using ReactiveUI;
using System;
using System.Diagnostics;
using System.Numerics;
using System.Reactive;
using System.Reactive.Linq;
using System.Xml.Linq;
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

        public ReactiveCommand<ContactItem, Unit> DeleteCommand { get; }

        public MainWindowViewModel()
        {
            _service = new ContactListService();
            _ContactList = new ContactListViewModel(_service.GetItems());
            _contentViewModel = _ContactList;
            DeleteCommand = ReactiveCommand.Create<ContactItem>(DeleteItem);
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
                        _service.SaveItem(newItem);
                        _ContactList.ListItems.Add(newItem);

                    }
                    ContentViewModel = _ContactList;
                });

            ContentViewModel = addItemViewModel;
        }

        public void DeleteItem(ContactItem contact) 
        {
            if (contact != null) {
                _service.DeleteItem(contact);
                _ContactList.ListItems.Remove(contact);
            }
            ContentViewModel = _ContactList;
        }
    }
}