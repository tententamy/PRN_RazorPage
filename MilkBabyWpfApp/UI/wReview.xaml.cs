using MilkBabyBusiness.Category;
using MilkBabyData.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MilkBabyWpfApp.UI
{
    public partial class wReview : Window
    {
        private readonly ReviewBusiness _business;
        private readonly ProductBusiness _productBusiness;
        private readonly CustomerBusiness _customerBusiness;
        public ObservableCollection<Review> Reviews { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }

        private Review _selectedReview;
        public wReview()
        {
            InitializeComponent();
            _business = new ReviewBusiness();
            _productBusiness = new ProductBusiness();
            _customerBusiness = new CustomerBusiness();
            Reviews = new ObservableCollection<Review>();
            Products = new ObservableCollection<Product>();
            Customers = new ObservableCollection<Customer>();
            DataContext = this;
            LoadGridReviews();
            LoadProducts();
            LoadCustomers();
        }

        private async void ButtonSaveReview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Guid reviewId;

                // Kiểm tra và tạo mới ReviewId nếu cần
                if (string.IsNullOrEmpty(txtReviewId.Text))
                {
                    reviewId = Guid.NewGuid(); // Tạo mới Guid cho ReviewId
                }
                else
                {
                    if (!Guid.TryParse(txtReviewId.Text, out reviewId))
                    {
                        MessageBox.Show("Invalid Review ID format.", "Error");
                        return;
                    }
                }

                var rating = int.Parse(txtRating.Text);
                if (rating < 1 || rating > 5)
                {
                    MessageBox.Show("Rating must be between 1 and 5.", "Validation Error");
                    return;
                }

                var helpfulCount = int.Parse(txtReviewHelpfulCount.Text);
                var notHelpfulCount = int.Parse(txtReviewNotHelpfulCount.Text);
                if (helpfulCount < 0 || notHelpfulCount < 0)
                {
                    MessageBox.Show("Helpful Count and Not Helpful Count must be non-negative.", "Validation Error");
                    return;
                }

                // Kiểm tra xem _selectedReview có tồn tại hay không
                if (_selectedReview != null)
                {
                    _selectedReview.ProductId = (Guid)cbProduct.SelectedValue;
                    _selectedReview.CustomerId = (Guid)cbCustomer.SelectedValue;
                    _selectedReview.Rating = rating;
                    _selectedReview.ReviewText = txtReviewText.Text;
                    _selectedReview.ReviewTitle = txtReviewTitle.Text;
                    _selectedReview.ReviewImg = txtReviewImage.Text;
                    _selectedReview.ReviewHelpfulCount = helpfulCount;
                    _selectedReview.ReviewNotHelpfulCount = notHelpfulCount;
                    _selectedReview.ReviewUpdatedDate = DateOnly.FromDateTime(DateTime.Now);

                    var result = await _business.Update(_selectedReview);
                    MessageBox.Show(result.Message, result.Status > 0 ? "Success" : "Error");

                    ClearReviewForm();
                    LoadGridReviews();

                    _selectedReview = null; // Xóa _selectedReview sau khi hoàn thành cập nhật
                }
                else
                {
                    // Nếu _selectedReview null, tạo mới đối tượng Review để lưu
                    var review = new Review()
                    {
                        ReviewId = reviewId,
                        ProductId = (Guid)cbProduct.SelectedValue,
                        CustomerId = (Guid)cbCustomer.SelectedValue,
                        Rating = rating,
                        ReviewText = txtReviewText.Text,
                        ReviewTitle = txtReviewTitle.Text,
                        ReviewImg = txtReviewImage.Text,
                        ReviewHelpfulCount = helpfulCount,
                        ReviewNotHelpfulCount = notHelpfulCount,
                        ReviewCreatedDate = DateOnly.FromDateTime(DateTime.Now),
                    };

                    var result = await _business.Save(review);
                    MessageBox.Show(result.Message, result.Status > 0 ? "Success" : "Error");

                    ClearReviewForm();
                    LoadGridReviews();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }
        private void ButtonCancelReview_Click(object sender, RoutedEventArgs e)
        {
            ClearReviewForm();
        }

        private async void ButtonDeleteReview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grdReview.SelectedItem is Review selectedReview)
                {
                    var result = await _business.DeleteById(selectedReview.ReviewId);
                    MessageBox.Show(result.Message, result.Status > 0 ? "Success" : "Error");

                    if (result.Status > 0)
                    {
                        ClearReviewForm();
                        await LoadGridReviews(); // Đảm bảo load lại danh sách sau khi xóa thành công
                    }
                }
                else
                {
                    MessageBox.Show("Please select a review to delete.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }





        private async void grdReview_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (grdReview.SelectedItem is Review review)
            {
                _selectedReview = review; // Lưu đối tượng Review được chọn vào biến _selectedReview

                // Hiển thị thông tin của đối tượng Review được chọn lên form chỉnh sửa
                txtReviewId.Text = review.ReviewId.ToString();
                cbProduct.SelectedValue = review.ProductId;
                cbCustomer.SelectedValue = review.CustomerId;
                txtRating.Text = review.Rating.ToString();
                txtReviewText.Text = review.ReviewText;
                txtReviewTitle.Text = review.ReviewTitle;
                txtReviewImage.Text = review.ReviewImg;
                txtReviewHelpfulCount.Text = review.ReviewHelpfulCount.ToString();
                txtReviewNotHelpfulCount.Text = review.ReviewNotHelpfulCount.ToString();
                dpReviewCreatedDate.SelectedDate = review.ReviewCreatedDate?.ToDateTime(new TimeOnly(0, 0));
                dpReviewUpdatedDate.SelectedDate = review.ReviewUpdatedDate?.ToDateTime(new TimeOnly(0, 0));
            }
        }

        private async Task LoadGridReviews()
        {
            try
            {
                var result = await _business.GetAll();

                if (result.Status > 0 && result.Data is List<Review> reviews)
                {
                    Reviews.Clear();
                    foreach (var review in reviews)
                    {
                        Reviews.Add(review);
                    }
                }
                else
                {
                    Reviews.Clear();
                    MessageBox.Show("Failed to load reviews. No data retrieved.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reviews: {ex.Message}", "Error");
            }
        }

        private async Task LoadProducts()
        {
            try
            {
                var result = await _productBusiness.GetAll();

                if (result.Status > 0 && result.Data is List<Product> products)
                {
                    Products.Clear();
                    foreach (var product in products)
                    {
                        Products.Add(product);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load products. No data retrieved.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error");
            }
        }

        private async Task LoadCustomers()
        {
            try
            {
                var result = await _customerBusiness.GetAll();

                if (result.Status > 0 && result.Data is List<Customer> customers)
                {
                    Customers.Clear();
                    foreach (var customer in customers)
                    {
                        Customers.Add(customer);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load customers. No data retrieved.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error");
            }
        }


        private void ClearReviewForm()
        {
            txtReviewId.Text = string.Empty;
            cbProduct.SelectedIndex = -1;
            cbCustomer.SelectedIndex = -1;
            txtRating.Text = string.Empty;
            txtReviewText.Text = string.Empty;
            txtReviewTitle.Text = string.Empty;
            txtReviewImage.Text = string.Empty;
            txtReviewHelpfulCount.Text = string.Empty;
            txtReviewNotHelpfulCount.Text = string.Empty;
            dpReviewCreatedDate.SelectedDate = null;
            dpReviewUpdatedDate.SelectedDate = null;
        }
    }
}
