using System;
using System.Collections.Generic;

namespace MyClasses.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null;
            
            if (!String.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    ret = new Supervisor();
                }
                else
                {
                    ret = new Employee();
                }

                ret.FirstName = first;
                ret.LastName = last;
            }

            return ret;
        }

        public List<Person> GetPeople()
        {
           return  new List<Person>()
           {
               new Person() { FirstName = "Matheus", LastName = "Vieira" },
               new Person() { FirstName = "Isabella", LastName = "Vieira" },
               new Person() { FirstName = "Ivani", LastName = "Vieira" }
           };
        }
        
        public List<Person> GetSupervisors()
        {
            return  new List<Person>()
            {
                CreatePerson("Matheus", "Vieira", true),
                CreatePerson("Isabella", "Vieira", true),
                CreatePerson("Ivani", "Vieira", true)
            };
        }
    }
}