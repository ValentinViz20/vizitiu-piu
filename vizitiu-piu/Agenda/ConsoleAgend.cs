using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vizitiu_piu.Agenda
{
    /// <summary>
    /// Main class for controling the Agend.
    /// This works with an termianl text based interface
    /// </summary>
    internal class ConsoleAgend
    {
        private List<Person> peopleInAgend = new List<Person>();

        /// <summary>
        /// Adds a person to the agend.
        /// </summary>
        /// <param name="person"> The person to add </param>
        public void AddPersonToAgend(Person person) { 
            
            peopleInAgend.Add(person); 
        }

        /// <summary>
        /// Removes a given person from the agend. 
        /// </summary>
        /// <param name="person"> The person to remove </param>
        /// <returns> <see langword="true"/> if the person was removes sucessfully </returns>
        public bool RemovePersonFromAgend(Person person)
        {
            return peopleInAgend.Remove(person);
        }

        /// <summary>
        /// Updates a person from the agend if it exists.
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="newPerson"></param>
        /// <returns> 
        /// <see langword="true"/> if the person was updated sucessfully
        /// <see langword="false"/> if the person doesn't exist in the agend </returns>
        public bool UpdatePersonInAgend(int personId,  Person newPerson) {

            for (int i = 0; i < peopleInAgend.Count; i++)
            {
                if (peopleInAgend[i].Id == personId)
                {
                    peopleInAgend[i] = newPerson;
                    return true;
                }
            }
                return false;
        }

        public Person SearchPersonByName(string name)
        {
            foreach (Person person in peopleInAgend)
            {
                if (person.name  == name)
                    return person;
            }
            return null;
        }

        public Person SearchPersonByEmail(string email)
        {
            foreach (Person person in peopleInAgend)
            {
                if (person.email  == email)
                    return person;
            }
            return null;
        }

        public Person SearchPersonByPhoneNumber(int phoneNumber)
        {
            foreach (Person person in peopleInAgend)
            {
                if (person.phoneNumber  == phoneNumber)
                    return person;
            }
            return null;
        }

    }
}
