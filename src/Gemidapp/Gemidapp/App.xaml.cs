using Gemidapp.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Gemidapp
{
	public partial class App : Application
	{
        public App()
		{
			InitializeComponent();

			SetMainPage();
		}

		public static void SetMainPage()
		{
            //Current.MainPage = new SendGemidaoPage();
            Current.MainPage = new MasterDetailPage()
            {
                Master = new Drawer(),
                Detail = new SendGemidaoPage()
            };
        }
	}
}
