using MilkBabyBusiness.Base;
using MilkBabyCommon;
using MilkBabyData;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBabyBusiness.Category
{
    public interface IOrderItemBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(Guid id);
        Task<IBusinessResult> Save(OrderItem orderItem);
        Task<IBusinessResult> Update(OrderItem orderItem);
        Task<IBusinessResult> DeleteById(Guid id);
    }

    public class OrderItemBusiness : IOrderItemBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public OrderItemBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.OrderItemRepository.GetAllAsync();

                if (products == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, products);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetById(Guid id)
        {
            try
            {
                #region Business rule
                #endregion

                var product = await _unitOfWork.OrderItemRepository.GetByIdAsync(id);

                if (product == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, product);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Save(OrderItem orderItem)
        {

            try
            {
                int result = await _unitOfWork.OrderItemRepository.CreateAsync(orderItem);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> Update(OrderItem orderItem)
        {
            try
            {
                await _unitOfWork.OrderItemRepository.UpdateAsync(orderItem);
                return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> DeleteById(Guid id)
        {
            try
            {
                var orderItem = await _unitOfWork.OrderItemRepository.GetByIdAsync(id);
                if (orderItem != null)
                {
                    await _unitOfWork.OrderItemRepository.RemoveAsync(orderItem);
                    return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> GetByOrderId(Guid orderId)
        {
            try
            {
                #region Business rule
                #endregion

                var product = await _unitOfWork.OrderItemRepository.GetByOrderIdAsync(orderId);

                if (product == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, product);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
    }
}
