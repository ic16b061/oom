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
            // create different albums
            var a_items = new List<Album>
            {
                new Album("Sorceress", "Opeth", "Opeth - Sorceress", "0727361382209", 15.90m),
                new Album("Love Ire & Song", "Frank Turner", "Frank Turner - Love Ire & Song", "5024545505122", 9.90m),
                new Album("Back To Times Of Splendor", "Disillusion", "Disillusion - Back To Times Of Splendor", "0039841445619", 12.90m),
            };

            // create different headphones
            var h_items = new List<Headphone>
            {
                new Headphone("AKG", "K702", "AKG K702", "9002761021219", 185.00m),
                new Headphone("Beyerdynamic", "DT 880 Edition", "Beyerdynamic DT 880 Edition 600 Ohm", "4010118491320", 199.00m),
                new Headphone("Sennheiser", "HD 800 S", "Sennheiser HD 800 S", "4044155209280", 1590.00m),
                new Headphone("Audio-Technica", "AHT-W5000", "Audio-Technica ATH-W5000", "4961310088088", 1300.00m),
                new Headphone("Denon", "AH-D7200", "Denon AH-D7200", "4951035059357", 799.00m),
            };

            // print each album description and current price and serialize it to json file
            for (var i = 0; i < a_items.Count; i++)
            {
                Console.WriteLine($"{a_items[i].Description}: {a_items[i].Price}");
                string s = JsonConvert.SerializeObject(a_items[i]);
                File.WriteAllText(@"D:\" + a_items[i].Artist + "_" + a_items[i].Name + ".json", s);
            }

            // print each headphone description and current price and serialize it to json file
            for (var i = 0; i < h_items.Count; i++)
            {
                Console.WriteLine($"{h_items[i].Description}: {h_items[i].Price}");
                string s = JsonConvert.SerializeObject(h_items[i]);
                File.WriteAllText(@"D:\" + h_items[i].Brand + "_" + h_items[i].Model + ".json", s);
            }

            Console.WriteLine("Deserializing...");

            // deserialize album JSON from file & print it
            for (var i = 0; i < a_items.Count; i++)
            {
                Album x = JsonConvert.DeserializeObject<Album>(File.ReadAllText(@"D:\" + a_items[i].Artist + "_" + a_items[i].Name + ".json"));
                Console.WriteLine($"{x.Description}: {x.Price}");
            }

            // deserialize headphone JSON from file & print it
            for (var i = 0; i < h_items.Count; i++)
            {
                Headphone x = JsonConvert.DeserializeObject<Headphone>(File.ReadAllText(@"D:\" + h_items[i].Brand + "_" + h_items[i].Model + ".json"));
                Console.WriteLine($"{x.Description}: {x.Price}");
            }
        }
    }
}

