using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Service
{
    public class VisitService
    {
        public Visit Add(Visit visit)
        {
            if (visit == null)
            {
                return null;
            }

            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    visit.DateCreated = DateTime.Now;
                    visit.DateUpdated = DateTime.Now;
                    visit.Deleted = false;
                    unitOfWork.Visits.Add(visit);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return visit;
        }

        public PageResponse<Visit> GetPage(PageModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    return unitOfWork.Visits.GetPage(model);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
