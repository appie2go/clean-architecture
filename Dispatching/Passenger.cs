namespace Dispatching
{
    public class Passenger
    {
        public Location Destination { get; }
        
        public Passenger(Location destination)
        {
            Destination = destination;
        }
    }
}