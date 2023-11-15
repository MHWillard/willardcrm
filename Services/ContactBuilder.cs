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
            contactItem._relationship = contactProps["relationship"];
            contactItem._interests = contactProps["interests"];
            contactItem._email = contactProps["email"];
            contactItem._phone = contactProps["phone"];
            contactItem._notes = contactProps["notes"];

            //                {"name", "Bill Grogs"},{"relationship", "Friend"},{"interests", "roleplaying games, history"},{"email", "bill@billgrognard.com"},{"phone", "555.782.9843"},{"notes", "Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic."}

            return contactItem;
        }
    }
}
