using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gemidapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendGemidaoPage : ContentPage
    {
        ViewModels.SendGemidaoViewModel vm;
        public SendGemidaoPage()
        {
            InitializeComponent();

            this.BindingContext = vm = new ViewModels.SendGemidaoViewModel();
        }

        private async void FromLoadButton_Clicked(object sender, EventArgs e)
        {
            vm.From = (await GetContactAsked()).Replace("+55", "");
        }

        private async void ToLoadButton_Clicked(object sender, EventArgs e)
        {
            vm.To = (await GetContactAsked()).Replace("+55", "");
        }

        private async Task<string> GetContactAsked()
        {
            SelectContactPage contactPage = new SelectContactPage();
            await this.Navigation.PushAsync(contactPage);
            return contactPage.SelectedContact.Number;
        }
    }
}