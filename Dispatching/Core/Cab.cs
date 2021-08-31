using System;
using System.Collections.Generic;
using System.Linq;
using Dispatching.Core.Rides;

namespace Dispatching.Core
{
    public class Cab
    {   
        private readonly Guid _id = Guid.NewGuid();
        private readonly int _cabSize;
        private readonly List<Passenger> _passengers = new ();

        public Mile Mileage { get; private set; }

        public Location Location { get; private set; }

        public IReadOnlyList<Passenger> Passengers => _passengers.AsReadOnly();

        public bool Taken => _passengers.Any();

        public Cab(Location location, int cabSize)
        {
            _cabSize = cabSize;
            Location = location;
        }

        public void Embark(Passenger passenger)
        {
            const int cabDrivers = 1;
            _passengers.Add(passenger);

            if (_passengers.Count + cabDrivers > _cabSize)
            {
                throw new NotSupportedException("Too many passengers.");
            }
        }

        public Receipt Drive(Mile distance, Location newLocation)
        {
            var receipt = Receipt.Create(distance, Location, newLocation); 
            
            Mileage += distance;
            Location = newLocation;
            
            return receipt;
        }

        public void Disembark() => _passengers.Clear();
    }
}