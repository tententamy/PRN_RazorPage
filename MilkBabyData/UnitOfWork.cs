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
            private OrderItemRepository _orderItemRepository;
            private OrderRepository _orderRepository;
            private ReviewRepository _reviewRepository;
            private NET1702_PRN221_MilkBabyContext _unitOfWorkContext;

        public UnitOfWork()
        {
            _unitOfWorkContext ??= new NET1702_PRN221_MilkBabyContext();
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

        public OrderRepository OrderRepository
        {
            get
            {
                /* return _vendorRepository ??= new Repository.VendorRepository();*/
                return _orderRepository ??= new Repository.OrderRepository(_unitOfWorkContext);
            }
        }

        public OrderItemRepository OrderItemRepository
        {
            get
            {
                /* return _vendorRepository ??= new Repository.VendorRepository();*/
                return _orderItemRepository ??= new Repository.OrderItemRepository(_unitOfWorkContext);
            }
        }

        public ReviewRepository ReviewRepository
        {
            get
            {
                /* return _vendorRepository ??= new Repository.VendorRepository();*/
                return _reviewRepository ??= new Repository.ReviewRepository(_unitOfWorkContext);
            }
        }
    }
}
