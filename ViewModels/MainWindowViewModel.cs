using ReactiveUI;
using System;
using System.Reactive.Linq;
using willardcrm.DataModel;
using willardcrm.Services;

namespace willardcrm.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;
        private ContactListService _service;
        private ContactListViewModel _ContactList;

        //this has a dependency on the ToDoListService

        public MainWindowViewModel()
        {
            _service = new ContactListService();
            _ContactList = new ContactListViewModel(_service.GetItems());
            _contentViewModel = _ContactList;
        }

        public ContactListViewModel ContactList { get; }

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public void AddItem()
        {
            AddItemViewModel addItemViewModel = new();

            Observable.Merge(
                addItemViewModel.OkCommand,
                addItemViewModel.CancelCommand.Select(_ => (ContactItem?)null))
                .Take(1)
                .Subscribe(newItem =>
                { 
                    if (newItem != null)
                    {
                        //ContactList.ListItems.Add(newItem);
                        _service.SaveItem(newItem);
                        var updatedList = _service.GetItems();
                        _ContactList.ListItems = updatedList;

                    }
                    ContentViewModel = _ContactList;
                });

            ContentViewModel = addItemViewModel;
        }

        public void DeleteItem(ContactItem contact) 
        {
            //take in selectedItem
            //use _service: find and destroy it
            //re-render list
            _service.DeleteItem(contact);
        }
    }
}