using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gemidapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Drawer : ContentPage
	{
        public ObservableCollection<string> Items { get; set; }

        public MasterDetailPage MasterDetailPage => App.Current.MainPage as MasterDetailPage;

        public Drawer ()
		{
			InitializeComponent ();

            Items = new ObservableCollection<string>
            {
                "Enviar Gemidão",
                "Configurar Token",
            };

            BindingContext = this;
        }

        object lastSelectedItem = null;
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            if (lastSelectedItem == e.Item) return;

            if (e.Item is String name)
            {
                switch (name)
                {
                    case "Enviar Gemidão":
                        this.MasterDetailPage.Detail = new SendGemidaoPage();
                        break;
                    default:
                        this.MasterDetailPage.Detail = new TokenPage();
                        break;
                }
            }
        }
    }
}