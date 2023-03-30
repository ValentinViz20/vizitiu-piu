using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace vizitiu_piu.Agenda
{
    
    /// <summary>
    /// Represents a person in the agend
    /// </summary>
    class Person
    {
        /// <summary>
        /// Caracterul ce separa datele salvate in fisier
        /// </summary>
        readonly static char SEPARATOR_DATE = '$';

        /// <summary>
        /// The ID used for creating new objects. This should be incremeneted at each new call of the constructor.
        /// </summary>
        public static int currentId = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Prenume { get; set; }
        public string PhoneNumber { get; set; }
        public string Group { get; set; }
        public string Email { get; set; }
        public DateTime BithDate { get; set; }


        public Person(string name, string prenume, string phoneNumber, string group, string email, DateTime birthDate) {

            this.Id = currentId++;
            this.Name = name;  
            this.Prenume = prenume;  
            this.PhoneNumber = phoneNumber;
            this.Group = group;
            this.Email = email;
            this.BithDate = birthDate;
        }

        public Person(int Id, string name, string prenume, string phoneNumber, string group, string email, DateTime birthDate) {

            this.Id = Id;
            this.Name = name;  
            this.Prenume = prenume;  
            this.PhoneNumber = phoneNumber;
            this.Group = group;
            this.Email = email;
            this.BithDate = birthDate;
        }
         
        public Person(string stringSavedPerson)
        {
            string[] splits = stringSavedPerson.Split(SEPARATOR_DATE);

            this.Id = Int32.Parse(splits[0]);
            this.Name = splits[1];
            this.Prenume = splits[2];
            this.PhoneNumber = splits[3];
            this.Group = splits[4];
            this.Email = splits[5];
            this.BithDate = DateTime.ParseExact(splits[6], "dd/MM/yyyy", CultureInfo.InvariantCulture); 
        }

        public string ConvertPersonDateToString()
        {
            string stringData = $"{this.Id}{SEPARATOR_DATE}" +
                                $"{this.Name}{SEPARATOR_DATE}" +
                                $"{this.Prenume}{SEPARATOR_DATE}" +
                                $"{this.PhoneNumber}{SEPARATOR_DATE}" +
                                $"{this.Group}{SEPARATOR_DATE}" +
                                $"{this.Email}{SEPARATOR_DATE}" +
                                $"{this.BithDate.Day}/{this.BithDate.Month,2}/{this.BithDate.Year}\n";

            return stringData;
                                
        }

        public string GetPrettyPersonInfo() {
            return $"Nume: {this.Name}\n" +
                $"Prenume: {this.Prenume}\n" +
                $"Nr. Telefon: {this.PhoneNumber}\n" +
                $"Grup: {this.Group}\n" +
                $"Email: {this.Email}\n" +
                $"Birthday: {this.BithDate}\n";
        }
    }
}
