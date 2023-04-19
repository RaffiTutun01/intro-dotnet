using DataProvider;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfApp1
{
    public class MainWindowsModel : INotifyPropertyChanged
    {
        private readonly IPersonRepository _personRepository;
        private PersonViewModel? _currentPerson;
        private ObservableCollection<Person> _people;

        public MainWindowsModel(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            LoadPeople();
            SelectPersonCommand = new ActionCommand(person => SelectPerson((Person)person));
            SaveCommand = new ActionCommand(Save);
        }

        private void LoadPeople()
        {
            People = new ObservableCollection<Person>(_personRepository.GetAll());

        }

        public ObservableCollection<Person> People
        {
            get => _people;
            set
            {
                _people = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(People)));
            }
        }
        public ICommand SelectPersonCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public PersonViewModel? CurrentPerson
        {
            get => _currentPerson; set
            {
                _currentPerson = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPerson)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void SelectPerson(Person person)
        {
            if (person == null)
            {
                CurrentPerson = null;
                return;
            }
            CurrentPerson = new PersonViewModel
            {
                Id = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age
            };
        }
        public void Save()
        {
            _personRepository.Update(CurrentPerson.Id, CurrentPerson.FirstName, CurrentPerson.LastName, CurrentPerson.Age);
            LoadPeople();
        }
    }
    public class PersonViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
