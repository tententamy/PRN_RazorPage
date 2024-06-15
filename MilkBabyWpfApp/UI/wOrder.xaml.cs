using MilkBabyBusiness.Category;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MilkBabyWpfApp.UI
{
    public partial class wOrder : Window
    {
        private readonly OrderBusiness _business;

        public wOrder()
        {
            InitializeComponent();
            _business = new OrderBusiness();
            LoadGridOrders();
        }

        private async void ButtonSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Guid idTmp = new Guid();
                Guid.TryParse(txtOrderID.Text, out idTmp);

                var item = await _business.GetById(idTmp);

                if (item.Data == null)
                {
                    var order = new Order()
                    {
                        OrderId = Guid.NewGuid(),
                        CustomerId = Guid.Parse(txtOrderCustomerId.Text),
                        OrderDate = dpOrderDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpOrderDate.SelectedDate.Value) : DateOnly.FromDateTime(DateTime.Now),
                        TotalAmount = decimal.Parse(txtTotalAmount.Text),
                        Voucher = txtVoucher.Text,
                        OrderStatus = txtOrderStatus.Text,
                        OrderShippingAddress = txtOrderShippingAddress.Text,
                        OrderBillingAddress = txtOrderBillingAddress.Text,
                        OrderPaymentMethod = txtOrderPaymentMethod.Text,
                        OrderShippingMethod = txtOrderShippingMethod.Text,
                        OrderTrackingNumber = txtOrderTrackingNumber.Text,
                        OrderCreatedDate = DateOnly.FromDateTime(DateTime.Now),
                        OrderUpdatedDate = DateOnly.FromDateTime(DateTime.Now)
                    };

                    var result = await _business.Save(order);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var order = item.Data as Order;
                    order.CustomerId = Guid.Parse(txtOrderCustomerId.Text);
                    order.OrderDate = dpOrderDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpOrderDate.SelectedDate.Value) : DateOnly.FromDateTime(DateTime.Now);
                    order.TotalAmount = decimal.Parse(txtTotalAmount.Text);
                    order.Voucher = txtVoucher.Text;
                    order.OrderStatus = txtOrderStatus.Text;
                    order.OrderShippingAddress = txtOrderShippingAddress.Text;
                    order.OrderBillingAddress = txtOrderBillingAddress.Text;
                    order.OrderPaymentMethod = txtOrderPaymentMethod.Text;
                    order.OrderShippingMethod = txtOrderShippingMethod.Text;
                    order.OrderTrackingNumber = txtOrderTrackingNumber.Text;
                    order.OrderUpdatedDate = DateOnly.FromDateTime(DateTime.Now);

                    var result = await _business.Update(order);
                    MessageBox.Show(result.Message, "Update");
                }

                ClearOrderForm();
                LoadGridOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void ButtonCancelOrder_Click(object sender, RoutedEventArgs e)
        {
            ClearOrderForm();
        }

        private async void grdOrder_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (grdOrder.SelectedItem != null)
            {
                var order = grdOrder.SelectedItem as Order;
                if (order != null)
                {
                    var result = await _business.DeleteById(order.OrderId);
                    MessageBox.Show(result.Message, "Delete");

                    ClearOrderForm();
                    LoadGridOrders();
                }
            }
        }

        private async void grdOrder_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (grdOrder.SelectedItem != null)
            {
                var order = grdOrder.SelectedItem as Order;
                txtOrderID.Text = order.OrderId.ToString();
                txtOrderCustomerId.Text = order.CustomerId.ToString();
                dpOrderDate.SelectedDate = order.OrderDate?.ToDateTime(TimeOnly.MinValue);
                txtTotalAmount.Text = order.TotalAmount.ToString();
                txtVoucher.Text = order.Voucher;
                txtOrderStatus.Text = order.OrderStatus;
                txtOrderShippingAddress.Text = order.OrderShippingAddress;
                txtOrderBillingAddress.Text = order.OrderBillingAddress;
                txtOrderPaymentMethod.Text = order.OrderPaymentMethod;
                txtOrderShippingMethod.Text = order.OrderShippingMethod;
                txtOrderTrackingNumber.Text = order.OrderTrackingNumber;
            }
        }

        private async void LoadGridOrders()
        {
            var result = await _business.GetAll();

            if (result.Status > 0 && result.Data != null)
            {
                grdOrder.ItemsSource = result.Data as List<Order>;
            }
            else
            {
                grdOrder.ItemsSource = new List<Order>();
            }
        }

        private void ClearOrderForm()
        {
            txtOrderID.Text = string.Empty;
            txtOrderCustomerId.Text = string.Empty;
            dpOrderDate.SelectedDate = null;
            txtTotalAmount.Text = string.Empty;
            txtVoucher.Text = string.Empty;
            txtOrderStatus.Text = string.Empty;
            txtOrderShippingAddress.Text = string.Empty;
            txtOrderBillingAddress.Text = string.Empty;
            txtOrderPaymentMethod.Text = string.Empty;
            txtOrderShippingMethod.Text = string.Empty;
            txtOrderTrackingNumber.Text = string.Empty;
        }
    }
}
