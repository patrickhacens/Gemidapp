using Gemidapp.Helpers;
using Gemidapp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gemidapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectContactPage : ContentPage, INotifyPropertyChanged
    {
        private ViewModels.SelectContactViewModel vm;

        private Contact _selectedContact;
        public Contact SelectedContact { get
            { return _selectedContact; } set
            {
                if(_selectedContact != value)
                    _selectedContact = value;
                this.OnPropertyChanged();
            }
        }

        

        public SelectContactPage()
        {
            InitializeComponent();

            BindingContext = vm = new ViewModels.SelectContactViewModel();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Contact contact)
            {
                this.SelectedContact = contact;
                await this.Navigation.PopAsync();
            }
            //if (e.SelectedItem == null)
            //    return;

            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            ////Deselect Item
            //((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (vm.Contacts.Count == 0)
                vm.LoadItemsCommand.Execute(null);
        }
    }
}