using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Threading;

namespace Task6
{
    public static class TaskTests
    {
        public static void Run()
        {
            var random = new Random();

            var items = new Headphone[]
            {
                new Headphone("AKG", "K712 PRO", "AKG K712 PRO", "0182500387666", 249.00m),
                new Headphone("Beyerdynamic", "T1 2. Generation", "Beyerdynamic T1 2. Generation", "4010118718991", 1190.00m),
                new Headphone("Sennheiser", "HD 650", "Sennheiser HD 650", "0252855101221", 319.00m),
                new Headphone("AKG", "K702", "AKG K702", "9002761021219", 186.00m),
                new Headphone("Beyerdynamic", "DT 880 Edition", "Beyerdynamic DT 880 Edition 600 Ohm", "4010118491320", 199.00m),
                new Headphone("Sennheiser", "HD 800 S", "Sennheiser HD 800 S", "4044155209280", 1590.00m),
                new Headphone("Audio-Technica", "AHT-W5000", "Audio-Technica ATH-W5000", "4961310088088", 1300.00m),
                new Headphone("Denon", "AH-D7200", "Denon AH-D7200", "4951035059357", 799.00m),
            };

            var tasks = new List<Task<decimal>>();
            foreach (var x in items)
            {
                var task = Task.Run(() =>
                {
                    Console.WriteLine($"set {x.Description} returned and calculate new price (original price is {x.Price:0.00})");
                    x.SetReturned();
                    Task.Delay(TimeSpan.FromSeconds(5.0 + random.Next(20))).Wait();
                    Console.Write($"done updating {x.Description}: ");                    
                    return x.Price;
                });

                tasks.Add(task);
            }

            var tasks2 = new List<Task<decimal>>();
            foreach (var task in tasks.ToArray())
            {
                tasks2.Add(
                    task.ContinueWith(t =>
                    {
                        Console.WriteLine($"new price is {t.Result:0.00}");
                        return t.Result;
                    })
                );
            }

            var token = new CancellationTokenSource();
            var longTask = CheckPrice(items, token.Token);

            Console.ReadLine();
            token.Cancel();
            Console.WriteLine("cancelled operation");
        }

        public static Task<bool> IsBelow1000(decimal price, CancellationToken token)
        {
            return Task.Run(() =>
            {
                token.ThrowIfCancellationRequested();
                if (price < 1000m) return true;
                return false;
            }, token);
        }

        public static async Task CheckPrice(Headphone[] items, CancellationToken token)
        {
            var random = new Random();

            foreach (var x in items)
            {
                token.ThrowIfCancellationRequested();
                Task.Delay(TimeSpan.FromSeconds(3.0 + random.Next(10))).Wait();
                if (await IsBelow1000(x.Price, token)) Console.WriteLine($"Price of {x.Description} is below 1.000 Euros: {x.Price:0.00}");
            }
        }
    }
}
