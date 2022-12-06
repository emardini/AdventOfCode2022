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

        private static int CalculatePoints(char l)
        {
            return char.IsLower(l) ? (l - 'a') + 1 : l - 'A' + 27;
        }

        private static char GetCommonItem(string item1, string item2)
        {
            var comparer = item1.ToHashSet();
            return item2.First(i => comparer.Contains(i));
        }

        private static char GetCommonItem(List<string> input)
        {
            var comparer1 = input[0].ToHashSet();
            var comparer2 = input[1].Where(i => comparer1.Contains(i)).ToHashSet();
            return input[2].First(i => comparer2.Contains(i));
        }
    }

}