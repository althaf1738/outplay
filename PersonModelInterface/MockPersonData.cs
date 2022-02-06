using Firstapi.PersonModels;
using System.Collections.Generic;

namespace Firstapi.PersonModelInterface;


    public class MockPersonData : IPerson
    {

        private readonly PersonContext _personContext;
        public MockPersonData(PersonContext personContext)
        {
            _personContext = personContext;
        }
        public Person AddPerson(Person person)
        {
            
            _personContext.Persons.Add(person);
            _personContext.SaveChanges();
            return person;
        }

        public void DeletePerson(Person person)
        {
             
            _personContext.Persons.Remove(person);
            _personContext.SaveChanges();
            
        }

        public Person EditPerson(Person person)
        {
            var existingPerson =  _personContext.Persons.Find(person.Id);
            if(existingPerson !=null)
            {
                existingPerson.Name= person.Name;
                existingPerson.Age= person.Age;
                existingPerson.Dob = person.Dob;
                existingPerson.IsAdult = person.IsAdult;

                _personContext.Persons.Update(existingPerson);
                _personContext.SaveChanges();
            }
           return person;
        }

        public Person GetPerson(int id)
        {
            var person =  _personContext.Persons.Find(id);
            return person;
        }

        public List<Person> GetPersons()
        {
            return _personContext.Persons.ToList();
        }

        public List<Person> GreaterAge(int age)
        {
            return _personContext.Persons.Where( x => x.Age > age).ToList();
            
        }

        public List<Person> IsAdult(bool status)
        {
            return _personContext.Persons.Where( x => x.IsAdult== status).ToList();
            
        }

      
    }
