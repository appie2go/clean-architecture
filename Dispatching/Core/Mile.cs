using System;

namespace Dispatching.Core
{
    public readonly struct Mile
    {
        private readonly decimal _distance;

        public static Mile Create(decimal distance) => new(distance);

        private Mile(decimal distance)
        {
            if (distance < 0)
            {
                throw new ArgumentException("Distance must be 0 or greater.", nameof(distance));
            }

            _distance = distance;
        }
        
        public static bool operator >(Mile a, Mile b) => a._distance > b._distance;
        
        public static bool operator <(Mile a, Mile b) => a._distance < b._distance;

        public static Mile operator +(Mile a, Mile b) => Create(a._distance + b._distance);
        
        public override string ToString() => _distance.ToString();
        
        public decimal ToDecimal() => _distance;
    }
}