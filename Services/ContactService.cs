using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using willardcrm.DataModel;

namespace willardcrm.Services
{
    public class ContactService
    {
        public IEnumerable<ContactItem> GetItems() => new[]
        {
            new ContactItem { Name = "Friend One" },
            new ContactItem { Name = "Friend Two" },
            new ContactItem { Name = "Enemy One", IsChecked = true },
        };
    }
}
