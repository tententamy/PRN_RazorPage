using System;
using System.Collections.Generic;
using System.Linq;
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
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyWpfApp.UI
{
    /// <summary>
    /// Interaction logic for wProduct.xaml
    /// </summary>
    public partial class wProduct : Window
    {

        private readonly ProductBusiness _business;
        private readonly OrderItemBusiness _orderItemBusiness;
        public wProduct()
        {
            InitializeComponent();
            _business = new ProductBusiness();
            LoadGridProducts();

        }
        private async void ButtonSave_Click(object sender, RoutedEventArgs e) {
            try
            {

                Guid idTmp = new Guid();
                Guid.TryParse(txtProductId.Text, out idTmp);
                var item = await _business.GetById(idTmp);
                if (item.Data == null)
                {
                    var product = new Product()
                    {
                        ProductId = Guid.NewGuid(), 
                        ProductName = txtName.Text,
                        ProductPrice = decimal.Parse(txtPrice.Text), 
                        ProductQuantity = int.Parse(txtQuantity.Text), 
                        ProductDescription = txtDesription.Text,
                    };
                    var result = await _business.Save(product);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var product = item.Data as Product;
                    product.ProductName = txtName.Text;
                    product.ProductPrice = decimal.Parse(txtPrice.Text);
                    product.ProductQuantity = int.Parse(txtQuantity.Text);
                    product.ProductDescription = txtDesription.Text;
                    var result = await _business.Update(product);
                    MessageBox.Show(result.Message, "Update");
                }
                txtProductId.Text = string.Empty;
                txtName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtDesription.Text = string.Empty;
                txtQuantity.Text = string.Empty;
                this.LoadGridProducts();
                this.ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }


        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e) { }
        private async void grdProduct_ButtonDelete_Click(object sender, RoutedEventArgs e) {

            try
            {
                var button = sender as Button;
                if (button != null && button.CommandParameter != null)
                {
                    Guid productId = (Guid)button.CommandParameter;

                    
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        var deleteResult = await _business.DeleteById(productId);
                        if (deleteResult.Status > 0)
                        {
                            MessageBox.Show(deleteResult.Message, "Delete");
                            LoadGridProducts();
                        }
                        else
                        {
                            MessageBox.Show(deleteResult.Message, "Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }

        }
        private async void grdProduct_MouseDouble_Click(object sender, RoutedEventArgs e) {

            if (grdProduct.SelectedItem != null)
            {
                var product = grdProduct.SelectedItem as Product;
                txtProductId.Text = product.ProductId.ToString();
                txtName.Text = product.ProductName;
                txtPrice.Text = product.ProductPrice.ToString();
                txtQuantity.Text = product.ProductQuantity.ToString();
                txtDesription.Text = product.ProductDescription;
            }
        }

        private async void LoadGridProducts()
        {

            var result = await _business.GetAll();

            if (result.Status > 0 && result.Data != null)
            {
                grdProduct.ItemsSource = result.Data as List<Product>;
            }
            else
            {
                grdProduct.ItemsSource = new List<Product>();
            }

        }

        private void ClearTextBoxes()
        {
            txtProductId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtDesription.Text = string.Empty;
            txtQuantity.Text = string.Empty;
        }


    }
}
