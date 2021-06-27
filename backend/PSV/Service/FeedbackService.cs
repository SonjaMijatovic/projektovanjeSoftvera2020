using PSV.Model;
using PSV.Repository;
using System;
using Microsoft.EntityFrameworkCore;
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
            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    Feedback feedback = unitOfWork.Feedbacks.Get(id);

                    if (feedback == null)
                    {
                        return;
                    }

                    feedback.Visible = true;
                    unitOfWork.Context.Feedbacks.Attach(feedback);
                    unitOfWork.Context.Entry(feedback).State = EntityState.Modified;
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
            }
        }

        public void Unpublish(int id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    Feedback feedback = unitOfWork.Feedbacks.Get(id);

                    if (feedback == null)
                    {
                        return;
                    }

                    feedback.Visible = false;
                    unitOfWork.Context.Feedbacks.Attach(feedback);
                    unitOfWork.Context.Entry(feedback).State = EntityState.Modified;
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
            }
        }

        public Feedback Add(Feedback feedback)
        {
            if (feedback == null)
            {
                return null;
            }

            try
            {
                feedback.DateCreated = DateTime.Now;
                feedback.DateUpdated = DateTime.Now;
                feedback.Deleted = false;
                feedback.Visible = false;

                User user = _unitOfWork.Users.Get(feedback.User.Id);
                feedback.User = user;
                _unitOfWork.Feedback.Add(feedback);
                _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return null;
            }

            return feedback;
        }

        public PageResponse<Feedback> GetPage(PageModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    return unitOfWork.Feedbacks.GetPage(model);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public PageResponse<Feedback> GetPublic(PageModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    return unitOfWork.Feedbacks.GetPublic(model);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}