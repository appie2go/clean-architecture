using System;
using Newtonsoft.Json;

namespace Dispatching.Core.Rides
{
    public readonly struct Location
    {
        public decimal Longitude { get; }
        public decimal Latitude { get; }

        public static Location Create(decimal longitude, decimal latitude) => new(longitude, latitude);

        public static Location Parse(string serializedLocation)
        {
            var decimals = JsonConvert.DeserializeObject<decimal[]>(serializedLocation);
            if (decimals.Length != 2)
            {
                throw new FormatException($"{serializedLocation} is not a valid location");
            }

            return new(decimals[0], decimals[1]);
        }
        
        private Location(decimal longitude, decimal latitude)
        {
            if (longitude > 180 || longitude < -180)
            {
                throw new ArgumentException(nameof(longitude));
            }
            
            if (latitude > 90 || latitude < -90)
            {
                throw new ArgumentException(nameof(longitude));
            }

            Longitude = longitude;
            Latitude = latitude;
        }

        public override string ToString() => JsonConvert.SerializeObject(new[] { Longitude, Latitude });
    }
}