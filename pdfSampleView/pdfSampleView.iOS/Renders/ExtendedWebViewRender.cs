using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Foundation;
using pdfSampleView.Controls;
using pdfSampleView.iOS.Renders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedWebView), typeof(ExtendedWebViewRender))]
namespace pdfSampleView.iOS.Renders
{
    /// <summary>
    /// Extended web view render.
    /// </summary>
    public class ExtendedWebViewRender : ViewRenderer<ExtendedWebView, UIWebView>
    {
        ExtendedWebView webViewPdf;
        protected override void OnElementChanged(ElementChangedEventArgs<ExtendedWebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var fr = Frame;

                SetNativeControl(new UIWebView(new CoreGraphics.CGRect(0, 0, 375, 600)));
            }
            if (e.OldElement != null)
            {
                // Cleanup
            }
            if (e.NewElement != null)
            {
                var customWebView = Element as ExtendedWebView;
                webViewPdf = customWebView;
                webViewPdf.LoadUrl += LoadErrorHnadler;
                webViewPdf.PropertyChangedLoadUrl += loadUrlAction;

                if (!string.IsNullOrEmpty(customWebView.Uri))
                {
                    loadUrl(webViewPdf);
                }
            }
            else
                Console.WriteLine(("uri not found"));
        }

        private void LoadErrorHnadler(object sender, EventArgs e)
        {
            loadUrl(webViewPdf);
        }

        private void loadUrlAction()
        {
            loadUrl(webViewPdf);
        }

        private async Task<string> loadFile(string urlPdf)
        {
            try
            {
                var fileName = string.Format("{0}{1}", Guid.NewGuid(), ".pdf");

                var FieDownbloaded = await DownloadFile(urlPdf, fileName);

                if (FieDownbloaded)
                {
                    webViewPdf.Uri = fileName;
                    loadUrl(webViewPdf);
                }

            }
            catch (Exception ex)
            {

            }

            return string.Empty;
        }

        public async Task<bool> DownloadFile(string uri, string filename)
        {
            try
            {
                var webClient = new WebClient();

                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string localFilename = filename;
                string localPath = Path.Combine(documentsPath, localFilename);


                await Task.Run(delegate
                {
                    webClient.DownloadFile(uri, localPath);
                });


                if (File.Exists(localPath))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private async void loadUrl(ExtendedWebView customWebView)
        {
            Console.WriteLine("loading url pdfff");

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string localFilename = customWebView.Uri;
            string localPath = Path.Combine(documentsPath, localFilename);

            if (File.Exists(localPath))
            {
                Control.LoadError += LoadError;
                Control.LoadRequest(new NSUrlRequest(new NSUrl(localPath, false)));
                Control.ScalesPageToFit = true;
                Control.LoadFinished += loadFinish;
            }
            else
            {
                await loadFile(customWebView.Uri);
            }
        }

        private void loadFinish(object sender, EventArgs e)
        {
            webViewPdf.LoadUrlComplete();
        }

        private void LoadError(object sender, UIWebErrorArgs e)
        {
            Console.WriteLine(("LoadError"));
        }

    }
}
