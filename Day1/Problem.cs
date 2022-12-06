namespace AdventOfCode2022.Day1
{
    public static class Problem
    {
        public static void GetAnswerA()
        {

            var result = new List<List<int>>();
            try
            {
                using StreamReader reader = new("day1\\input.txt");

                var currentResult = new List<int>();
                do
                {
                    var line = (reader.ReadLine() ?? "").Trim();
                    if (line == "")
                    {
                        result.Add(currentResult);
                        currentResult = new List<int>();
                    }

                    if (int.TryParse(line, out int value))
                    {
                        currentResult.Add(value);
                    }
                }
                while (reader.Peek() != -1);
            }
            catch
            {
                //Ignore error
            }

            var maxThree = result.Select(r => r.Sum()).OrderByDescending(r => r).Take(3).Sum();
            var maxTotalCalories = result.Select(r => r.Sum()).Max();
            Console.WriteLine(maxThree);
            Console.WriteLine(maxTotalCalories);
        }
    }

}