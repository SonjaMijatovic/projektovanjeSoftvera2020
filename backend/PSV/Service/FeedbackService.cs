using PSV.Model;
using PSV.Repository;
using System;
using PSV.Core;

namespace PSV.Service
{
    public class FeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public FeedbackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Publish(int id)
        {
            throw new NotImplementedException();
        }

        public void Unpublish(int id)
        {
            throw new NotImplementedException();
        }

        public Feedback Add(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public PageResponse<Feedback> GetPage(PageModel model)
        {
            throw new NotImplementedException();
        }

        public PageResponse<Feedback> GetPublic(PageModel model)
        {
            throw new NotImplementedException();
        }
    }
}