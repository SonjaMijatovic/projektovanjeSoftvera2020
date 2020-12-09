using RentCar.Model;
using RentCar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Service
{
    public class AppointmentService
    {
        public Appointment Add(Appointment appointment)
        {
            if (appointment == null)
            {
                return null;
            }

            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    appointment.DateCreated = DateTime.Now;
                    appointment.DateUpdated = DateTime.Now;
                    appointment.Deleted = false;
                    unitOfWork.Appointments.Add(appointment);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return appointment;
        }

        public PageResponse<Appointment> GetPage(PageModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    return unitOfWork.Appointments.GetPage(model);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
