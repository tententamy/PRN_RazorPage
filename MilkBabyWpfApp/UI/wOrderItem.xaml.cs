using MilkBabyBusiness.Category;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MilkBabyWpfApp.UI
{
    public partial class wOrderItem : Window
    {
        private readonly OrderItemBusiness _business;

        public wOrderItem()
        {
            InitializeComponent();
            _business = new OrderItemBusiness();
            LoadGridOrderItems();
        }

        private async void ButtonSaveOrderItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Guid idTmp = new Guid();
                Guid.TryParse(txtOrderItemId.Text, out idTmp);

                var item = await _business.GetById(idTmp);

                if (item.Data == null)
                {
                    var orderItem = new OrderItem()
                    {
                        OrderItemId = Guid.NewGuid(),
                        OrderId = Guid.Parse(txtOrderId.Text),
                        ProductId = Guid.Parse(txtProductId.Text),
                        Quantity = int.Parse(txtQuantity.Text),
                        Price = decimal.Parse(txtPrice.Text)
                    };

                    var result = await _business.Save(orderItem);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var orderItem = item.Data as OrderItem;
                    orderItem.OrderId = Guid.Parse(txtOrderId.Text);
                    orderItem.ProductId = Guid.Parse(txtProductId.Text);
                    orderItem.Quantity = int.Parse(txtQuantity.Text);
                    orderItem.Price = decimal.Parse(txtPrice.Text);

                    var result = await _business.Update(orderItem);
                    MessageBox.Show(result.Message, "Update");
                }

                ClearOrderItemForm();
                LoadGridOrderItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void ButtonCancelOrderItem_Click(object sender, RoutedEventArgs e)
        {
            ClearOrderItemForm();
        }

        private async void grdOrderItem_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (grdOrderItem.SelectedItem != null)
            {
                var orderItem = grdOrderItem.SelectedItem as OrderItem;
                if (orderItem != null)
                {
                    var result = await _business.DeleteById(orderItem.OrderItemId);
                    MessageBox.Show(result.Message, "Delete");

                    ClearOrderItemForm();
                    LoadGridOrderItems();
                }
            }
        }

        private async void grdOrderItem_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (grdOrderItem.SelectedItem != null)
            {
                var orderItem = grdOrderItem.SelectedItem as OrderItem;
                txtOrderItemId.Text = orderItem.OrderItemId.ToString();
                txtOrderId.Text = orderItem.OrderId.ToString();
                txtProductId.Text = orderItem.ProductId.ToString();
                txtQuantity.Text = orderItem.Quantity.ToString();
                txtPrice.Text = orderItem.Price.ToString();
            }
        }

        private async void LoadGridOrderItems()
        {
            var result = await _business.GetAll();

            if (result.Status > 0 && result.Data != null)
            {
                grdOrderItem.ItemsSource = result.Data as List<OrderItem>;
            }
            else
            {
                grdOrderItem.ItemsSource = new List<OrderItem>();
            }
        }

        private void ClearOrderItemForm()
        {
            txtOrderItemId.Text = string.Empty;
            txtOrderId.Text = string.Empty;
            txtProductId.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }
    }
}
