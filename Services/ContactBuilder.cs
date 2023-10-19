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
        public ContactItem BuildContact(List<string> contactProps) { 
            ContactItem contactItem = new ContactItem();
            contactItem._name = "Bill Grogs";
            contactItem._relationship = "Friend";
            contactItem._interests = "roleplaying games, history";
            contactItem._email = "bill@billgrognard.com";
            contactItem._phone = "555.782.9843";
            contactItem._notes = "Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic.";

            return contactItem;
        }
    }
}
