using MilkBabyBusiness.Base;
using MilkBabyCommon;
using MilkBabyData.Models;
using MilkBabyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBabyBusiness.Category
{
    public interface IOrderBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(Guid id);
        Task<IBusinessResult> Save(Order order);
        Task<IBusinessResult> Update(Order order);
        Task<IBusinessResult> DeleteById(Guid id);
    }

    public class OrderBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public OrderBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.OrderRepository.GetAllAsync();

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

                var product = await _unitOfWork.OrderRepository.GetByIdAsync(id);

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

        public async Task<IBusinessResult> Save(Order order)
        {

            try
            {
                int result = await _unitOfWork.OrderRepository.CreateAsync(order);
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

        public async Task<IBusinessResult> Update(Order order)
        {
            try
            {
                await _unitOfWork.OrderRepository.UpdateAsync(order);
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
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
                if (order != null)
                {
                    await _unitOfWork.OrderRepository.RemoveAsync(order);
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
    }
}
