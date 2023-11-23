using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using willardcrm.DataModel;

namespace willardcrm.Services
{
    public class ContactBuilder
    {
        public ContactItem BuildContact(Dictionary<string, string> contactProps) { 
            ContactItem contactItem = new ContactItem();
            contactItem.Name = contactProps["name"];
            contactItem.Relationship = contactProps["relationship"];
            contactItem.Interests = contactProps["interests"];
            contactItem.Email = contactProps["email"];
            contactItem.Phone = contactProps["phone"];
            contactItem.Notes = contactProps["notes"];

            //                {"name", "Bill Grogs"},{"relationship", "Friend"},{"interests", "roleplaying games, history"},{"email", "bill@billgrognard.com"},{"phone", "555.782.9843"},{"notes", "Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic."}

            return contactItem;
        }
    }
}
