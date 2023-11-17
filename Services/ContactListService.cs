using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
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

        public IEnumerable<ContactItem> GetItems() 
        {
            //gets data from ContactHandler to load
            //new ContactItem { }, new ContactItem { }, new ContactItem { },
            IEnumerable<ContactItem> ListItems = contactHandler.GetAllContactItems();
            return ListItems;
        }
    }
}