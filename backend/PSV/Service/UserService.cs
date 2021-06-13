using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSV.Core;

namespace PSV.Service
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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
            if (user == null)
            {
                return null;
            }
            try
            {
                    user.DateCreated = DateTime.Now;
                    user.DateUpdated = DateTime.Now;
                    user.Deleted = false;
                    user.Blocked = false;

                    if (user.DoctorType != null)
                    {
                        user.DoctorType = _unitOfWork.DoctorTypes.Get(user.DoctorType.Id);
                    }

                    if (string.IsNullOrEmpty(user.UserType))
                    {
                        user.UserType = "PATIENT";
                    }

                    _unitOfWork.Users.Add(user);
                    _unitOfWork.Complete();
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

        public bool DoesUserExist(string userDataEmail)
        {
            return _unitOfWork.Users.GetUserWithEmail(userDataEmail) != null;
        }
    }
}