using MilkBabyBusiness.Base;
using MilkBabyCommon;
using MilkBabyData;
using MilkBabyData.Models;

namespace MilkBabyBusiness.Category;
public interface ICustomerBusiness
{
    Task<IBusinessResult> GetAll();
    Task<IBusinessResult> GetById(Guid code);
    Task<IBusinessResult> Save(Customer currency);
    Task<IBusinessResult> Update(Customer currency);
    Task<IBusinessResult> DeleteById(Guid code);
    Task<IBusinessResult> GetByName(String key);
}
public class CustomerBusiness : ICustomerBusiness
{
    //private readonly CurrencyDAO _DAO;        
    //private readonly CurrencyRepository _currencyRepository;
    private readonly UnitOfWork _unitOfWork;

    public CustomerBusiness()
    {
        //_currencyRepository ??= new CurrencyRepository();            
        _unitOfWork ??= new UnitOfWork();
    }

    public async Task<IBusinessResult> GetAll()
    {
        try
        {
            #region Business rule
            #endregion

            //var currencies = _DAO.GetAll();
            //var currencies = await _currencyRepository.GetAllAsync();
            var currencies = await _unitOfWork.CustomerRepository.GetAllAsync();


            if (currencies == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, currencies);
            }
        }
        catch (Exception ex)
        {
            return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
        }
    }

    public async Task<IBusinessResult> GetByName(String code)
    {
        try
        {
            #region Business rule
            #endregion

            //var currency = await _currencyRepository.GetByIdAsync(code);
            var currency = await _unitOfWork.CustomerRepository.GetByNameAsync(code);

            if (currency == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, currency);
            }
        }
        catch (Exception ex)
        {
            return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
        }
    }
    public async Task<IBusinessResult> GetById(Guid code)
    {
        try
        {
            #region Business rule
            #endregion

            //var currency = await _currencyRepository.GetByIdAsync(code);
            var currency = await _unitOfWork.CustomerRepository.GetByIdAsync(code);

            if (currency == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, currency);
            }
        }
        catch (Exception ex)
        {
            return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
        }
    }

    public async Task<IBusinessResult> Save(Customer currency)
    {
        try
        {
            //int result = await _currencyRepository.CreateAsync(currency);
            int result = await _unitOfWork.CustomerRepository.CreateAsync(currency);
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

    public async Task<IBusinessResult> Update(Customer currency)
    {
        try
        {
            //int result = await _currencyRepository.UpdateAsync(currency);
            int result = await _unitOfWork.CustomerRepository.UpdateAsync(currency);

            if (result > 0)
            {
                return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
            }
            else
            {
                return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
            }
        }
        catch (Exception ex)
        {
            return new BusinessResult(-4, ex.ToString());
        }
    }

    public async Task<IBusinessResult> DeleteById(Guid code)
    {
        try
        {
            //var currency = await _currencyRepository.GetByIdAsync(code);
            var currency = await _unitOfWork.CustomerRepository.GetByIdAsync(code);
            if (currency != null)
            {
                //var result = await _currencyRepository.RemoveAsync(currency);
                var result = await _unitOfWork.CustomerRepository.RemoveAsync(currency);
                if (result)
                {
                    return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG);
                }
            }
            else
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
            }
        }
        catch (Exception ex)
        {
            return new BusinessResult(-4, ex.ToString());
        }
    }

}

