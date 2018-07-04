namespace BashSoft.Repository
{
    using BashSoft.IO;
    using BashSoft.Static_data;
    using System.Collections.Generic;
    using System.Linq;

    public static class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                //OrderAndTake(wantedData, studentsToTake, CompareInOrder); // Replaced by LINQ
                PrintStudents(wantedData
                             .OrderBy(x => x.Value.Sum())
                             .Take(studentsToTake)
                             .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                //OrderAndTake(wantedData, studentsToTake, CompareDescendingOrder); // Replaced by LINQ
                PrintStudents(wantedData
                             .OrderByDescending(x => x.Value.Sum())
                             .Take(studentsToTake)
                             .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private static void PrintStudents(Dictionary<string, List<int>> studentsSorted)
        {
            foreach (var keyValuePair in studentsSorted)
            {
                OutputWriter.PrintStudent(keyValuePair);
            }
        }
    }
}