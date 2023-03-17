using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace vizitiu_piu.Agenda
{
    /// <summary>
    /// Represents a person in the agend
    /// </summary>
    internal class Person
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int phoneNumber { get; set; }
        public string group { get; set; }
        public string email { get; set; }
        public DateTime bithDate { get; set; }

        public Person(string name, int phoneNumber, string group, string email, DateTime birthDate) { 
            
            this.name = name;  
            this.phoneNumber = phoneNumber;
            this.group = group;
            this.email = email;
            this.bithDate = birthDate;
        }

    }
}
