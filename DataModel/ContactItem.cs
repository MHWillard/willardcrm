using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace willardcrm.DataModel
{
    public class ContactItem
    {
        public string _name { get; set; } = String.Empty;
        public string _relationship { get; set; } = String.Empty;
        public string _interests { get; set; } = String.Empty;
        public string _updates { get; set; } = String.Empty; //this has to be a list

        public string GetJSON()
        {
            return "{\"name\": \"Joe Schmo\",\"relationship\": \"friend\",\"interests\": \"football, hockey\",\"updates:\" [{\"id\": 1,\"date\": \"10-09-2023\",\"comment\": \"met Joe\"},{\"id\": 2,\"date\": \"10-10-2023\",\"comment\": \"helped Joe move\"},]}";
        }
    }
}
