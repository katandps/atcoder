using System;
using System.Diagnostics;
using System.IO;

namespace ABC116B
{
    public class Local
    {
        private const string Filename = "out.txt";

        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.SetIn(new StreamReader("../../../input.in"));

            FileStream writeFs = new FileStream(Filename, FileMode.Create);
            StreamWriter fileSw = new StreamWriter(writeFs) {AutoFlush = false};
            Console.SetOut(fileSw);

            Program.Debug();
            Console.WriteLine("{0}ms", stopWatch.ElapsedMilliseconds);
            Console.Out.Flush();
            writeFs.Close();

            FileStream readFs = new FileStream(Filename, FileMode.Open);
            StreamReader sr = new StreamReader(readFs);
            StreamWriter standard = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = false};
            Console.SetOut(standard);
            Console.WriteLine(sr.ReadToEnd());
            Console.Out.Flush();
            readFs.Close();
        }
    }
}