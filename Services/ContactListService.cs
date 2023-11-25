using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using willardcrm.DataModel;

namespace willardcrm.Services
{
    public class ContactListService
    {
        private ContactHandler contactHandler = new ContactHandler(); //later inject this dependency

        public void SaveItem(ContactItem contactItem)
        {
            contactHandler.saveContact(contactItem);
        }

        public ObservableCollection<ContactItem> GetItems() 
        {
            //gets data from ContactHandler to load
            //IEnumerable<ContactItem>
            ObservableCollection<ContactItem> ListItems = contactHandler.GetAllContactItems();
            return ListItems;
        }

        public void DeleteItem(ContactItem contact)
        {
            contactHandler.deleteContact(contact);
        }
    }
}