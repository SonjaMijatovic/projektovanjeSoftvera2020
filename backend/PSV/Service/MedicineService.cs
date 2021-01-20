using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Service
{
    public class MedicineService
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
    }
}
