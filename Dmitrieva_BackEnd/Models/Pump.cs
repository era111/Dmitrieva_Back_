using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dmitrieva_BackEnd.Models
{
    public class Pump
    {
        public int id { get; set; }

        public string Type { get; set; }

        public int Power { get; set; }

        public int barrel { get; set; }

        public int price { get; set; }

        
        public int StartYear { get; set; } //2020

        public int EndYear { get; set; } //2025

        public IEnumerable<Pump> ppumps { get; set; }

        //public double Depreciation() 
       // {
           // double Ar = price/ (EndYear - StartYear);
            
           // return Ar;
        //}

    }
}
