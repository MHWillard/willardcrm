using System.Collections.Generic;
using willardcrm.DataModel;

namespace willardcrm.Services
{
    public class ContactListService
    {
        public IEnumerable<ContactItem> GetItems() => new[]
        {
            new ContactItem { Name = "Friend 1" },
            new ContactItem { Name = "Friend 2" },
            new ContactItem { Name = "Enemy 1", IsChecked = true },
        };
    }
}