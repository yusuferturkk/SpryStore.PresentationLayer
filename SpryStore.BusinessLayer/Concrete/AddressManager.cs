using SpryStore.BusinessLayer.Abstract;
using SpryStore.DataAccessLayer.Abstract;
using SpryStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpryStore.BusinessLayer.Concrete
{
    public class AddressManager : IAddressService
    {

        private readonly IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public void Insert(Address entity)
        {
            _addressDal.Insert(entity);
        }

        public void Update(Address entity)
        {
            _addressDal.Update(entity);
        }

        public void Delete(Address entity)
        {
            _addressDal.Delete(entity);
        }

        public Address GetById(int id)
        {
            return _addressDal.GetById(id);
        }

        public List<Address> GetList()
        {
            return _addressDal.GetList();
        }
    }
}
