using System;
using ReactiveUI;
using System.Reactive;
using willardcrm.DataModel;

namespace willardcrm.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        private string _name = string.Empty;
        private string _relationship = string.Empty;
        private string _email = string.Empty;
        private string _phone = string.Empty;
        private string _interests = string.Empty;
        private string _notes = string.Empty;

        public ReactiveCommand<Unit, ContactItem> OkCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public AddItemViewModel()
        {
            var isValidObservable = this.WhenAnyValue(x => x._name, x => !string.IsNullOrWhiteSpace(x));

            OkCommand = ReactiveCommand.Create(() => new ContactItem { _name = Name }, isValidObservable);
            CancelCommand = ReactiveCommand.Create(() => { });
        }

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
    }
}