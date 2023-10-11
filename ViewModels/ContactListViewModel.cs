using System.Collections.Generic;
using System.Collections.ObjectModel;
using willardcrm.DataModel;

namespace willardcrm.ViewModels
{
    public class ContactListViewModel : ViewModelBase
    {
        public ContactListViewModel(IEnumerable<ToDoItem> items)
        {
            ListItems = new ObservableCollection<ToDoItem>(items);
        }

        public ObservableCollection<ToDoItem> ListItems { get; }
    }
}