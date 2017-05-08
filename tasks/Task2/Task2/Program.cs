using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            // create album objects
            Album a = new Album("Sorceress", "Opeth", "0727361382209", 15.90m);
            Album b = new Album("Love Ire & Song", "Frank Turner", "5024545505122", 9.90m);
            Album c = new Album("Back To Times Of Splendor", "Disillusion", "0039841445619", 12.90m);

            // print properties
            Console.WriteLine("The artist of the album " + a.Name +  " is " + a.Artist + ".");
            Console.WriteLine("The price of the album " + b.Name + " is " + b.Price + ".");
            Console.WriteLine("The EAN of the album " + c.Name + " is " + c.EAN + ".");
            
            // update price of album b and print new price
            b.UpdatePrice(7.99m);
            Console.WriteLine("The new price of the album " + b.Name + " is " + b.Price + ".");
        }
    }

    public class Album
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
        /// <param name="price">album name (must be positive)</param>
        public Album(string name, string artist, string ean, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Album name must not be empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(artist)) throw new ArgumentException("Album artist must not be empty.", nameof(artist));
            if (string.IsNullOrWhiteSpace(ean)) throw new ArgumentException("EAN must not be empty.", nameof(ean));

            Name = name;
            Artist = artist;
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
