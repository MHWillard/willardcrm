using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace willardcrm.DataModel
{
    public class ContactItem
    {
        public string Name { get; set; } = String.Empty;
        public string Relationship { get; set; } = String.Empty;
        public string Interests { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public string Notes { get; set; } = String.Empty;
        //public List<ContactUpdate> _updates { get; set; } = new List<ContactUpdate>(); //this has to be a list
        //some properties should default to empty, but a Name is required

        public string GetJSON()
        {
            return "{\"name\": \"Joe Schmo\",\"relationship\": \"friend\",\"interests\": \"football, hockey\",\"updates:\" [{\"id\": 1,\"date\": \"10-09-2023\",\"comment\": \"met Joe\"},{\"id\": 2,\"date\": \"10-10-2023\",\"comment\": \"helped Joe move\"},]}";
        }

    }
}
