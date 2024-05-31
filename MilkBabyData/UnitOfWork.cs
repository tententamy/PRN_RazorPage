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
            private CustomerRepository _customerRepository;
            private ProductRepository _product;
            private VendorRepository _vendorRepository;
        private Net1702Prn221MilkBabyContext _unitOfWorkContext;

        public UnitOfWork()
        {
            _unitOfWorkContext ??= new Net1702Prn221MilkBabyContext();
        }

        public ProductRepository ProductRepository
        {
                get
                {
                   /* return _product ??= new Repository.ProductRepository();*/
                    return _product ??= new Repository.ProductRepository(_unitOfWorkContext);
            }
            }

        public CustomerRepository CustomerRepository
        {
            get
            {
                /* return _customerRepository ??= new Repository.CustomerRepository();*/
                return _customerRepository ??= new Repository.CustomerRepository(_unitOfWorkContext);
            }
        }

        public VendorRepository VendorRepository
        {
            get
            {
                /* return _vendorRepository ??= new Repository.VendorRepository();*/
                return _vendorRepository ??= new Repository.VendorRepository(_unitOfWorkContext);
            }
        }
    }
}
