using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBroker
{
    public class Vehicle : Entity
    {
        public string Make { get; set; }
        public string Model { get; set; }

        // Implementing the abstract method
        public override void DisplayInfo()
        {
            Console.WriteLine($"Vehicle ID: {ID}, Make: {Make}, Model: {Model}");
        }
    }

}
