using Gemidapp.Helpers;
using Gemidapp.Models;
using Gemidapp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Gemidapp.ViewModels
{
    public class SelectContactViewModel : BaseViewModel
    {

        public ObservableRangeCollection<Contact> Contacts { get; set; }

        public Command LoadItemsCommand { get; set; }

        private IContactService contactService;

        public SelectContactViewModel()
        {
            Title = "Select a Contact";
            Contacts = new ObservableRangeCollection<Contact>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            contactService = DependencyService.Get<IContactService>();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy) return;

            IsBusy = true;

            try
            {
                Contacts.Clear();
                Contacts.AddRange(contactService.GetContacts());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert()
                {
                    Title = "Error",
                    Message = "Unable to load contacts.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
