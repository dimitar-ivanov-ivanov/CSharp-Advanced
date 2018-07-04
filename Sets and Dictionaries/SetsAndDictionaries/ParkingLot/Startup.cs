namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute());
        }

        private static string Execute()
        {
            var cars = new SortedSet<string>();
            var args = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            while (args[0] != "END")
            {
                if (args[0] == "IN")
                {
                    if (!cars.Contains(args[1]))
                    {
                        cars.Add(args[1]);
                    }
                }
                else
                {
                    if (cars.Contains(args[1]))
                    {
                        cars.Remove(args[1]);
                    }
                }

                args = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            if (cars.Count == 0)
            {
                return "Parking Lot is Empty";
            }

            return string.Join("\n", cars);
        }
    }
}