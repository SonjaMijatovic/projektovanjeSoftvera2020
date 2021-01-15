using PSV.Core;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BackendContext context;

        public UnitOfWork(BackendContext context)
        {
            this.context = context;
            Users = new UserRepository(this.context);
            Appointments = new AppointmentRepository(this.context);
            Feedbacks = new FeedbackRepository(this.context);
            Visits = new VisitRepository(this.context);
        }

        public IUserRepository Users { get; private set; }
        public IAppointmentRepository Appointments { get; private set; }
        public IFeedbackRepository Feedbacks { get; private set; }
        public IVisitRepository Visits { get; private set; }

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
