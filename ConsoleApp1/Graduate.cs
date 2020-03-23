using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp12
{
    public class Graduate : Student
    {
        string diplom;
		string email;
        public string Diplom
        {
            get { return diplom; }
            set { diplom = value; }
        }
		public string Email
		{
			get => email;
			set
			{
				if (Regex.IsMatch(value, "^[a-zA-Z_]{2,20}@[a-z]{1,6}.[a-z]{2,6}(?=.[a-z]{2,6}).[a-z]{2,6}$"))
				{
					email = value;
				}
				else
				{
					throw new Exception("Incorrect Email");
				}
			}
		}
        public Graduate(int age, string first_name, string sur_name, string gender, int rankings, string group, int course, string diplom, string email) : base(age, first_name, sur_name, gender, rankings, group, course)
        {
            Diplom = diplom;
			Email = email;
            Console.WriteLine("GradConstructor: " + this.GetHashCode());
        }
        ~Graduate()
        {
            Console.WriteLine("GradDestructor" + this.GetHashCode());
        }

        //Methods
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"\nТема дипломной роботы:{Diplom}\nEmail:{Email}");
        }
    }
}
