using PSV.Core;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class VisitRepository : Repository<Visit>, IVisitRepository
    {
        public VisitRepository(BackendContext context) : base(context)
        {

        }
    }
}
