using MilkBabyBusiness.Category;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MilkBabyWpfApp.UI
{
    public partial class wVendor : Window
    {
        private readonly VendorBusiness _business;


        public wVendor()
        {
            InitializeComponent();
            _business = new VendorBusiness();
            LoadGridVendors();
        }

        private async void ButtonSaveVendor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Guid idTmp = new Guid();
                Guid.TryParse(txtVendorId.Text, out idTmp);

                var item = await _business.GetById(idTmp);

                if (item.Data == null)
                {
                    var vendor = new Vendor()
                    {
                        VendorId = Guid.NewGuid(),
                        VendorName = txtVendorName.Text,
                        VendorAddress = txtVendorAddress.Text,
                        VendorPhone = txtVendorPhone.Text,
                        VendorEmail = txtVendorEmail.Text
                    };

                    var result = await _business.Save(vendor);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var vendor = item.Data as Vendor;
                    vendor.VendorName = txtVendorName.Text;
                    vendor.VendorAddress = txtVendorAddress.Text;
                    vendor.VendorPhone = txtVendorPhone.Text;
                    vendor.VendorEmail = txtVendorEmail.Text;

                    var result = await _business.Update(vendor);
                    MessageBox.Show(result.Message, "Update");
                }

                ClearVendorForm();
                LoadGridVendors();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void ButtonCancelVendor_Click(object sender, RoutedEventArgs e)
        {
            ClearVendorForm();
        }

        private async void grdVendor_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (grdVendor.SelectedItem != null)
            {
                var vendor = grdVendor.SelectedItem as Vendor;
                if (vendor != null)
                {
                    var result = await _business.DeleteById(vendor.VendorId);
                    MessageBox.Show(result.Message, "Delete");

                    ClearVendorForm();
                    LoadGridVendors();
                }
            }
        }

        private async void grdVendor_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (grdVendor.SelectedItem != null)
            {
                var vendor = grdVendor.SelectedItem as Vendor;
                txtVendorId.Text = vendor.VendorId.ToString();
                txtVendorName.Text = vendor.VendorName;
                txtVendorAddress.Text = vendor.VendorAddress;
                txtVendorPhone.Text = vendor.VendorPhone;
                txtVendorEmail.Text = vendor.VendorEmail;
            }
        }

        private async void LoadGridVendors()
        {
            var result = await _business.GetAll();

            if (result.Status > 0 && result.Data != null)
            {
                grdVendor.ItemsSource = result.Data as List<Vendor>;
            }
            else
            {
                grdVendor.ItemsSource = new List<Vendor>();
            }
        }

        private void ClearVendorForm()
        {
            txtVendorId.Text = string.Empty;
            txtVendorName.Text = string.Empty;
            txtVendorAddress.Text = string.Empty;
            txtVendorPhone.Text = string.Empty;
            txtVendorEmail.Text = string.Empty;
        }
    }
}
