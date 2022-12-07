namespace AdventOfCode2022.Day4
{
    public static class Problem
    {
        public static void GetAnswerA()
        {

            try
            {
                var lines = File.ReadAllLines("day4\\input.txt");
                var result = lines
                    .Select(l => l.Split(','))
                    .Select(l => new { v1 = l[0], v2 = l[1] })
                    .Select(l => new { y1 = l.v1.Split('-'), y2 = l.v2.Split('-')})
                    .Select(l => new { r1s = int.Parse(l.y1[0]), r1e = int.Parse(l.y1[1]), r2s = int.Parse(l.y2[0]), r2e = int.Parse(l.y2[1])})
                    .Count(l => OneIsContainedInTheOther((l.r1s, l.r1e), (l.r2s, l.r2e)));
                Console.WriteLine(result);
            }
            catch
            {
                //Ignore error
            }
        }

        private static bool OneIsContainedInTheOther((int s, int e) range1, (int s, int e) range2)
        {
            return ( (range1.s <= range2.s) && (range1.e >= range2.e) ) 
                || ((range2.s <= range1.s) && (range2.e >= range1.e));
        }

        private static bool OneOverlapsTheOther((int s, int e) range1, (int s, int e) range2)
        {
            return !(range1.e < range2.s || range1.s > range2.e);
        }

        public static void GetAnswerB()
        {
            try
            {
                var lines = File.ReadAllLines("day4\\input.txt");
                var result = lines
                    .Select(l => l.Split(','))
                    .Select(l => new { v1 = l[0], v2 = l[1] })
                    .Select(l => new { y1 = l.v1.Split('-'), y2 = l.v2.Split('-') })
                    .Select(l => new { r1s = int.Parse(l.y1[0]), r1e = int.Parse(l.y1[1]), r2s = int.Parse(l.y2[0]), r2e = int.Parse(l.y2[1]) })
                    .Count(l => OneOverlapsTheOther((l.r1s, l.r1e), (l.r2s, l.r2e)));
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