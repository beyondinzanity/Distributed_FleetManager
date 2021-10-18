using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Desktop.Model
{
    public class Car
    {
        public int? Id { get; set; }
        public string Brand { get; set; }
        public int Mileage { get; set; }
        public Location Location { get; set; }
    }
}
