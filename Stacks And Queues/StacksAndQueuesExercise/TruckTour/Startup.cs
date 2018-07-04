namespace TruckTour
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var NumberOfStations = int.Parse(Console.ReadLine());
            var KeepPetrolStations = new int[NumberOfStations, 2];

            for (int i = 0; i < NumberOfStations; i++)
            {
                var InputInfo = Console.ReadLine()
                    .Split(new[] { ' ', ',', '/' }, StringSplitOptions.RemoveEmptyEntries);

                KeepPetrolStations[i, 0] = int.Parse(InputInfo[0]); //gas in station
                KeepPetrolStations[i, 1] = int.Parse(InputInfo[1]); //gas needed for travelling
            }

            var UsedGasLog = new Dictionary<int, int[,]>();
            //upon reaching a negative gas tank we store the starting index of the path in which we get
            //the negative gas ,how many indices(stations) to skip and the gas in order to use them if
            //we go through them again

            var StartPathStations = -1;
            var Gas = 0;

            for (int i = 0, Length = KeepPetrolStations.GetLength(0); i <= Length; i++)
            {
                if (UsedGasLog.ContainsKey(i))
                {
                    Gas += UsedGasLog[i][0, 0];
                    i = UsedGasLog[i][0, 1];
                    continue;
                }
                if (i == Length)
                {
                    i = -1;
                    continue;
                }
                if (i == StartPathStations)
                {
                    Console.WriteLine(StartPathStations);
                    return;
                }

                //get gas in station and remove the gas that we need for travelling
                Gas += KeepPetrolStations[i, 0] - KeepPetrolStations[i, 1];

                if (Gas >= 0)
                {
                    if (StartPathStations == -1)
                    {
                        StartPathStations = i;
                    }
                }
                else
                {
                    if (StartPathStations == -1) //if the first one is negative
                    {
                        StartPathStations = i;
                    }

                    UsedGasLog[StartPathStations] = new int[1, 2];
                    UsedGasLog[StartPathStations][0, 0] = Gas;//store gas
                    UsedGasLog[StartPathStations][0, 1] = i;
                    StartPathStations = -1;
                    Gas = 0;
                }
            }

        }
    }
}