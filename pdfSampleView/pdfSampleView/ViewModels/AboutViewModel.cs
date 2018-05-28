using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace pdfSampleView.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private string _Uri;
        private string _Title;

        public AboutViewModel(string UrlPdf,string Pagetitle)
        {
            Uri = UrlPdf;
            Title = Pagetitle;
        }

        public string Uri
        {
            get
            {
                return _Uri;
            }
            set
            {
                if (_Uri != value)
                {
                    _Uri = value;
                    OnPropertyChanged(nameof(Uri));
                }
            }
        }
        
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }
    }
}