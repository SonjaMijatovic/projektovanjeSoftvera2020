using PSV.Core;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class MedicineRepository : Repository<Medicine>, IMedicineRepository
    { 
        public MedicineRepository(BackendContext context) : base(context) { }

        public override PageResponse<Medicine> GetPage(PageModel model)
        {
            var query = BackendContext.Medicines.Where(x => (x.Deleted == false && (x.Name.Contains(model.Search))));

            return new PageResponse<Medicine>(query.OrderBy(x => x.Id).Skip(model.Page).Take(model.PerPage).ToList(), query.Count());
        }
    }
}