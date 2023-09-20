using ReactiveUI;
using willardcrm.Services;

namespace willardcrm.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;

        public MainWindowViewModel() {
            var service = new ContactService();
            ContactList = new ContactViewModel(service.GetItems());
            _contentViewModel = ContactList;
        }

        public ContactViewModel ContactList { get;}

        public ViewModelBase ContentViewModel {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public void AddItem()
        {
            ContentViewModel = new AddItemViewModel();
        }
    }
}