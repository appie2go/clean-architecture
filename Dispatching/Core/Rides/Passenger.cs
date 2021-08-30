namespace Dispatching.Core.Rides
{
    public class Passenger
    {
        public Location Location { get; }
        
        public Passenger(Location location)
        {
            Location = location;
        }
    }
}