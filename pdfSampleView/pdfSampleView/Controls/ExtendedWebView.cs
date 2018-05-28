using System;
using Xamarin.Forms;

namespace pdfSampleView.Controls
{
    public class ExtendedWebView : WebView
    {
        public static readonly BindableProperty UriProperty = BindableProperty.Create(propertyName: "Uri",
                returnType: typeof(string),
                declaringType: typeof(ExtendedWebView),
                defaultValue: default(string));

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }

        public static readonly BindableProperty IsPdfProperty = BindableProperty.Create(propertyName: "IsPdf",
        returnType: typeof(bool),
        declaringType: typeof(ExtendedWebView),
        defaultValue: default(bool));

        public bool IsPdf
        {
            get { return (bool)GetValue(IsPdfProperty); }
            set { SetValue(IsPdfProperty, value); }
        }
        
        public Action PropertyChangedLoadUrl;
        public event EventHandler LoadUrl;
        
        
         public void LoadUrlComplete()
         {
            LoadUrl?.Invoke(this,null);
         }
        
    }
}
