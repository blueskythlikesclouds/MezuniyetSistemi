using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.Business.Concrete
{
    public class EMailManager : IEmailService
    {

        private IUnitOfWork _unitOfWork { get; }

        public EMailManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Email email)
        {
            _unitOfWork.Emails.Add(email);
            _unitOfWork.Save();
        }

        public void Delete(Email email)
        {
            _unitOfWork.Emails.Delete(email);
            _unitOfWork.Save();
        }

        public IList<Email> FindAll(bool trackChanges)
        {
            return _unitOfWork.Emails.FindAll(trackChanges).ToList();
        }

        public Email FindById(int id, bool trackChanges)
        {
            return _unitOfWork.Emails.FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();
        }

        public void Update(int id, Email email, bool trackChanges)
        {
            _unitOfWork.Emails.Update(email);
            _unitOfWork.Save();
        }
    }
}
