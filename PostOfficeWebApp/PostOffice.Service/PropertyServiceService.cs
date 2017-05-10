using PostOffice.Model.Models;
using PostOfiice.DAta.Infrastructure;
using PostOfiice.DAta.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice.Service
{
    public interface IPropertyServiceService {
        PropertyService Add(PropertyService pro);

        PropertyService Delete(int id);
        IEnumerable<PropertyService> GetAll();

        IEnumerable<PropertyService> GetAll(string keyword);

        IEnumerable<PropertyService> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        void Update(PropertyService pro);

        void Save();

        PropertyService GetById(int id);
    }
    public class PropertyServiceService : IPropertyServiceService
    {

        private IPropertyServiceRepository _proRepository;
        private IUnitOfWork _uniOfWork;

        public PropertyServiceService(IPropertyServiceRepository proRepository, IUnitOfWork unitOfWork)
        {
            this._proRepository = proRepository;
            this._uniOfWork = unitOfWork;
        }

        public PropertyService Add(PropertyService pro)
        {
            return _proRepository.Add(pro);
        }

        public PropertyService Delete(int id)
        {
            return _proRepository.Delete(id);
        }

        public IEnumerable<PropertyService> GetAll()
        {
            return _proRepository.GetAll();
        }

        public IEnumerable<PropertyService> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _proRepository.GetMulti(x => x.Name.Contains(keyword));
            }
            else
            {
                return _proRepository.GetAll();
            }
        }

        public PropertyService GetById(int id)
        {
            return _proRepository.GetSingleByID(id);
        }

        public void Save()
        {
            _uniOfWork.Commit();
        }

        public IEnumerable<PropertyService> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public void Update(PropertyService pro)
        {
            _proRepository.Update(pro);
        }
    }
}
