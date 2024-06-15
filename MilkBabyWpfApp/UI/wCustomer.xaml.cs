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
                    var customer = new Customer()
                    {
                        CustomerId = Guid.NewGuid(),
                        CustomerName = txtCustomerName.Text,
                        CustomerEmail = txtCustomerEmail.Text,
                        CustomerAddress = txtCustomerAddress.Text,
                        CustomerPhone = txtCustomerPhone.Text,
                        CustomerImg = txtCustomerImg.Text,
                        CustomerPassword = txtCustomerPassword.Text,
                        CustomerBirthDate = dpCustomerBirthDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpCustomerBirthDate.SelectedDate.Value) : null,
                        CustomerGender = ((ComboBoxItem)cbCustomerGender.SelectedItem)?.Content?.ToString(),
                        CustomerStatus = chkCustomerStatus.IsChecked ?? false
                    };

                    var result = await _business.Save(customer);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var customer = item.Data as Customer;
                    customer.CustomerName = txtCustomerName.Text;
                    customer.CustomerAddress = txtCustomerAddress.Text;
                    customer.CustomerEmail = txtCustomerEmail.Text;
                    customer.CustomerPhone = txtCustomerPhone.Text;
                    customer.CustomerPassword = txtCustomerPassword.Text;
                    customer.CustomerImg = txtCustomerImg.Text;
                    customer.CustomerBirthDate = dpCustomerBirthDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpCustomerBirthDate.SelectedDate.Value) : null;
                    customer.CustomerGender = ((ComboBoxItem)cbCustomerGender.SelectedItem)?.Content?.ToString();
                    customer.CustomerStatus = chkCustomerStatus.IsChecked ?? false;

                    var result = await _business.Update(customer);
                    MessageBox.Show(result.Message, "Update");
                }

                ClearForm();
                LoadGridCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
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

                    ClearForm();
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
                dpCustomerBirthDate.Text = customer.CustomerBirthDate.ToString();
                cbCustomerGender.Text = customer.CustomerGender;
                chkCustomerStatus.IsChecked = customer.CustomerStatus;
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

        private void ClearForm()
        {
            txtCustomerID.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerAddress.Text = string.Empty;
            txtCustomerEmail.Text = string.Empty;
            txtCustomerPhone.Text = string.Empty;
            txtCustomerPassword.Text = string.Empty;
            txtCustomerImg.Text = string.Empty;
            dpCustomerBirthDate.SelectedDate = null;
            cbCustomerGender.SelectedIndex = -1;
            chkCustomerStatus.IsChecked = false;
        }
    }
}
