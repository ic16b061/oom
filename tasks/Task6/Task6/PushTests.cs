using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Task6
{
    public static class PushTests
    {
        public static void Run()
        {
            var items_subject = new Headphone[]
            {
                new Headphone("AKG", "K712 PRO", "AKG K712 PRO", "0182500387666", 249.00m),
                new Headphone("Beyerdynamic", "T1 2. Generation", "Beyerdynamic T1 2. Generation", "4010118718991", 1199.00m),
                new Headphone("Sennheiser", "HD 650", "Sennheiser HD 650", "0252855101221", 319.00m),
                new Headphone("AKG", "K702", "AKG K702", "9002761021219", 185.00m),
                new Headphone("Beyerdynamic", "DT 880 Edition", "Beyerdynamic DT 880 Edition 600 Ohm", "4010118491320", 199.00m),
                new Headphone("Sennheiser", "HD 800 S", "Sennheiser HD 800 S", "4044155209280", 1590.00m),
                new Headphone("Audio-Technica", "AHT-W5000", "Audio-Technica ATH-W5000", "4961310088088", 1300.00m),
                new Headphone("Denon", "AH-D7200", "Denon AH-D7200", "4951035059357", 799.00m),
            };

            // Rx Queries
            // #1
            var producer = new Subject<Headphone>();
            Console.WriteLine($"Importing new headphones:");
            producer.Subscribe(x => Console.WriteLine($"received value {x.Description} - {x.Price:0.00}"));

            foreach (var x in items_subject)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
                producer.OnNext(x);
            }

            // #2
            var producer2 = new Subject<Headphone>();
            Console.WriteLine($"Headphones above 300 Euros:");
            producer2
                .Where(x => x.Price > 300m)
                .Subscribe(x => Console.WriteLine($"{x.Brand} {x.Model}"))
                ;

            foreach (var x in items_subject)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(0.1));
                producer2.OnNext(x);
            }
        }
    }
}
