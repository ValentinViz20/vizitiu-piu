using System;
using System.Collections.Generic;
using System.IO;

namespace vizitiu_piu.Agenda
{
    /// <summary>
    /// Main class for controling the Agend.
    /// This works with an termianl text based interface
    /// </summary>
    internal class ConsoleAgend
    {
        /// <summary>
        /// The List that holds all the people in the adgend."
        /// </summary>
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
        /// <param name="personId">The ID of the person</param>
        /// <param name="newPerson">The Person object to add to the Contacts</param>
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

        /// <summary>
        /// Loads all the Contacts from the specified file
        /// </summary>
        /// <param name="fileName">The name of the file to load contacts from</param>
        /// <returns> The number of people loaded from the file</returns>
        public int LoadPeopleFromFile(string fileName)
        {
            int nrPersoaneAdaugate = 0;

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string linieFisier;
                
                /* citeste cate o linie si creaza un obiect de tip Person
                pe baza datelor din linia citita */

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    if (linieFisier.Length == 0) continue;

                    this.peopleInAgend.Add(new Person(linieFisier));
                    nrPersoaneAdaugate++;
                }
            }

            return nrPersoaneAdaugate;
        }

        /// <summary>
        /// Saves all the current contacts to the specified file
        /// </summary>
        /// <param name="fileName"> The name of the file to save the contacts to</param>
        public void SavePeopleToFile(string fileName) {

            foreach (Person person in peopleInAgend)
            {
                using (StreamWriter streamWriterFisierText = new StreamWriter(fileName, false))
                {
                    streamWriterFisierText.WriteLine(person.ConvertPersonDateToString());
                }
            }
            
        }

        /// <summary>
        /// Searches a person in the agend by their full name.
        /// </summary>
        /// <param name="name"> The first name of the person </param>
        /// <param name="prenume"> The last name of the person </param>
        /// <returns> The person that found, or null otherwise </returns>
        public Person SearchPersonByName(string name, string prenume)
        {
            foreach (Person person in peopleInAgend)
            {
                if (person.Name  == name && person.Prenume == prenume)
                {
                    return person;
                }
            }
            return null;
        }

        /// <summary>
        /// Searches a person in the agend by their email.
        /// </summary>
        /// <param name="email"> The email of the person </param>
        /// <returns> The person that found, or null otherwise </returns>
        public Person SearchPersonByEmail(string email)
        {
            foreach (Person person in peopleInAgend)
            {
                if (person.Email  == email)
                    return person;
            }
            return null;
        }

        /// <summary>
        /// Searches a person in the agend by their phone number.
        /// </summary>
        /// <param name="phoneNumber"> The phone number of the person </param>
        /// <returns> The person that found, or null otherwise </returns>
        public Person SearchPersonByPhoneNumber(string phoneNumber)
        {
            foreach (Person person in peopleInAgend)
            {
                if (person.PhoneNumber  == phoneNumber)
                    return person;
            }
            return null;
        }

    }
}
