using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;

using vizitiu_piu.Agenda;

/* TO DO LIST:
 * Identificați clasa (clasele) necesare modelării entităților din cadrul temei alese și implementați-le ✅
 * Folosiți un software de versionare a fișierelor ✅
 * citirea datelor de la tastatura; ✅
 * salvarea datelor în fișier text; ✅
 * preluarea datelor dintr-un fișier text; ✅
 * căutarea după anumite criterii. ✅
 * Implementați facilitățile specificate in laboratorul anterior pentru o a doua entitate ✅
 * Modificați clasele astfel încât să se folosească proprietăți auto-implemented de „get” si „set”. ✅
 * Completați clasele proiectate cu două câmpuri care să fie de tip enum. ✅
 */

namespace vizitiu_piu
{

    internal class Program
    {
        /// <summary>
        /// The name of the file where the data for Contacts is stored.
        /// </summary>
        static readonly string NUME_FISIER = ConfigurationManager.AppSettings["file_name"];

        /// <summary>
        /// The valid options the user can pick from in the main menu
        /// </summary>
        static readonly List<int> VALID_MENU_OPTIONS = new List<int>() { 1, 2, 3, 4, 5, 6, 15};

        static void Main(string[] args)
        {
            bool exitProgram = false;
            bool convertedSucessfuly;

            ConsoleAgend agenda = new ConsoleAgend();


            // Run the program until the user chooses to exit
            while (true)
            {
                if (exitProgram) break;

                Console.Write(
                @"Alegeti o optinue:
1. Adaugare contact nou de la tastatura\n
2. Incarcare contacte din fisier\n
3. Salvare contacte in fisier\n
4. Cautare persoana dupa nume si prenume
5. Cautare persoana dupa email
6. Afiseaza toate persoanele din agenda
15. Exit program
>>> "
                );

                // Read user's option
                convertedSucessfuly = int.TryParse(Console.ReadLine(), out int option);

                // Check if the user's option is valid
                if (!convertedSucessfuly || !VALID_MENU_OPTIONS.Contains(option))
                {
                    Console.WriteLine("Invalid option, please input the number in front of the options above.");
                    continue;
                }


                Person foundPerson;
                Person newPerson;
                string name;
                string prenume;
                string phoneNumber;
                Person.ContactGroup group;
                string email;
                DateTime birthDate;

                // Handle the option picked by the user
                switch (option)
                {
                    // Adds a new user in the agend
                    case 1:
                        Console.Write("Adding new contact:\nFirst Name: ");
                        name = Console.ReadLine();

                        Console.Write("Last Name: ");
                        prenume = Console.ReadLine();

                        Console.Write("Phone number: ");
                        phoneNumber = Console.ReadLine();

                        Console.Write("Group: ");
                        Enum.TryParse(Console.ReadLine(), out group);

                        Console.Write("Email: ");
                        email = Console.ReadLine();

                        Console.Write("Birthday (dd/MM/yyyy): ");

                        if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                        {
                            Console.WriteLine("Invalid date format. Please enter the birthdate in the format dd/MM/yyyy");
                            continue;
                        }

                        newPerson = new Person(Person.currentId++, name, prenume, phoneNumber, group, email, birthDate);

                        agenda.AddPersonToAgend(newPerson);

                        Console.WriteLine($"Contactul: {name} {prenume} a fost adaugat.\n\n");
                        break;

                    // Load all the contacts from a file
                    case 2:
                        int nrPersoanseAdaugate = agenda.LoadPeopleFromFile(NUME_FISIER);

                        Person.currentId += nrPersoanseAdaugate;

                        Console.WriteLine($"{nrPersoanseAdaugate} contacte au fost incarcate din fisier.");

                        break;

                    // Saves the current contacts to the file
                    case 3:
                        agenda.SavePeopleToFile(NUME_FISIER);

                        Console.WriteLine("Contactele au fost salvate in fiser.");
                        break;

                    // Searched a person by name 
                    case 4:
                        Console.Write("Cautare contact dupa nume:\nFirst Name: ");
                        name = Console.ReadLine();
                        Console.Write("Last Name: ");
                        prenume = Console.ReadLine();

                        foundPerson = agenda.SearchPersonByName(name, prenume);

                        if (foundPerson == null)
                        {
                            Console.WriteLine($"\nThe person with the name \"{name} {prenume}\" was not found.");
                            break;
                        }

                        Console.WriteLine($"\nThe person was found: \n{foundPerson.GetPrettyPersonInfo()}");
                        break;
    
                    // Search person by email
                    case 5:

                        Console.Write("Please give the email to search by: ");
                        email = Console.ReadLine();

                        foundPerson = agenda.SearchPersonByEmail(email);

                        if (foundPerson == null)
                        {
                            Console.WriteLine($"\nThe person with the email \"{email}\" was not found.");
                            break;
                        }

                        Console.WriteLine($"\nThe person was found: \n{foundPerson.GetPrettyPersonInfo()}");
                        break;

                    case 6:
                        agenda.PrintAllContacts();
                        break;
                    case 15:

                        exitProgram = true;
                        break;
                }
            }

            // We can get here only when the user picks the option to exit
            Console.WriteLine("Thank you fro using the Constole Agend App!\nPress any key to close to exit.");
            Console.ReadKey();
        }
    }
}
