using System;

namespace FleetManager.Entities
{
    public class Car : BaseEntity
    {
        public string Brand { get; set; }
        public int Mileage { get; set; }
        public DateTime? Reserved { get; set; }
        public Location Location { get; set; }

        public int? LocationId => Location?.Id;
    }
}
