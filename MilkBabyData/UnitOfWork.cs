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
            private ProductRepository _product;
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
        }
}
