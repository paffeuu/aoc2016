using System;

namespace aoc5
{
    internal static class Program
    {
        private const string Input = "abbhdwsy";
        //private const string Example = "abc";
        
        public static void Main(string[] args)
        {
            var md5Gen = new MD5Generator(Input);
            Console.WriteLine("Password is: " + md5Gen.LookForPassword());
        }
    }
}