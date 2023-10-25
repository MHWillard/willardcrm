using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using willardcrm.DataModel;
using FluentAssertions.Formatting;

namespace willardcrm.Services
{
    public class ContactHandler
    {
        public string GetContactPath() {
            string baseDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName;
            string contactPath = Path.Combine(baseDirectory, "Contacts");
            return contactPath;
        }
        public string GetContactJSON(string contactName)
        {
            string output = "";
            string contactPath = this.GetContactPath();
            string JSONFilename = contactName + ".json";
            string fullPath = Path.Combine(contactPath, JSONFilename);
            if (File.Exists(fullPath)) {
                output = File.ReadAllText(fullPath);
            }

            //need to make sure to return an error or do a handler in case this is blank
            
            return output;
        }

        public ContactItem GetContactItem(string contactName)
        {
            string output = this.GetContactJSON(contactName);
            ContactItem contactItem = JsonConvert.DeserializeObject<ContactItem>(output);
            return contactItem;
        }

        public ContactItem[] GetAllContactItems() {
            ContactItem[] contactArray = new ContactItem[3];
            return contactArray;
        }

        public void saveContact(ContactItem contact)
        {
            string output = JsonConvert.SerializeObject(contact);
            string contactPath = this.GetContactPath();
            string JSONfilename = contact._name + ".json";
            string fullPath = Path.Combine(contactPath, JSONfilename);
            File.WriteAllText(fullPath, output);
        }
    }
}
