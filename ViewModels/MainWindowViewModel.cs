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

        //this has a dependency on the ToDoListService

        public MainWindowViewModel()
        {
            var service = new ContactListService();
            ContactList = new ContactListViewModel(service.GetItems());
            _contentViewModel = ContactList;
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
                        ContactList.ListItems.Add(newItem);
                    }
                    ContentViewModel = ContactList;
                });

            ContentViewModel = addItemViewModel;
        }
    }
}