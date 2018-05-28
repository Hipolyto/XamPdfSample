using System;
using pdfSampleView.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pdfSampleView.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage(string Url, string PageTitle)
        {
            InitializeComponent();
            BindingContext = new AboutViewModel(Url, PageTitle);
        }
    }
}