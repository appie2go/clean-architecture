using System;

namespace Dispatching
{
    public readonly struct Location
    {
        public decimal Longitude { get; }
        public decimal Latitude { get; }

        public static Location Create(decimal longitude, decimal latitude)
        {
            return new(longitude, latitude);
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
    }
}