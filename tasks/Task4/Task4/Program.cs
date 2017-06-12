using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Task4
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

            // print description and price of each product
            foreach (var x in items)
            {
                Console.WriteLine("{0}: {1:0.00}", x.Description, x.Price);
            }

            // Serialize products to json file
            Console.WriteLine("Serialize products...");
            string s = JsonConvert.SerializeObject(items);
            File.WriteAllText(@"D:\products.json", s);
            
            // deserialize products from JSON file & print description and price of each product
            Console.WriteLine("Deserialize products...");
            dynamic items_new = JsonConvert.DeserializeObject(File.ReadAllText(@"D:\products.json"));
            foreach (var x in items_new)
            {
                Console.WriteLine("{0}: {1:0.00}", x.Description, x.Price);
            }
        }
    }
}

