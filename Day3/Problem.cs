namespace AdventOfCode2022.Day3
{
    public static class Problem
    {
        public static void GetAnswerA()
        {

            try
            {
                var lines = File.ReadAllLines("day3\\input.txt");
                var result = lines
                    .Select(l => (l.Substring(0, l.Length/2), l.Substring(l.Length/2, l.Length / 2)))
                    .Select(l => GetCommonItem(l.Item1, l.Item2))
                    .Select(l => CalculatePoints(l))
                    .Sum();
                Console.WriteLine(result);
            }
            catch
            {
                //Ignore error
            }
        }

        public static void GetAnswerB()
        {

            try
            {
                var lines = File.ReadAllLines("day3\\input.txt");
                var groups = lines.Aggregate(new List<List<string>>() { new List<string>() }, (l, l2) => l.Last().Count == 3 ? AppendGroup(l, new List<string>() { l2 }) : AppendItemsToLastGroup(l, l2));
                var result = groups
                    .Select(g => GetCommonItem(g))
                    .Select(l => CalculatePoints(l))
                    .Sum();
                        
                Console.WriteLine(result);
            }
            catch
            {
                //Ignore error
            }
        }

        private static List<List<string>> AppendGroup(List<List<string>> input, List<string> element)
        {
            input.Add(element);
            return input;
        }

        private static List<List<string>> AppendItemsToLastGroup(List<List<string>> input, string element)
        {
            input.Last().Add(element);
            return input;
        }

        private static int CalculatePoints(char l) => char.IsLower(l) ? (l - 'a') + 1 : l - 'A' + 27;

        private static char GetCommonItem(string item1, string item2) => item1.Intersect(item2).First();

        private static char GetCommonItem(List<string> input) => input.Skip(1).Aggregate(input.First().ToList(), (l, l2) => l.Intersect(l2.ToList()).ToList()).First();
    }

}