using Microsoft.EntityFrameworkCore;
using PSV.Core;
using PSV.Model;
using System;
using System.Linq;

namespace PSV.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(BackendContext context) : base(context)
        {

        }
        
        public PageResponse<Appointment> GetPage(PageModel model, long from, long to, int doctorId, string type)
        {
            var query = BackendContext.Appointments.Include("Patient").Include("Doctor").Where(x => (x.Deleted == false));

            if (model.User != null && model.User.UserType == "PATIENT")
            {
                if (from != 0 && to != 0 && type != "")
                {
                    DateTime fromDate = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(from);
                    DateTime toDate = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(to);

                    if (type == "DOCTOR")
                    {
                        fromDate = fromDate.AddDays(-7);
                        toDate = toDate.AddDays(7);

                        query = query.Where(x => x.Date > fromDate && x.Date < toDate && x.IsFree && x.Doctor.Id == doctorId);
                    }
                    else
                    {
                        query = query.Where(x => x.Date > fromDate && x.Date < toDate && x.IsFree);
                    }
                }
                else
                {
                    query = query.Where(x => x.Patient.Id == model.User.Id || x.IsFree);
                }


            }

            if (model.User != null && model.User.UserType == "DOCTOR")
            {
                query = query.Where(x => x.Doctor.Id == model.User.Id);
            }

            return new PageResponse<Appointment>(query.OrderBy(x => x.Id).Skip(model.Page).Take(model.PerPage).ToList(), query.Count());
        }
    }
}
