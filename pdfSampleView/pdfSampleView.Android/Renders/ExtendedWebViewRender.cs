using System;
using Android.Content;
using Android.Views;
using Android.Webkit;
using pdfSampleView.Controls;
using pdfSampleView.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedWebView), typeof(ExtendedWebViewRender))]
namespace pdfSampleView.Droid.Renders
{
    /// <summary>
    /// Extended web view render.
    /// </summary>
    public class ExtendedWebViewRender : WebViewRenderer
    {
        private ExtendedWebView _customWebView;
        private WebViewClientDelegate _webDelegate;
        public ExtendedWebViewRender(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                _customWebView = Element as ExtendedWebView;
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                
                _webDelegate = new  WebViewClientDelegate(_customWebView);
                
                if (!_customWebView.IsPdf)
                    Control.LoadUrl(_customWebView.Uri);
                else
                    Control.LoadUrl("https://drive.google.com/viewerng/viewer?embedded=true&url=" + _customWebView.Uri);
                    
                Control.SetWebViewClient(_webDelegate);
            }
        }

        private class WebViewClientDelegate : WebViewClient
        {
            private ExtendedWebView _customWebView;

            public WebViewClientDelegate(ExtendedWebView customWebView)
            {
                _customWebView = customWebView;
            }

            public override void OnPageStarted(Android.Webkit.WebView view, string url, Android.Graphics.Bitmap favicon)
            {
                base.OnPageStarted(view, url, favicon);
            }

            public override void OnPageFinished(Android.Webkit.WebView view, string url)
            {
               base.OnPageFinished(view, url);
                 _customWebView.LoadUrlComplete();
            }

            public override void OnReceivedError(Android.Webkit.WebView view, ClientError errorCode, string description, string failingUrl)
            {
                base.OnReceivedError(view, errorCode, description, failingUrl);
            }
        }
    }
}
