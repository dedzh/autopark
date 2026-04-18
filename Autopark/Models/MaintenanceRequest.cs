using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.Models
{
    public class MaintenanceRequest
    {
        public int id { get; set; }
        public int car_id { get; set; }
        public DateTime request_date { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public Car Car { get; set; }
    }
}
