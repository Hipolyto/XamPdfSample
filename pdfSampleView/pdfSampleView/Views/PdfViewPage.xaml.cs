using System;
using System.Collections.Generic;
using pdfSampleView.ViewModels;
using Xamarin.Forms;

namespace pdfSampleView.Views
{
    public partial class PdfViewPage : ContentPage
    {
        public PdfViewPage(string Url, string PageTitle)
        {
            InitializeComponent();
            BindingContext = new AboutViewModel(Url, PageTitle);

            pdfControl.LoadUrl += LoadUrlHandler;
        }

        private void LoadUrlHandler(object sender, EventArgs e)
        {
            loadingBox.IsVisible = false;
        }
    }
}
