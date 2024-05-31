using MilkBabyData.Models;
using MilkBabyData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBabyData
{
    public class UnitOfWork
    {
        private Net1702Prn221MilkBabyContext _unitOfWorkContext;
        private CustomerRepository _customer;
        public UnitOfWork()
        {
            _unitOfWorkContext ??= new Net1702Prn221MilkBabyContext();
        }

        public CustomerRepository CustomerRepository
        {
            get 
            {
                /*return _customer ??= new Repository.CustomerRepository();*/
                return _customer ??= new Repository.CustomerRepository(_unitOfWorkContext);
            }
        }
    }
}
