
using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace PSV.Service
{
    public class MedsService
    {
        public Medicine Add(Medicine medicine)
        {
            if (medicine == null)
            {
                return null;
            }

            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    medicine.DateCreated = DateTime.Now;
                    medicine.DateUpdated = DateTime.Now;
                    medicine.Deleted = false;
                    unitOfWork.Medicines.Add(medicine);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return medicine;
        }

        public PageResponse<Medicine> GetPage(PageModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    return unitOfWork.Medicines.GetPage(model);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async void AddMore(int id, double amount) {
            try
            {
                AppContext.SetSwitch(
                    "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                using var channel = GrpcChannel.ForAddress("http://localhost:8081");
                var client =  new MedicineService.MedicineServiceClient(channel);
                var reply = await client.getMedicineAsync(new MedicineRequest { MedicineId = id.ToString() });

                if (reply.Result != "OK")
                {
                    return;
                }
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    Medicine medicine = unitOfWork.Medicines.Get(id);
                    if(medicine == null)
                    {
                        return;
                    }
                    medicine.Amount += amount;
                    unitOfWork.Medicines.Update(medicine);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return;
            }
        }
    }
}
