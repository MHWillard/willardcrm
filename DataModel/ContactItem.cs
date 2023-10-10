using System;

namespace willardcrm.DataModel
{
    public class ContactItem
    {
        public string Name { get; set; } = String.Empty;
        public bool IsChecked { get; set; }

        public string GetJSON()
        {
            return "{\"name\": \"Joe Schmo\",\"relationship\": \"friend\",\"interests\": \"football, hockey\",\"updates:\" [{\"id\": 1,\"date\": \"10-09-2023\",\"comment\": \"met Joe\"},{\"id\": 2,\"date\": \"10-10-2023\",\"comment\": \"helped Joe move\"},]}";
        }
    }
}