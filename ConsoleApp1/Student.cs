using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp12
{
    public class Student : Human
    {
        int rankings;
        string group;
        public int course;
        public int Rankings
        {
            get { return rankings; }
            set { rankings = value; }

        }
        public string Group
        {
            get
			{
				return group;
			}
            set
			{
				string delimiter = "(_| |-)";
				
				if (Regex.IsMatch(value, $"^(ST|PS{delimiter}(SB|VS)){delimiter}(PV|PU|ITV|ITU|VS|SB){delimiter}[0-9]{{2}}[abv]?$"))
				{
					group = value;
				}
				else
				{
					throw new Exception("Incorrect symbol");
				}
				group = value;
			}

        }
        public int Course
        {
            get { return course; }
            set { course = value; }

        }

        //Constructors
        public Student(int age, string first_name, string sur_name, string gender, int rankings, string group, int course) : base(age, first_name, sur_name, gender)
        {
            Rankings = rankings;
            Group = group;
            Course = course;
            Console.WriteLine("StConstructor: " + this.GetHashCode());
        }
        ~Student()
        {
            Console.WriteLine("StDestructor: " + this.GetHashCode());
        }
        public override void Info()
        {
            Console.WriteLine(this + "\n" + $"Рейтинг: {Rankings}\nГруппа: {Group}\nКурс: {Course}");
        }

    }

}
