using Firstapi.PersonModels;

namespace Firstapi.PersonModelInterface{

     public interface IPerson{
        List<Person> GetPersons();

        Person GetPerson(int id);

        Person AddPerson(Person person);

        void DeletePerson(Person person);

        Person  EditPerson(Person person);

        List<Person> IsAdult(bool isAdult);

        List<Person> GreaterAge(int age);
    }
}