namespace KeyRevolver
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var gunBarrel = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var locks = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var valueOfIntelligence = int.Parse(Console.ReadLine());
            var lockIndex = 0;
            var bulletsInBarrel = gunBarrel;

            for (int i = bullets.Length - 1; i >= 0; i--)
            {

                if (bullets[i] <= locks[lockIndex])
                {
                    Console.WriteLine("Bang!");
                    lockIndex++;
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                bulletsInBarrel--;
                if (bulletsInBarrel == 0 && i > 0)
                {
                    Console.WriteLine("Reloading!");
                    bulletsInBarrel = gunBarrel;
                }

                valueOfIntelligence -= bulletPrice;
                if (lockIndex == locks.Length)
                {
                    Console.WriteLine($"{i} bullets left. Earned ${valueOfIntelligence}");
                    return;
                }
            }

            Console.WriteLine($"Couldn't get through. Locks left: {locks.Length - lockIndex}");
        }
    }
}