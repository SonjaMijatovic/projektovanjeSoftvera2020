using PSV.Core;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class DoctorTypeRepository : Repository<DoctorType>, IDoctorTypeRepository
    {
        public DoctorTypeRepository(BackendContext context) : base(context)
        {

        }

        public override PageResponse<DoctorType> GetPage(PageModel model)
        {
            var query = BackendContext.DocumentTypes.Where(x => (x.Deleted == false && (x.Name.Contains(model.Search))));

            return new PageResponse<DoctorType>(query.OrderBy(x => x.Id).Skip(model.Page).Take(model.PerPage).ToList(), query.Count());
        }
    }
}
