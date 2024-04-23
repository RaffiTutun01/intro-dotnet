using DataProvider;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
            DeleteCommand = new ActionCommand(Delete);
            ResetForm = new ActionCommand(Reset);
            SelectPerson(null);
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
        public ICommand DeleteCommand { get; set; }
        public ICommand ResetForm { get; set; }
        public PersonViewModel? CurrentPerson
        {
            get => _currentPerson; set
            {
                _currentPerson = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPerson)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void SelectPerson(Person? person)
        {
            if (person == null)
            {
                CurrentPerson = new PersonViewModel
                {
                    Id = Guid.NewGuid(),
                    Age = 0
                };
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
            if (CurrentPerson == null)
            {
                Console.WriteLine("Cannot be null");
            } else
            {
                bool exist = _personRepository.GetAll().Any(person => person.PersonId == CurrentPerson.Id);
                if (exist)
                {
                    _personRepository.Update(CurrentPerson.Id, CurrentPerson.FirstName, CurrentPerson.LastName, CurrentPerson.Age);
                } else
                {
                    Person person = _personRepository.Create(CurrentPerson.FirstName, CurrentPerson.LastName, CurrentPerson.Age);
                    SelectPerson(person);
                }
            }
            LoadPeople();
        }

        public void Delete()
        {
            if (CurrentPerson == null)
                Console.WriteLine("Cannot be null");
            else
                _personRepository.Delete(CurrentPerson.Id);
            LoadPeople();
            SelectPerson(null);
        }
        public void Reset()
        {
            if (CurrentPerson == null)
                Console.WriteLine("Cannot be null");
            else
                CurrentPerson = null;
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
