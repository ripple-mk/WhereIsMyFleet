using WhereIsMyFleet.Core.Abstractions;

namespace WhereIsMyFleet.Core.Features.Fleet
{
    public class Drone : BaseEntity
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
