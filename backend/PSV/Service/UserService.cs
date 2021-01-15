using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Service
{
    public class UserService
    {
        public User Add(User user)
        {
            if (user == null)
            {
                return null;
            }

            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    user.DateCreated = DateTime.Now;
                    user.DateUpdated = DateTime.Now;
                    user.Deleted = false;
                    unitOfWork.Users.Add(user);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return user;
        }

        public User GetUserWithEmailAndPassword(string email, string password)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    return unitOfWork.Users.GetUserWithEmailAndPassword(email, password);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public User GetUserWithEmail(string email)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    return unitOfWork.Users.GetUserWithEmail(email);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public PageResponse<User> GetPage(PageModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    return unitOfWork.Users.GetPage(model);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
