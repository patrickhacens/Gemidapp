using Gemidapp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gemidapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TokenPage : ContentPage
    {
        TokenViewModel vm;
        public TokenPage()
        {
            InitializeComponent();
            this.BindingContext = vm = new TokenViewModel();
        }
    }
}