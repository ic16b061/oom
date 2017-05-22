using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            // create different products
            var items = new Product[]
            {
                new Album("Sorceress", "Opeth", "Opeth - Sorceress", "0727361382209", 15.90m),
                new Album("Love Ire & Song", "Frank Turner", "Frank Turner - Love Ire & Song", "5024545505122", 9.90m),
                new Album("Back To Times Of Splendor", "Disillusion", "Disillusion - Back To Times Of Splendor", "0039841445619", 12.90m),
                new Headphone("AKG", "K702", "AKG K702", "9002761021219", 185.00m),
                new Headphone("Beyerdynamic", "DT 880 Edition", "Beyerdynamic DT 880 Edition 600 Ohm", "4010118491320", 199.00m),
                new Headphone("Sennheiser", "HD 800 S", "Sennheiser HD 800 S", "4044155209280", 1590.00m),
                new Headphone("Audio-Technica", "AHT-W5000", "Audio-Technica ATH-W5000", "4961310088088", 1300.00m),
                new Headphone("Denon", "AH-D7200", "Denon AH-D7200", "4951035059357", 799.00m),
            };

            // print each product description and current price
            foreach (var x in items)
            {
                Console.WriteLine($"{x.Description}: {x.Price}");
            }
            
        }
    }

    public interface Product
    {
        /// <summary>
        /// get product description
        /// </summary>
        string Description { get; }

        /// <summary>
        /// get EAN of product
        /// </summary>
        string EAN { get; }

        /// <summary>
        /// get product price
        /// </summary>
        /// <returns></returns>
        decimal Price { get; }

        /// <summary>
        /// update price of product
        /// </summary>
        void UpdatePrice(decimal price_new);
    }

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

