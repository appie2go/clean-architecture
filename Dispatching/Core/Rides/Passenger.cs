namespace Dispatching.Core.Rides
{
    public class Passenger
    {
        public Location Location { get; }

        public static Passenger Create(decimal @long, decimal lat) => new(Location.Create(@long, lat));
        
        private Passenger(Location location)
        {
            Location = location;
        }
    }
}