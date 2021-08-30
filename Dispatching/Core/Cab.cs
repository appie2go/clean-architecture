using System;
using System.Collections.Generic;
using System.Linq;

namespace Dispatching.Core
{
    public class Cab
    {
        private readonly int _cabSize;
        private readonly List<Passenger> _passengerses = new ();

        public Location Location { get; private set; }

        public IReadOnlyList<Passenger> Passengers => _passengerses;

        public bool Taken => _passengerses.Any();

        public Cab(Location location, int cabSize)
        {
            _cabSize = cabSize;
            Location = location;
        }

        public void Embark(Passenger passenger)
        {
            const int cabDrivers = 1;
            _passengerses.Add(passenger);

            if (_passengerses.Count + cabDrivers > _cabSize)
            {
                throw new NotSupportedException("Too many passengers.");
            }
        }

        public void SetLocation(Location newLocation) => Location = newLocation;
        
        public void Disembark() => _passengerses.Clear();
    }
}