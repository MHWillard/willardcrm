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
using System.Collections.ObjectModel;
using System.Configuration;

namespace willardcrm.Services
{
    public class ContactHandler
    {

        //these all need to be try/catches to safely return if nulls/empty stuff comes up
        public string GetContactPath() {
            /*
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //string baseDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName;
            //string contactPath = Path.Combine(baseDirectory, "Contacts");
            //string appMainDirectory = AppContext.BaseDirectory;
            string contactsFolderPath = ConfigurationManager.AppSettings["ContactsFolderPath"];
            string contactPath = Path.Combine(baseDirectory, "Contacts");
            */

            //string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string baseDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("baseDirectory: " + baseDirectory);
            string contactPath = Path.Combine(baseDirectory, "Contacts");
            Console.WriteLine("contactPath: " + contactPath);

            if (!Directory.Exists(contactPath))
            {
                Directory.CreateDirectory(contactPath);
            }

            return contactPath;
            //manage this with a configuration setting for what's running, debug or build
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

        public ContactItem GetContactItemByName(string contactName)
        {
            string output = this.GetContactJSON(contactName);
            ContactItem contactItem = JsonConvert.DeserializeObject<ContactItem>(output);
            return contactItem;
        }

        public ContactItem GetContactItemByFile(string file)
        {
            string output = File.ReadAllText(file);
            ContactItem contactItem = JsonConvert.DeserializeObject<ContactItem>(output);
            return contactItem;
        }

        public ObservableCollection<ContactItem> GetAllContactItems() {
            //read contacts folder: get each item and load into it
            //return empty list anyway initialized to 0
            string contactPath = this.GetContactPath();
            //arm empty DS
            //for each file: load into DS
            //otherwise, return empty DS or put an empty item in it?
            string[] contactFiles = Directory.GetFiles(contactPath);
            //how can I get this to make/find the Contacts folder each time in the release directory?
            //write test for build and debug config to hit the right path
            //or see if we can grab a current directory, make a contacts folder if it doesn't already exist, then read that
            ObservableCollection<ContactItem> contactItems = new ObservableCollection<ContactItem>();

            foreach (string file in contactFiles)
            {
                ContactItem contactItem = this.GetContactItemByFile(file);
                contactItems.Add(contactItem);
            }
            return contactItems;
        }

        public void saveContact(ContactItem contact)
        {
            string output = JsonConvert.SerializeObject(contact);
            string contactPath = this.GetContactPath();
            string JSONfilename = contact.Name + ".json";
            string fullPath = Path.Combine(contactPath, JSONfilename);
            File.WriteAllText(fullPath, output);
        }

        public bool CheckIfContactExists(string contactName)
        {
            string output = this.GetContactJSON(contactName);
            if (output == "")
            {
                return false;
            }
            return true;
        }

        public void deleteContact(ContactItem contact)
        {
            string contactName = contact.Name;
            if (this.CheckIfContactExists(contactName))
            {
                string contactPath = this.GetContactPath();
                string JSONFilename = contactName + ".json";
                string fullPath = Path.Combine(contactPath, JSONFilename);
                File.Delete(fullPath);
            }
        }
    }
}
