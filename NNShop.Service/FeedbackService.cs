using NNShop.Data.Infrastructure;
using NNShop.Data.Repositories;
using NNShop.Model.Models;

namespace NNShop.Service
{
    public interface IFeedbackService
    {
        Feedback Create(Feedback fb);

        void Save();
    }

    public class FeedbackService : IFeedbackService
    {
        private IFeedBackRepository _feedbackRepository;
        private IUnitOfWork _unitOfWork;

        public FeedbackService(IFeedBackRepository feedbacRepository, IUnitOfWork unitOfWork)
        {
            this._feedbackRepository = feedbacRepository;
            this._unitOfWork = unitOfWork;
        }

        public Feedback Create(Feedback fb)
        {
            return _feedbackRepository.Add(fb);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}