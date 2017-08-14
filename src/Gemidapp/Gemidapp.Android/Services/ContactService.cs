using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Gemidapp.Services;
using Android.Provider;
using Android.Database;
using System.Threading.Tasks;
using Xamarin.Forms;
using Gemidapp.Models;

[assembly: Dependency(typeof(Gemidapp.Droid.Services.ContactService))]
namespace Gemidapp.Droid.Services
{

    public class ContactService : IContactService
    {
        static Context context;
        public static void SetContext(Context applicationContext)
        {
            context = applicationContext;
        }

        public IReadOnlyList<Contact> GetContacts()
        {
            var phoneContacts = new List<Contact>();
            using (var loader = new CursorLoader(context, ContactsContract.CommonDataKinds.Phone.ContentUri, null, null, null, null))
            using (var phones = (ICursor)loader.LoadInBackground())
            {
                if (phones != null)
                {
                    while (phones.MoveToNext())
                    {
                        try
                        {
                            phoneContacts.Add(new Contact
                            {
                                Name = phones.GetString(phones.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.DisplayName)),
                                Number = phones.GetString(phones.GetColumnIndex(ContactsContract.CommonDataKinds.Phone.Number)),
                            });
                        }
                        catch (Exception ex)
                        {
                            //something wrong with one contact, may be display name is completely empty, decide what to do
                        }
                    }
                    //phones.Close(); //not really neccessary, we have "using" above
                }
                else
                {
                    throw new Exception("Phone cursor is null at lowlevel");
                }
            }

            return phoneContacts;
        }

        //public Task<IReadOnlyList<Contact>> GetContactsAsync()
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<IReadOnlyList<Contact>> GetContactsAsync()
        {
            throw new NotImplementedException();
        }


        public class PersonContact
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
        }
    }
}