using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSV.Core;
using PSV.Model;
using PSV.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PSV.Controllers
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BackendContext context;

        public UnitOfWork(BackendContext context)
        {
            this.context = context;
            Users = new UserRepository(this.context);
            AppointmentRepository = new AppointmentRepository(this.context);


        }

        public IUserRepository Users { get; private set; }
        public IAppointmentRepository AppointmentRepository { get; private set; }
        
        public BackendContext Context
        {
            get { return context; }
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
