using System.Collections.Generic;
using FluentAssertions;
using MyClasses.PersonClasses;
using Xunit;

namespace MyClassesTest
{
    public class CollectionAssertClassTest
    {
        [Fact]
        public void CollectionsAreEqual()
        {
            PersonManager permgr = new PersonManager();

            List<Person> peopleExpected = new List<Person>()
            {
                new Person() { FirstName = "Matheus", LastName = "Vieira" },
                new Person() { FirstName = "Isabella", LastName = "Vieira" },
                new Person() { FirstName = "Ivani", LastName = "Vieira" }
            };

            List<Person> peopleActual = permgr.GetPeople();

            //Podemos fazer essa validação como uma sobrecarga do CollectionAsset.AreEqual, o ponto é que vale a ordem
            for (int i = 0; i < peopleExpected.Count; i++)
            {
                Assert.Equal(peopleExpected[i].FirstName, peopleActual[i].FirstName);
                Assert.Equal(peopleExpected[i].LastName, peopleActual[i].LastName);
            }
        }
        
        [Fact]
        public void CollectionsAreEquivalent()
        {
            PersonManager permgr = new PersonManager();

            List<Person> peopleExpected = new List<Person>()
            {
                new Person() { FirstName = "Matheus", LastName = "Vieira" },
                new Person() { FirstName = "Ivani", LastName = "Vieira" },
                new Person() { FirstName = "Isabella", LastName = "Vieira" }
            };
            
            //Podemos fazer essa validação com CollectionAsset.AreEquivalent, o ponto é que não vale a ordem
            List<Person> peopleActual = permgr.GetPeople();
            peopleExpected.Should().BeEquivalentTo(peopleActual);
        }
        
        [Fact]
        public void CollectionsAreNotEquivalent()
        {
            PersonManager permgr = new PersonManager();

            List<Person> peopleExpected = new List<Person>()
            {
                new Person() { FirstName = "Matheus", LastName = "Vieira" },
                new Person() { FirstName = "Ivani", LastName = "Vieira" }
            };

            List<Person> peopleActual = permgr.GetPeople();
            peopleExpected.Should().NotBeEquivalentTo(peopleActual);
        }
        
        [Fact]
        public void CollectionShouldHaveAllItensAsInstanceOfSupervisor()
        {
            PersonManager permgr = new PersonManager();

            List<Person> list = permgr.GetSupervisors();
            
            list.Should().AllBeOfType<Supervisor>();
        }
    }
}