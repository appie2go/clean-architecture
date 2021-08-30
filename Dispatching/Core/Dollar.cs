using System;

namespace Dispatching.Core
{
    public readonly struct Dollar
    {
        private readonly decimal _amount;

        public static Dollar Create(decimal amount) => new (amount);

        private Dollar(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be bigger than 0.");
            }

            _amount = amount;
        }
        
        public static Dollar operator *(Dollar price, decimal multiplier) => Create(price._amount * multiplier);
        public static Dollar operator +(Dollar a, Dollar b) => Create(a._amount + b._amount);
    }
}