// See https://aka.ms/new-console-template for more information

using MilkBabyBusiness.Category;
using MilkBabyData.Models;
using System;

Console.WriteLine("Hello, World!");

//var context = new efastContext(new Microsoft.EntityFrameworkCore.DbContextOptions<efastContext>());
//var currencyBusiness = new CurrencyBusiness(context);

var customerBusiness = new CustomerBusiness();
Guid IdNew = Guid.NewGuid(); // id mới tạo ngẫu nhiên
Guid Id = Guid.Parse("6e68bf7f-4b9a-4281-b02e-76eeec5e137e"); // id cũ để test
Customer customerTest = new Customer()
{
    CustomerId = Guid.Parse("F73DA9A8-84C0-470A-B739-F8FEC2DA5396"),
    CustomerName = "TestUpdate20",
    CustomerEmail = "TestUpdate"
};

//get all
Console.WriteLine("DAO.GetAll()");
var currencyResult = customerBusiness.GetAll();

if (currencyResult.Status > 0 && currencyResult.Result.Data != null)
{
    var customers = currencyResult.Result.Data as IEnumerable<Customer>;

    if (customers != null && customers.Any())
    {
        foreach (var customer in customers)
        {
            Console.WriteLine(customer.CustomerName);
        }
    }

}
else
{
    Console.WriteLine("Get All Currency fail");
}


// get by id
Console.WriteLine("DAO.GetById(code)");
currencyResult = customerBusiness.GetById(Id);

if (currencyResult.Status > 0 && currencyResult.Result.Data != null)
{
    var currency = (Customer)currencyResult.Result.Data;
    Console.WriteLine(currency.CustomerName);
}

//save
Console.WriteLine("DAO.Save(code)");
currencyResult = customerBusiness.GetById(IdNew);
if (currencyResult.Status > 0 && currencyResult.Result.Data != null)
{
    Console.WriteLine("This currency is exist");
}
else
{
    var item = new Customer()
    {
        CustomerId = IdNew,
        CustomerEmail = "minhtam12345",
        CustomerName = "teny"
    };

    var result = customerBusiness.Save(item);
    Console.WriteLine(result.Result.Message);
}

/*//Remove
Console.WriteLine("DAO.Remove()");
currencyResult = customerBusiness.GetById(Id);
if (currencyResult.Status > 0 && currencyResult.Result.Data != null)
{
    var result = customerBusiness.DeleteById((Customer)currencyResult.Result.Data);
    Console.WriteLine(result.Result.Message);
}
else
{

    Console.WriteLine("This currency is not exist");
}*/

/*//Update
Console.WriteLine("DAO.Update()");
currencyResult = customerBusiness.GetById(customerTest.CustomerId);
if (currencyResult.Status > 0 && currencyResult.Result.Data != null)
{
    var result = customerBusiness.Update(customerTest);
    Console.WriteLine(result.Result.Message);
}
else
{

    Console.WriteLine("This currency is not exist");
}
*/


/**CALL DAO********************************************************************************************/
//var currencyDAO = new CurrencyDAO();

Console.ReadLine();

