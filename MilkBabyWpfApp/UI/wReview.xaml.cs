using MilkBabyBusiness.Category;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MilkBabyWpfApp.UI
{
    public partial class wReview : Window
    {
        private readonly ReviewBusiness _business;

        public wReview()
        {
            InitializeComponent();
            _business = new ReviewBusiness();
            LoadGridReviews();
        }

        private async void ButtonSaveReview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Guid idTmp = new Guid();
                Guid.TryParse(txtReviewId.Text, out idTmp);

                var item = await _business.GetById(idTmp);

                if (item.Data == null)
                {
                    var review = new Review()
                    {
                        ReviewId = Guid.NewGuid(),
                        ProductId = Guid.Parse(txtProductId.Text),
                        CustomerId = Guid.Parse(txtCustomerId.Text),
                        Rating = int.Parse(txtRating.Text),
                        ReviewText = txtReviewText.Text,
                        ReviewDate = dpReviewDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpReviewDate.SelectedDate.Value) : DateOnly.FromDateTime(DateTime.Now),
                        ReviewImg = txtReviewImg.Text
                    };

                    var result = await _business.Save(review);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var review = item.Data as Review;
                    review.ProductId = Guid.Parse(txtProductId.Text);
                    review.CustomerId = Guid.Parse(txtCustomerId.Text);
                    review.Rating = int.Parse(txtRating.Text);
                    review.ReviewText = txtReviewText.Text;
                    review.ReviewDate = dpReviewDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpReviewDate.SelectedDate.Value) : DateOnly.FromDateTime(DateTime.Now);
                    review.ReviewImg = txtReviewImg.Text;

                    var result = await _business.Update(review);
                    MessageBox.Show(result.Message, "Update");
                }

                ClearReviewForm();
                LoadGridReviews();
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

        private async void grdReview_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (grdReview.SelectedItem != null)
            {
                var review = grdReview.SelectedItem as Review;
                if (review != null)
                {
                    var result = await _business.DeleteById(review.ReviewId);
                    MessageBox.Show(result.Message, "Delete");

                    ClearReviewForm();
                    LoadGridReviews();
                }
            }
        }

        private async void grdReview_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (grdReview.SelectedItem != null)
            {
                var review = grdReview.SelectedItem as Review;
                txtReviewId.Text = review.ReviewId.ToString();
                txtProductId.Text = review.ProductId.ToString();
                txtCustomerId.Text = review.CustomerId.ToString();
                txtRating.Text = review.Rating.ToString();
                txtReviewText.Text = review.ReviewText;
                dpReviewDate.SelectedDate = review.ReviewDate?.ToDateTime(new TimeOnly(0, 0));
                txtReviewImg.Text = review.ReviewImg;
            }
        }

        private async void LoadGridReviews()
        {
            var result = await _business.GetAll();

            if (result.Status > 0 && result.Data != null)
            {
                grdReview.ItemsSource = result.Data as List<Review>;
            }
            else
            {
                grdReview.ItemsSource = new List<Review>();
            }
        }

        private void ClearReviewForm()
        {
            txtReviewId.Text = string.Empty;
            txtProductId.Text = string.Empty;
            txtCustomerId.Text = string.Empty;
            txtRating.Text = string.Empty;
            txtReviewText.Text = string.Empty;
            dpReviewDate.SelectedDate = null;
            txtReviewImg.Text = string.Empty;
        }
    }
}
