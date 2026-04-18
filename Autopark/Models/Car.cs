using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.Models
{
    public class Car
    {
        public int id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public string license_plate { get; set; }
        public int mileage { get; set; }
        public string FullInfo => $"{brand} {model} ({license_plate})";
    }
}
