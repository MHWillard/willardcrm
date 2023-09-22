using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using willardcrm.DataModel;

namespace willardcrm.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        public ContactViewModel(IEnumerable<ContactItem> items)
        {
            ListItems = new ObservableCollection<ContactItem>(items);
        }

        public ObservableCollection<ContactItem> ListItems { get; }
    }
}
