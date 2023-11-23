using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using willardcrm.DataModel;

namespace willardcrm.ViewModels
{
    public class ContactDetailsViewModel : ReactiveObject
    {
        ContactItem receivedItem;

        public ContactItem ReceivedItem
        {
            get => receivedItem;
            set => this.RaiseAndSetIfChanged(ref receivedItem, value);
        }
    }
}
