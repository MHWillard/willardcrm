using System.Collections.Generic;
using System.Collections.ObjectModel;
using willardcrm.DataModel;

namespace willardcrm.ViewModels
{
    public class ContactListViewModel : ViewModelBase
    {
        public ContactListViewModel(IEnumerable<ContactItem> items)
        {
            ListItems = new ObservableCollection<ContactItem>(items);
        }

        public ObservableCollection<ContactItem> ListItems { get; }
    }
}