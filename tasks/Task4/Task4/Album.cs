using System;

namespace Task4
{
    public class Album : Product
    {
        /// <summary>
        /// private field for album price
        /// </summary>
        private decimal a_price;

        /// <summary>
        /// create a new album object
        /// </summary>
        /// <param name="name">album name (must not be empty)</param>
        /// <param name="artist">album artist (must not be empty)</param>
        /// <param name="ean">album EAN --> European Article Number (must not be empty)</param>
        /// <param name="price">album price (must be positive)</param>
        public Album(string name, string artist, string description, string ean, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Album name must not be empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(artist)) throw new ArgumentException("Album artist must not be empty.", nameof(artist));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Album description must not be empty.", nameof(description));
            if (string.IsNullOrWhiteSpace(ean)) throw new ArgumentException("EAN must not be empty.", nameof(ean));

            Name = name;
            Artist = artist;
            Description = description;
            EAN = ean;
            UpdatePrice(price);
        }

        /// <summary>
        /// get album price
        /// </summary>
        public decimal Price => a_price;

        /// <summary>
        /// get album name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// get album artist
        /// </summary>
        public string Artist { get; }

        /// <summary>
        /// get album description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// get album EAN
        /// </summary>
        public string EAN { get; }

        /// <summary>
        /// update album price
        /// </summary>
        /// <param name="price_new">new price for album (must be positive)</param>
        public void UpdatePrice(decimal price_new)
        {
            if (price_new < 0) throw new Exception("Price must be a positive value.");
            a_price = price_new;
        }
    }
}
