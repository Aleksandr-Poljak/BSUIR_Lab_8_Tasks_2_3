using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR_Lab_8_Tasks_2_3
{
    public class User : BasePerson
    {
        public string Name { get ; set; }
        public string Surname { get; set; }
        private int age;
        public int Age {
            get => age;
            set
            {
                if (value >= 0 && value <= 110) age = value;
                else throw new ArgumentOutOfRangeException("Возраст должен быть от 0 о 110 лет");
            }
        }
        private char? gender;
        public char? Gender
        {
            get => gender;
            set
            {
                if (value == 'M' || value == 'F' || value is null) gender = value;
                else throw new ArgumentOutOfRangeException("Пол может быть  M или F.");
            }
        }
        public User() 
        {
            Name = "Unknown";
            Surname = "Unknown";
            Age = 0;
            Gender = null;
        }
        public User(string name, string surname , int age, char gender) : this() 
        { 
            this.Name = name;
            this.Surname = surname;
            this .Age = age;
            this.Gender = gender;
        }

        public override string ToString()
        {
            return $"Name: {Name}. Surname: {Surname}. Age: {Age}. Gender: {Gender}";
        }

    }
}
