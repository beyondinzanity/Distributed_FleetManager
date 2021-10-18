using System;

namespace FleetManager.Desktop.Model
{
    public class Car
    {
        public int? Id { get; set; }
        public string Brand { get; set; }
        public int? Mileage { get; set; }
        public Location Location { get; set; }
    }
}
