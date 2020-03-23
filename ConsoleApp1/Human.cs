using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp12
{
    public class Human
    {
        //Variables
        int age;
        string gender;
        string first_name;
        string sur_name;

        //Properties
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0 && value < 100)
                {
                    this.age = value;
                }
				else
				{
					throw new Exception("Out of range");
				}
            }
        }
        public string Gender
        {
            get
			{
				return gender;
			}
            set
			{
				if(value == "Male" || value == "Female")
				{
					gender = value;
				}
				else
				{
					throw new Exception("Wrong Gender");
				}
			}
        }
        public string First_Name
        {
            get
			{
				return first_name;
			}
            set
			{
				if (Regex.Match(value, "[^A-Za-z]").Length == 0)
					{
						first_name = value;
					}
				else
				{
					throw new Exception("Incorrect symbol");
				}
			}
        }
        public string Sur_Name
        {
            get
			{
				return sur_name;
			}
            set
			{
				if ((Regex.Match(value, "[^A-Za-z]").Length == 0))
				{
					sur_name = value;
				}
				else
				{
					throw new Exception("Incorrect symbol");
				}
			}
        }

        //Constructors

        public Human(int age, string first_name, string sur_name, string gender)
        {
            Age = age;
            First_Name = first_name;
            Sur_Name = sur_name;
            Gender = gender;
            Console.WriteLine("HConstructor:\t" + this.GetHashCode());
        }
        ~Human()
        {
            Console.WriteLine("HDestructor:\t" + this.GetHashCode());
        }

        //Methods
        public override string ToString()
        {
            return $"Возраст: {Age}\nФамилия: {Sur_Name}\nИмя: {First_Name}\nПол: {Gender}";
        }
        public virtual void Info()
        {
            Console.WriteLine("Возраст: " + Age + "\n" + "Имя: " + First_Name + "\n" + "Фамилия: " + Sur_Name + "\n" + "Пол: " + Gender);
        }

    }
}
