using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Core
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        PageResponse<Appointment> GetPage(PageModel model, long from, long to, int doctorId, string type);
    }
}
