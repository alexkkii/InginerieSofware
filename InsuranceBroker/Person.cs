using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBroker
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Implementing the abstract method
        public override void DisplayInfo()
        {
            Console.WriteLine($"Person ID: {ID}, Name: {FirstName} {LastName}");
        }
    }

}
