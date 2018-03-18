using System;
using System.Collections.Generic;
using System.IO;

namespace aoc4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("../../source.txt");
            var sum = 0;
            foreach (var line in input)
            {
                var room = Room.Create(line);
                if (room != null)
                //    sum += room.SectorId;
                    Console.WriteLine("Nr of the room : {0}, ID of the room: {1}.", room.SectorId, room.Description);
            }
            //Console.WriteLine("Sum of sector IDs of created rooms is {0}.", sum);
        }
    }
}