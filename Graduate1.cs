using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp12
{
    public class Graduate1 : Student1
    {
        public string diplom;
        public string Diplom
        {
            get { return diplom; }
            set { diplom = value; }
        }
        public Graduate(int age, string first_name, string sur_name, string gender, int rankings, string group, int course, string diplom) : base(age, first_name, sur_name, gender, rankings, group, course)
        {
            Diplom = diplom;
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
            Console.WriteLine($"\nТема дипломной роботы:{Diplom}");
        }
    }
}
