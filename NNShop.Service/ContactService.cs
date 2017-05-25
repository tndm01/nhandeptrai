using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNShop.Data.Infrastructure;
using NNShop.Data.Repositories;
using NNShop.Model.Models;

namespace NNShop.Service
{
    public interface IContactService
    {
        ContactDetail GetDefaultContact();
    }
    public class ContactService : IContactService
    {
        IContactRepository _contactDetailRepository;
        IUnitOfWork _unitOfWork;

        public ContactService(IContactRepository contactRepository, IUnitOfWork unitOfWork)
        {
            this._contactDetailRepository = contactRepository;
            this._unitOfWork = unitOfWork;
        }

        public ContactDetail GetDefaultContact()
        {
            return _contactDetailRepository.GetSingleByCondition(x => x.Status);
        }
    }
}
