using MilkBabyWpfApp.UI;
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

namespace MilkBabyWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Open_wCustomer_Click(object sender, RoutedEventArgs e)
        {
            var p = new wCustomer();
            p.Owner = this;
            p.Show();
        }

        private void Open_wReview_Click(object sender, RoutedEventArgs e)
        {
            var p = new wReview();
            p.Owner = this;
            p.Show();
        }

        private void Open_wOrder_Click(object sender, RoutedEventArgs e)
        {
            var p = new wOrder();
            p.Owner = this;
            p.Show();
        }

        private void Open_wOrderItem_Click(object sender, RoutedEventArgs e)
        {
            var p = new wOrderItem();
            p.Owner = this;
            p.Show();
        }

        private void Open_wProduct_Click(object sender, RoutedEventArgs e)
        {
            var p = new wProduct();
            p.Owner = this;
            p.Show();
        }

        private void Open_wVendor_Click(object sender, RoutedEventArgs e)
        {
            var p = new wVendor();
            p.Owner = this;
            p.Show();
        }
    }
}
