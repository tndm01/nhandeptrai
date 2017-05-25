using NNShop.Data.Infrastructure;

namespace NNShop.Service
{
    public interface ICommonService
    {
    }

    public class CommonService : ICommonService
    {
        private IUnitOfWork _unitOfWord;

        public CommonService(IUnitOfWork unitOfWord)
        {
            _unitOfWord = unitOfWord;
        }
    }
}