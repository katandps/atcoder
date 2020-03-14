using System;
using System.Diagnostics;
using System.IO;

namespace Asakatsu20200314B
{
    public class Local
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.SetIn(new StreamReader("../../../input.in"));
            Program.Main(args);
            Console.WriteLine("{0}ms", sw.ElapsedMilliseconds);
        }
    }
}