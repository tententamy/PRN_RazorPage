// See https://aka.ms/new-console-template for more information
using MilkBabyData.Models;

Console.WriteLine("Hello, World!");
var currencyBusiness = new Cus();
var currencyList = currencyBusiness.GetAll();

if (currencyList.Status > 0 && currencyList.Result.Data != null)
{
    var currencies = (List<Customer>)currencyList.Result.Data;

    if (currencies != null && currencies.Count > 0)
    {
        foreach (var currency in currencies)
        {
            Console.WriteLine(currency.CurrencyCode);
        }
    }

}
else
{
    Console.WriteLine("Get All Currency fail");
}