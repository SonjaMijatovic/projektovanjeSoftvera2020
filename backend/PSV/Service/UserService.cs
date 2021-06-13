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
        public void Block(int id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    User user = unitOfWork.Users.Get(id);

                    if (user == null)
                    {
                        return;
                    }

                    user.Blocked = true;
                    unitOfWork.Context.Users.Attach(user);
                    unitOfWork.Context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
            }
        }

        public void Unlock(int id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    User user = unitOfWork.Users.Get(id);

                    if (user == null)
                    {
                        return;
                    }

                    user.Blocked = false;
                    unitOfWork.Context.Users.Attach(user);
                    unitOfWork.Context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
            }
        }

        public User Add(User user)
        {
            throw new NotImplementedException();
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

        public User FindUserByEmail(string email)
        {
            using (var unitOfWork = new UnitOfWork(new BackendContext()))
            {
                return unitOfWork.Users.GetUserWithEmail(email);
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

        public virtual bool DoesUserExist(string userDataEmail)
        {
            using (var unitOfWork = new UnitOfWork(new BackendContext()))
            {
                return unitOfWork.Users.GetUserWithEmail(userDataEmail) != null;
            }
        }
    }
}