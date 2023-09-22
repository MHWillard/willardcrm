using ReactiveUI;
using willardcrm.Services;

namespace willardcrm.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ViewModelBase _contentViewModel;

        //this has a dependency on the ToDoListService

        public MainWindowViewModel()
        {
            var service = new ContactService();
            ToDoList = new ContactViewModel(service.GetItems());
            _contentViewModel = ToDoList;
        }

        public ContactViewModel ToDoList { get; }

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