using PSV.Core;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(BackendContext context) : base(context)
        {

        }

        public override PageResponse<Appointment> GetPage(PageModel model)
        {
            var query = BackendContext.Appointments.Include("Patient").Include("Doctor").Where(x => (x.Deleted == false ));

            return new PageResponse<Appointment>(query.OrderBy(x => x.Id).Skip(model.Page).Take(model.PerPage).ToList(), query.Count());
        }
    }
}
