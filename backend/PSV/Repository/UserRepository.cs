using Microsoft.EntityFrameworkCore;
using PSV.Core;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BackendContext context) : base(context)
        {

        }
        public User GetUserWithEmail(string email)
        {
            return BackendContext.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public User GetUserWithEmailAndPassword(string email, string password)
        {
            return BackendContext.Users.Where(x => (x.Email == email && x.Password == password)).FirstOrDefault();
        }

        public override PageResponse<User> GetPage(PageModel model)
        {
            var query = BackendContext.Users.Include("DoctorType").Where(x => (x.Deleted == false && (x.FirstName.Contains(model.Search) || x.LastName.Contains(model.Search))));



            return new PageResponse<User>(query.OrderBy(x => x.Id).Skip(model.Page).Take(model.PerPage).ToList(), query.Count());
        }
    }
}
