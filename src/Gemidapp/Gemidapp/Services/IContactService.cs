using Gemidapp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gemidapp.Services
{
    public interface IContactService
    {
        IReadOnlyList<Contact> GetContacts();

        Task<IReadOnlyList<Contact>> GetContactsAsync();
    }
}
