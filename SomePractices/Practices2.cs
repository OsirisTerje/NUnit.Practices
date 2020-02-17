using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using NUnit.Framework;

namespace SomePractices2
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }

    public class DateTimeWrapper : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }

    public class Person
    {

        IDateTime DateHandling { get; }

        public Person(string v1, string v2, DateTime dateTime,IDateTime dateHandling=null)
        {
            FirstName = v1;
            LastName = v2;
            BirthDate = dateTime;
            DateHandling = dateHandling?? new DateTimeWrapper();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public int Age => (int)((DateHandling.Now - BirthDate).TotalDays / 365.25);


    }


    public class Practices
    {
        [Test]
        public void ThatAgeMatches()
        {
            var dNow = Substitute.For<IDateTime>();
            dNow.Now.Returns(new DateTime(2010, 1, 1));
            var sut = new Person("George", "Something", new DateTime(1926, 6, 18),dNow);

            var age = sut.Age;

            Assert.That(age, Is.EqualTo(83), "Got that wrong");

        }

        [Test]
        public void ThatAgeMatches2([Values( 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)] int month)
        {
            var sut = new Person("George", "Something", new DateTime(1926, month, 18));

            var age = sut.Age;

            Assert.That(age, Is.EqualTo(93), "Got that wrong");
        }

    }
}
