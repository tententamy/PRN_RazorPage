using MilkBabyBusiness.Category;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MilkBabyWpfApp.UI
{
    /// <summary>
    /// Interaction logic for wCustomer.xaml
    /// </summary>
    public partial class wCustomer : Window
    {
        private readonly CustomerBusiness _business;
        public wCustomer()
        {
            InitializeComponent();
            _business = new CustomerBusiness();
            LoadGridCustomers();

        }
        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            
                try
                {
                    Guid idTmp = new Guid();
                    Guid.TryParse(txtCustomerID.Text, out idTmp);

                    var item = await _business.GetById(idTmp);

                    if (item.Data == null)
                    {
                    var currency = new Customer()
                    {
                            CustomerId = Guid.NewGuid(),
                            CustomerName = txtCustomerName.Text,
                            CustomerEmail = txtCustomerEmail.Text,
                            CustomerAddress = txtCustomerAddress.Text,
                            CustomerPhone = txtCustomerPhone.Text,
                            CustomerImg = txtCustomerImg.Text,
                            CustomerPassword = txtCustomerPassword.Text,
                        };

                        var result = await _business.Save(currency);
                        MessageBox.Show(result.Message, "Save");
                    }
                    else
                    {

                    var currency = item.Data as Customer;
                        //currency.CurrencyCode = txtCurrencyCode.Text;
                        currency.CustomerName = txtCustomerName.Text;
                        currency.CustomerAddress = txtCustomerAddress.Text;
                        currency.CustomerEmail = txtCustomerEmail.Text;
                        currency.CustomerPhone = txtCustomerPhone.Text;
                        currency.CustomerPassword = txtCustomerPassword.Text;
                        currency.CustomerImg = txtCustomerImg.Text;

                        var result = await _business.Update(currency);
                        MessageBox.Show(result.Message, "Update");
                    }

                    txtCustomerName.Text = string.Empty;
                    txtCustomerAddress.Text = string.Empty;
                    txtCustomerEmail.Text = string.Empty;
                    txtCustomerPhone.Text = string.Empty;
                    txtCustomerPassword.Text = string.Empty;
                    txtCustomerImg.Text = string.Empty;
                    this.LoadGridCustomers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                }

            
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e) 
        {
            txtCustomerID.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerAddress.Text = string.Empty;
            txtCustomerEmail.Text = string.Empty;
            txtCustomerPhone.Text = string.Empty;
            txtCustomerPassword.Text = string.Empty;
            txtCustomerImg.Text = string.Empty;
        }
        private async void grdCustomer_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (grdCustomer.SelectedItem != null)
            {
                var customer = grdCustomer.SelectedItem as Customer;
                if (customer != null)
                {
                    var result = await _business.DeleteById(customer.CustomerId);
                    MessageBox.Show(result.Message, "Delete");


                    txtCustomerName.Text = string.Empty;
                    txtCustomerAddress.Text = string.Empty;
                    txtCustomerEmail.Text = string.Empty;
                    txtCustomerPhone.Text = string.Empty;
                    txtCustomerPassword.Text = string.Empty;
                    txtCustomerImg.Text = string.Empty;
                    LoadGridCustomers();
                }
            }
        }
        private async void grdCustomer_MouseDouble_Click(object sender, RoutedEventArgs e) 
            {
                if (grdCustomer.SelectedItem != null)
                {
                    var customer = grdCustomer.SelectedItem as Customer;
                    txtCustomerID.Text = customer.CustomerId.ToString();
                    txtCustomerName.Text = customer.CustomerName;
                    txtCustomerAddress.Text = customer.CustomerAddress;
                    txtCustomerEmail.Text = customer.CustomerEmail;
                    txtCustomerPhone.Text = customer.CustomerPhone;
                    txtCustomerPassword.Text = customer.CustomerPassword;
                    txtCustomerImg.Text = customer.CustomerImg;

            }
            }

        private async void LoadGridCustomers() 
        {
           
                var result = await _business.GetAll();

                if (result.Status > 0 && result.Data != null)
                {
                    grdCustomer.ItemsSource = result.Data as List<Customer>;
                }
                else
                {
                    grdCustomer.ItemsSource = new List<Customer>();
                }
            
        }
    }
}
