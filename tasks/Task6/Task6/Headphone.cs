using System;
using Newtonsoft.Json;

namespace Task6
{
    public class Headphone : Product
    {
        /// <summary>
        /// private field for headphone price
        /// </summary>
        private decimal h_price;

        /// <summary>
        /// create a new headphone object
        /// </summary>
        /// <param name="brand">name of manufacturer</param>
        /// <param name="model">name of headphone model</param>
        /// <param name="ean">headphone EAN --> European Article Number (must not be empty)</param>
        /// <param name="price">headphone price (must be positive)</param>
        public Headphone(string brand, string model, string description, string ean, decimal price)
        {
            if (string.IsNullOrWhiteSpace(brand)) throw new ArgumentException("Headphone brand name must not be empty.", nameof(brand));
            if (string.IsNullOrWhiteSpace(model)) throw new ArgumentException("Headphone model must not be empty.", nameof(model));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Headphone description must not be empty.", nameof(description));
            if (string.IsNullOrWhiteSpace(ean)) throw new ArgumentException("EAN must not be empty.", nameof(ean));

            Brand = brand;
            Model = model;
            Description = description;
            EAN = ean;
            UpdatePrice(price);
            IsReturned = false;
        }

        [JsonConstructor]
        public Headphone(string brand, string model, string description, string ean, decimal price, bool isreturned)
        {
            if (string.IsNullOrWhiteSpace(brand)) throw new ArgumentException("Headphone brand name must not be empty.", nameof(brand));
            if (string.IsNullOrWhiteSpace(model)) throw new ArgumentException("Headphone model must not be empty.", nameof(model));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Headphone description must not be empty.", nameof(description));
            if (string.IsNullOrWhiteSpace(ean)) throw new ArgumentException("EAN must not be empty.", nameof(ean));

            Brand = brand;
            Model = model;
            Description = description;
            EAN = ean;
            UpdatePrice(price);
            IsReturned = isreturned;
        }

        /// <summary>
        /// get headphone price
        /// </summary>
        public decimal Price => h_price;

        /// <summary>
        /// get headphone brand
        /// </summary>
        public string Brand { get; }

        /// <summary>
        /// get headphone model
        /// </summary>
        public string Model { get; }

        /// <summary>
        /// get headphone description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// get headphone EAN
        /// </summary>
        public string EAN { get; }

        /// <summary>
        /// set price of returned headphones to 90% of original price
        /// </summary>
        public void SetReturned()
        {
            if (IsReturned) throw new InvalidOperationException($"Headphone {Description} has already been returned.");

            var o_price = Price;
            var n_price = o_price * 0.8m;
            UpdatePrice(n_price);
            IsReturned = true;
        }

        public bool IsReturned { get; private set; }

        /// <summary>
        /// update album price
        /// </summary>
        /// <param name="price_new">new price for album (must be positive)</param>
        public void UpdatePrice(decimal price_new)
        {
            if (price_new < 0) throw new Exception("Price must be a positive value.");
            h_price = price_new;
        }
    }
}
