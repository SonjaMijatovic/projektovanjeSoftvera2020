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
        public void Block(int id) {

            try {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    User user = unitOfWork.Users.Get(id);

                    if (user == null) {
                        return;
                    }

                    user.Blocked = true;
                    unitOfWork.Context.Users.Attach(user);
                    unitOfWork.Context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    unitOfWork.Complete();
                }
            }
            catch (Exception e) { }
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
            catch (Exception e) { }
        }

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
                    user.Blocked = false;

                    if(user.DoctorType != null)
                    {
                        user.DoctorType = unitOfWork.DoctorTypes.Get(user.DoctorType.Id);
                    }

                    if (user.UserType == null || user.UserType == "") {
                        user.UserType = "PATIENT";
                    }

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
