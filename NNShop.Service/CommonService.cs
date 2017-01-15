using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNShop.Data.Infrastructure;
using NNShop.Model.Models;

namespace NNShop.Service
{
    public interface ICommonService
    {
    }
    public class CommonService : ICommonService
    {
        IUnitOfWork _unitOfWord;

        public CommonService(IUnitOfWork unitOfWord)
        {
            _unitOfWord = unitOfWord;
        }
    }
}
