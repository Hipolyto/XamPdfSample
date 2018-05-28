using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pdfSampleView.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : CarouselPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            
            if(Device.RuntimePlatform == Device.iOS)
            {
                //iOS stuff
                Children.Add(new PdfViewPage("http://www.pdf995.com/samples/pdf","Page 1 of 3"));
                Children.Add(new PdfViewPage("http://www.princexml.com/samples/invoice/invoicesample.pdf","Page 2 of 3"));
                Children.Add(new PdfViewPage("http://unec.edu.az/application/uploads/2014/12/pdf-sample.pdf","Page 3 of 3"));
            }
            else if(Device.RuntimePlatform == Device.Android)
            {
                Children.Add(new AboutPage("http://www.pdf995.com/samples/pdf","Page 1 of 3"));
                Children.Add(new AboutPage("http://www.princexml.com/samples/invoice/invoicesample.pdf","Page 2 of 3"));
                Children.Add(new AboutPage("http://unec.edu.az/application/uploads/2014/12/pdf-sample.pdf","Page 3 of 3"));
            }
            
            CurrentPageChanged  += PagesChangedHandle;
            
            Title = Children[0].Title;
        }
        
        private void PagesChangedHandle(object sender, EventArgs e)
        {
            Title = CurrentPage.Title;
        }
    }
}