using System;
using NUnit.Framework;

namespace SomePractices1
{

    // Person class
    public class Person
    {
        public Person(string v1, string v2, DateTime dateTime)
        {
            FirstName = v1;
            LastName = v2;
            BirthDate = dateTime;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public int Age => (int)((DateTime.Now - BirthDate).TotalDays / 365.25);


    }


    public class Practices
    {
        [Test]
        public void ThatAgeMatches()
        {
            var sut = new Person("George", "Something", new DateTime(1926, 6, 18));

            var age = sut.Age;

            Assert.That(age, Is.EqualTo(93), "Got that wrong");

        }

    }
}
