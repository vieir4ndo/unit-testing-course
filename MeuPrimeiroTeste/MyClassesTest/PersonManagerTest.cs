using System;
using MyClasses.PersonClasses;
using Xunit;

namespace MyClassesTest
{
    public class PersonManagerTest
    {
        [Fact]
        public void IsInstanceOfSupervisor()
        {
            PersonManager mgr = new PersonManager();
            Person per;
            per = mgr.CreatePerson("Matheus", "Santos", true);
            
            Assert.IsType<Supervisor>(per);
        }
        
        [Fact]
        public void IsInstanceOfEmployee()
        {
            PersonManager mgr = new PersonManager();
            Person per;
            per = mgr.CreatePerson("Matheus", "Santos", false);
            
            Assert.IsType<Employee>(per);
        }
        
        [Fact]
        public void DoesNotCreatePerson()
        {
            PersonManager mgr = new PersonManager();
            Person per;
            per = mgr.CreatePerson(String.Empty, "Santos", false);
            
            Assert.Null(per);
        }
    }
}