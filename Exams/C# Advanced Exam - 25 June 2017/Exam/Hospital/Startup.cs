namespace Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var departments = new Dictionary<string, List<string>>();
            var doctors = new Dictionary<string, List<string>>();
            var maxBedsInDepartment = 60;

            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (!string.Join("", args).Equals("Output"))
            {
                var dep = args[0];
                var doctor = args[1] + " " + args[2];
                var patient = args[3];

                if (!departments.ContainsKey(dep))
                {
                    departments.Add(dep, new List<string>(maxBedsInDepartment));
                }

                if (!doctors.ContainsKey(doctor))
                {
                    doctors.Add(doctor, new List<string>());
                }

                doctors[doctor].Add(patient);
                if (departments[dep].Count < maxBedsInDepartment)
                {
                    departments[dep].Add(patient);
                }

                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Print(departments, doctors);
        }

        private static void Print(Dictionary<string, List<string>> departments, Dictionary<string, List<string>> doctors)
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var res = new List<string>();

            if (args.Length == 1)
            {
                var name = args[0];
                if (departments.ContainsKey(name))
                {
                    for (int i = 0; i < departments[name].Count; i++)
                    {
                        res.Add(departments[name][i]);
                    }
                }
            }
            else
            {
                var first = args[0];
                if (args[1][0] >= 'A' && args[1][0] <= 'Z')
                {
                    var doctor = args[0] + " " + args[1];
                    for (int i = 0; i < doctors[doctor].Count; i++)
                    {
                        res.Add(doctors[doctor][i]);
                    }
                }
                else if (departments.ContainsKey(first))
                {
                    var room = int.Parse(args[1]);
                    var start = 3 * (room - 1);

                    if (departments.ContainsKey(first))
                    {
                        for (int i = start; i <= start + 2; i++)
                        {
                            res.Add(departments[first][i]);
                        }
                    }
                }

                res = res.OrderBy(x => x).ToList();
            }

            Console.WriteLine(string.Join("\n", res));
        }
    }
}
