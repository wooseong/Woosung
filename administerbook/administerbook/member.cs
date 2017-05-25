using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administerbook
{
    class member
    {
        private string name;
        private string ID;
        private string password;

        public void signOut()
        {
            Console.Clear();
            Console.Write("\n\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\t Sign in\n");
            Console.Write("\t\t\t\t\t\t Name - ");
            name = Console.ReadLine();
            Console.Write("\t\t\t\t\t\t I.D - ");
            ID = Console.ReadLine();
            Console.Write("\t\t\t\t\t\t Name - ");
            password = Console.ReadLine();
        }
    }
}
