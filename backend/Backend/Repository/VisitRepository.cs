using RentCar.Core;
using RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Repository
{
    public class VisitRepository : Repository<Visit>, IVisitRepository
    {
        public VisitRepository(RentCarContext context) : base(context)
        {

        }
    }
}
