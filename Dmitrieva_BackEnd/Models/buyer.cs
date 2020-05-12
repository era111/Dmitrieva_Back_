using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dmitrieva_BackEnd.Models
{
    public class buyer
    {
        public int Id { get; set; }
        public string name { get; set; }

        public double budget { get; set; }

        
        public ICollection<Pump> pumps { get; set; }

        public int getNumberPumps()
        {
            return pumps.Count();
        }
        

    }
}
