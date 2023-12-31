﻿using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using willardcrm.DataModel;

namespace willardcrm.ViewModels
{
    public class ContactListViewModel : ViewModelBase
    {
        ContactItem selectedItem;
        ContactDetailsViewModel detailsViewModel;

        public ContactListViewModel()
        {
            this.detailsViewModel = new ContactDetailsViewModel();
        }

        public ContactListViewModel(IEnumerable<ContactItem> items)
        {
            ListItems = new ObservableCollection<ContactItem>(items);
        }

        public ObservableCollection<ContactItem> ListItems { get; set; }

        public ContactItem SelectedItem
        {
            get => selectedItem;
            set 
            { 
                this.RaiseAndSetIfChanged(ref selectedItem, value);
                detailsViewModel.ReceivedItem = value;
            }
        }
    }
}