using PSV.Model;
using PSV.Repository;
using System;

namespace PSV.Service
{
    public class DoctorTypeService
    {
        public DoctorType Add(DoctorType doctorType)
        {
            if (doctorType == null)
            {
                return null;
            }

            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    doctorType.DateCreated = DateTime.Now;
                    doctorType.DateUpdated = DateTime.Now;
                    doctorType.Deleted = false;
                    unitOfWork.DoctorTypes.Add(doctorType);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return doctorType;
        }

        public PageResponse<DoctorType> GetPage(PageModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    return unitOfWork.DoctorTypes.GetPage(model);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
