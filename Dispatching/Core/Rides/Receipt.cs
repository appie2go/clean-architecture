using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dispatching.Core.Rides
{
    public readonly struct Receipt
    {
        public Mile Distance { get; }
        public Location StartingPoint { get; }
        public Location Destination { get; }
        
        public static Receipt Create(Mile distance, Location startingPoint, Location destination) => new(distance, startingPoint, destination);

        public static Receipt Merge(IEnumerable<Receipt> receipts)
        {
            var startingLocation = receipts.Select(x => x.StartingPoint).First();
            var destination = receipts.Select(x => x.Destination).Last();
            var distance = receipts.Select(x => x.Distance).Aggregate((x, y) => x + y);

            return Create(distance, startingLocation, destination);
        }

        private Receipt(Mile distance, Location startingPoint, Location destination)
        {
            Distance = distance;
            StartingPoint = startingPoint;
            Destination = destination;
        }

        public Dollar CalculatePrice()
        {
            var pricePerKilometer = Dollar.Create(0.5m);
            return pricePerKilometer * Distance.ToDecimal();
        }
    }
}