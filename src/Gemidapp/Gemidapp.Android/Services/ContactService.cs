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
            #region previous
            //List<Contact> result;
            //ContentResolver cr = context.ContentResolver;
            ////using (ICursor cur = cr.Query(ContactsContract.Contacts.ContentUri, null, null, null, null))
            ////{
            ////ICursor cur = cr.Query(Contacts.People.ContentUri, null, null, null, null);
            //ICursor cur = cr.Query(ContactsContract.Contacts.ContentUri, null, null, null, null);
            //result = new List<Contact>(cur.Count);
            //if (cur.Count > 0)
            //{
            //    while (cur.MoveToNext())
            //    {
            //        String id = cur.GetString(cur.GetColumnIndex(ContactsContract.Contacts.Entity.InterfaceConsts.Id));
            //        String name = cur.GetString(cur.GetColumnIndex(ContactsContract.Contacts.Entity.InterfaceConsts.DisplayName));
            //        //int number = cur.GetInt(cur.GetColumnIndex(Contacts.People.InterfaceConsts.));
            //        if (cur.GetInt(cur.GetColumnIndex(Contacts.People.InterfaceConsts.Number)) > 0)
            //        {
            //            using (ICursor pCur = cr.Query(ContactsContract.CommonDataKinds.Phone.ContentUri, null, ContactsContract.CommonDataKinds.Phone.InterfaceConsts.ContactId + " = ?", new String[] { id }, null))
            //            {
            //                while (pCur.MoveToNext())
            //                {
            //                    String phoneNo = pCur.GetString(pCur.GetColumnIndex(ContactsContract.CommonDataKinds.Phone.Number));

            //                    result.Add(new Contact
            //                    {
            //                        Name = name,
            //                        Number = phoneNo
            //                    });
            //                }
            //            }
            //        }
            //    }
            //}
            ////}
            //cur.Close();
            //return result; 
            #endregion


            using (var loader = new CursorLoader(context, ContactsContract.Contacts.ContentUri, null, $"{ContactsContract.Contacts.InterfaceConsts.HasPhoneNumber} > 0", null, ContactsContract.Contacts.Entity.InterfaceConsts.DisplayName))
            using (var cursor = (ICursor)loader.LoadInBackground())
            {
                List<Contact> result = new List<Contact>(cursor.Count);
                if (cursor.MoveToFirst())
                {
                    do
                    {
                        using (var phoneLoader = new CursorLoader(context,
                                            ContactsContract.CommonDataKinds.Phone.ContentUri,
                                            null,
                                            $"{ContactsContract.CommonDataKinds.Phone.InterfaceConsts.ContactId} = ?",
                                            new string[] { cursor.GetString(cursor.GetColumnIndex(ContactsContract.Contacts.Entity.InterfaceConsts.Id)) },
                                            null))
                        using (var phoneCursor = (ICursor)phoneLoader.LoadInBackground())
                            if (phoneCursor != null && phoneCursor.MoveToFirst())
                                result.Add(new Contact
                                {
                                    Name = cursor.GetString(cursor.GetColumnIndex(ContactsContract.Contacts.Entity.InterfaceConsts.DisplayName)),
                                    Number = phoneCursor.GetString(phoneCursor.GetColumnIndex(ContactsContract.CommonDataKinds.Phone.NormalizedNumber)),
                                });
                    } while (cursor.MoveToNext());
                }

                return result;
            }
        }

        public Task<IReadOnlyList<Contact>> GetContactsAsync()
        {
            throw new NotImplementedException();
        }
    }
}