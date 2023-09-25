using ReactiveUI;
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
            ToDoList = new ContactListViewModel(service.GetItems());
            _contentViewModel = ToDoList;
        }

        public ContactListViewModel ToDoList { get; }

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public void AddItem()
        {
            ContentViewModel = new AddItemViewModel();
        }
    }
}