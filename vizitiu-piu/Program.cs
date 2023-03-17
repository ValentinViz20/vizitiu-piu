using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using vizitiu_piu.Agenda;

namespace vizitiu_piu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleAgend agenda = new ConsoleAgend();

            DateTime person1BirthDate = DateTime.ParseExact("14/02/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Person person1 = new Person("Valentin", 0733351698, "friends", "test@gmail.com", person1BirthDate);

            DateTime person2BirthDate = DateTime.ParseExact("16/06/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Person person2 = new Person("Raul", 0712421412, "friends", "test1@gmail.com", person1BirthDate);

            agenda.AddPersonToAgend(person1);  
            agenda.AddPersonToAgend(person2);

            Person foundPeson = agenda.SearchPersonByName("Valentin");

            Console.Write($"Name of the person found: {foundPeson.name}");
            
            Console.ReadKey();
        }
    }
}
