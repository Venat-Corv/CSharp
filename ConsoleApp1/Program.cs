using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				Teacher t = new Teacher(20, "Anton", "Kiiko", "Male", 12312, "OOp");
				Student s = new Student(23, "Vitaliy", "Gavrish", "Male", 1200, "ST PV 34v", 2);
				Graduate g = new Graduate(19, "Brus", "Bellow", "Male", 1900, "ST PV 34v", 3, "AMD" ,"Skylinegvs@gmail.com");
				s.Info();
				t.Info();
				g.Info();
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
        }
    }
}
