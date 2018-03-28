using System;
using System.IO;

namespace aoc7
{
    internal static class Program
    {
        //private const string ExampleTLS = "../../example.txt";
        //private const string ExampleSSL = "../../example2.txt";
        private const string Input = "../../input.txt";
        
        
        public static void Main(string[] args)
        {
            var lines = GetInput(Input);
            var checkerTLS = new TLSChecker();
            var checkerSSL = new SSLChecker();
            var counterTLS = 0;
            var counterSSL = 0;
            foreach (var line in lines)
            {
                checkerTLS.Line = line;
                if (checkerTLS.CheckSupportTLS())
                    counterTLS++;
                checkerSSL.Line = line;
                if (checkerSSL.CheckSupportSSL())
                    counterSSL++;
            }
            Console.WriteLine(counterTLS + " IPs support TLS.");
            Console.WriteLine(counterSSL + " IPs support SSL.");
        }

        private static string[] GetInput(string fileDir) => File.ReadAllLines(fileDir);
    }
}