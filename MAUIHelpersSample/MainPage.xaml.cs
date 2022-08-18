using MAUIHelpersSample.ViewModels;

namespace MAUIHelpersSample
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new MainViewModel();
        }

        
    }
}