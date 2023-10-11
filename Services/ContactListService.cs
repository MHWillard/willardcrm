using System.Collections.Generic;
using willardcrm.DataModel;

namespace willardcrm.Services
{
    public class ContactListService
    {
        public IEnumerable<ToDoItem> GetItems() => new[]
        {
            new ToDoItem { Name = "Friend 1" },
            new ToDoItem { Name = "Friend 2" },
            new ToDoItem { Name = "Enemy 1", IsChecked = true },
        };
    }
}