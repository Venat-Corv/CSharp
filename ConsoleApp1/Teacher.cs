using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp12
{
    class Teacher : Human
    {
        int exper;
        string subject;

        public int Exper
        {
            get
            {
                return exper;
            }
            set
            {
                exper = value;
            }
        }
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public Teacher(int age, string first_name, string sur_name, string gender, int exper, string subject) : base(age, first_name, sur_name, gender)
        {
            Exper = exper;
            Subject = subject;
            Console.WriteLine("TeacherConstructor: " + this.GetHashCode());
        }
        ~Teacher()
        {
            Console.WriteLine("TeacherDestructor: " + this.GetHashCode());
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Опыт: {Exper}\nПредмет: {Subject}");
        }
    }
}
