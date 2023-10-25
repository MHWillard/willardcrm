using System.Collections.Generic;
using willardcrm.DataModel;

namespace willardcrm.Services
{
    public class ContactListService
    {
        public IEnumerable<ContactItem> GetItems() => new[]
        {
            //gets data from ContactHandler to load
            new ContactItem { }, new ContactItem { }, new ContactItem { },
        };
    }
}