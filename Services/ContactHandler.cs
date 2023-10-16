﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using willardcrm.DataModel;

namespace willardcrm.Services
{
    public class ContactHandler
    {
        public string GetContactJSON(string contactName)
        {
            //return "{\"name\": \"Bill Grogs\",\"relationship\": \"Friend\",\"interests\": \"roleplaying games, history\",\"email:\"bill@billgrognard.com\",\"number\":\"555.782.9843\",\"notes\":\"Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic.\",\"updates:\" []}";
            //open JSON file
            //string output = JsonConvert.SerializeObject(dummyJSON);
            string output = File.ReadAllText("../../../../Contacts/testContact.json");
            return output;
        }

        public void saveContact(ContactItem contact)
        {
            string output = JsonConvert.SerializeObject(contact);
            string absolute = Directory.GetParent(Directory.GetCurrentDirectory()).FullName; //get home directory
            File.WriteAllText(absolute + "/Contacts/testContact.json", output);
            //take this particular contact info and write it to a JSON object or string object
            //get each property
            //convert into .json
            //dump it into a directory contacts folder to read
        }
    }
}