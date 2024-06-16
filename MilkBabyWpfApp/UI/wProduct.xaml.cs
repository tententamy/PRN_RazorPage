using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyWpfApp.UI
{
    public partial class wProduct : Window
    {
        private readonly ProductBusiness _business;

        public wProduct()
        {
            InitializeComponent();
            _business = new ProductBusiness();
            LoadGridProducts();
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Guid idTmp = Guid.Empty;
                Guid.TryParse(txtProductId.Text, out idTmp);
                var item = await _business.GetById(idTmp);
                DateOnly? startDate = dpDateStart.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDateStart.SelectedDate.Value) : null;
                DateOnly? endDate = dpDateEnd.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDateEnd.SelectedDate.Value) : null;

                var product = item.Data as Product ?? new Product { ProductId = Guid.NewGuid() };

                product.ProductName = txtName.Text;
                product.ProductCategory = txtCategory.Text;
                product.ProductPrice = decimal.TryParse(txtPrice.Text, out decimal price) ? price : 0;
                product.ProductQuantity = int.TryParse(txtQuantity.Text, out int quantity) ? quantity : 0;
                product.ProductWeight = decimal.TryParse(txtWeight.Text, out decimal weight) ? weight : 0;
                product.ProductDimensions = txtDimensions.Text;
                product.ProductDescription = txtDescription.Text;
                product.ProductDateStart = startDate ?? DateOnly.MinValue;
                product.ProductDateEnd = endDate ?? DateOnly.MinValue;
                product.ProductStatus = chkStatus.IsChecked ?? false;
                product.ProductImg = txtImageUrl.Text;

                var result = item.Data == null
                    ? await _business.Save(product)
                    : await _business.Update(product);

                MessageBox.Show(result.Message, item.Data == null ? "Save" : "Update");
                LoadGridProducts();
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
        }

        private async void grdProduct_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Button button && button.CommandParameter is Guid productId)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        var deleteResult = await _business.DeleteById(productId);
                        MessageBox.Show(deleteResult.Message, deleteResult.Status > 0 ? "Delete" : "Error");
                        if (deleteResult.Status > 0) LoadGridProducts();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void grdProduct_MouseDouble_Click(object sender, MouseButtonEventArgs e)
        {
            if (grdProduct.SelectedItem is Product product)
            {
                txtProductId.Text = product.ProductId.ToString();
                txtName.Text = product.ProductName;
                txtCategory.Text = product.ProductCategory;
                txtPrice.Text = product.ProductPrice.ToString();
                txtQuantity.Text = product.ProductQuantity.ToString();
                txtWeight.Text = product.ProductWeight.ToString();
                txtDimensions.Text = product.ProductDimensions;
                txtDescription.Text = product.ProductDescription;
                dpDateStart.SelectedDate = product.ProductDateStart.HasValue ? product.ProductDateStart.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null;
                dpDateEnd.SelectedDate = product.ProductDateEnd.HasValue ? product.ProductDateEnd.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null;
                chkStatus.IsChecked = product.ProductStatus;
                txtImageUrl.Text = product.ProductImg;
            }
        }

        private async void LoadGridProducts()
        {
            var result = await _business.GetAll();
            grdProduct.ItemsSource = result.Status > 0 && result.Data != null
                ? result.Data as List<Product>
                : new List<Product>();
        }

        private void ClearTextBoxes()
        {
            txtProductId.Clear();
            txtName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtWeight.Clear();
            txtDimensions.Clear();
            txtDescription.Clear();
            dpDateStart.SelectedDate = null;
            dpDateEnd.SelectedDate = null;
            chkStatus.IsChecked = false;
            txtImageUrl.Clear();
        }
    }
}