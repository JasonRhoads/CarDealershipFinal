using System;
using System.Windows.Forms;
using CarBusiness;

namespace CarDealershipFinal
{
    public partial class frmListingDetails : Form
    {
        private Listing selectedListing;
        private CommentService commentService = new CommentService();

        public frmListingDetails(Listing listing)
        {
            InitializeComponent();
            selectedListing = listing;
        }

        private void frmListingDetails_Load(object sender, EventArgs e)
        {
            ShowListingDetails();
            LoadComments();
        }

        private void ShowListingDetails()
        {
            rchDetails.Text = selectedListing.Car.GetDisplayText();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadComments()
        {
            rchComments.Clear();

            var comments = commentService.GetComments(selectedListing.Car.CarID);

            foreach (var c in comments)
            {
                rchComments.AppendText(
                     $"{c.Username} • {c.DatePosted:g}\n" +
                     $"{c.CommentText}\n" +
                     $"------------------------------\n");
            }
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            if (!frmCarListings.userLoggedIn)
            {
                MessageBox.Show("You must be logged in to comment.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtComment.Text))
            {
                MessageBox.Show("Enter a comment.");
                return;
            }

            commentService.AddComment(
                selectedListing.Car.CarID,
                frmCarListings.currentUsername,
                txtComment.Text);

            txtComment.Clear();
            LoadComments();
        }
    }
}