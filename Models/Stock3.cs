using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Stock3
    {
        public string ID {get; set;}
        
        public double Open { get; set; }
        
        public double Close { get; set; }

        public double High { get; set; }

        public double Low { get; set; }
        
        public string Type {get; set;}

    }
}