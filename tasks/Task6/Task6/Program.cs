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
    class Program
    {
        static void Main(string[] args)
        {
            // Subject<T> and rx query tests
            PushTests.Run();

            // Asynchronous programming tests
            TaskTests.Run();
        }
    }
}

