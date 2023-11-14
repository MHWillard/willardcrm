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

            OkCommand = ReactiveCommand.Create(() => new ContactItem { _name = Name, _relationship = Relationship, _email = Email, _phone = Phone, _interests = Interests, _notes = Notes }, isValidObservable);
            CancelCommand = ReactiveCommand.Create(() => { });
        }

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public string Relationship
        {
            get => _relationship;
            set => this.RaiseAndSetIfChanged(ref _relationship, value);
        }

        public string Email
        {
            get => _email;
            set => this.RaiseAndSetIfChanged(ref _email, value);
        }

        public string Phone
        {
            get => _phone;
            set => this.RaiseAndSetIfChanged(ref _phone, value);
        }

        public string Interests
        {
            get => _interests;
            set => this.RaiseAndSetIfChanged(ref _interests, value);
        }

        public string Notes
        {
            get => _notes;
            set => this.RaiseAndSetIfChanged(ref _notes, value);
        }
    }
}