using Microsoft.EntityFrameworkCore;
using PSV.Core;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(BackendContext context) : base(context)
        {

        }

        public override PageResponse<Feedback> GetPage(PageModel model)
        {
            var query = BackendContext.Feedbacks.Include("User").Where(x => (x.Deleted == false && (x.Content.Contains(model.Search))));

            if (model.User != null && model.User.UserType == "PATIENT") 
            {
                query = query.Where(x => x.User.Id == model.User.Id);
            }

            return new PageResponse<Feedback>(query.OrderBy(x => x.Id).Skip(model.Page).Take(model.PerPage).ToList(), query.Count());
        }

        public PageResponse<Feedback> GetPublic(PageModel model)
        {
            var query = BackendContext.Feedbacks.Include("User").Where(x => (x.Visible == true));

            
            return new PageResponse<Feedback>(query.OrderBy(x => x.Id).Skip(model.Page).Take(model.PerPage).ToList(), query.Count());
        }
    }
}
