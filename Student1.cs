using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp12
{
    public class Student1 : Human1
    {
        public int rankings;
        public string group;
        public int course;
        public int Rankings
        {
            get { return rankings; }
            set { rankings = value; }

        }
        public string Group
        {
            get { return group; }
            set { group = value; }

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
