using System;

namespace DataProvider
{
    public class Person
    {
        public Person(Guid personId, string firstName, string lastName, int age)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public Guid PersonId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
    }
}
