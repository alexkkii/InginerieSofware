using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBroker
{
    public abstract class Entity
    {
        public string ID { get; set; }
        public abstract void DisplayInfo(); // Abstract method for polymorphism
    }
}
