namespace AdventOfCode2022.Day6
{
    public static class Problem
    {
        public static void GetAnswerA()
        {
            const int keySize = 4;
            try
            {
                var input = File.ReadAllLines("day6\\input.txt").First();
                int? marker = GetStartOfPackage(keySize, input);

                Console.WriteLine(marker.GetValueOrDefault(0));
            }
            catch
            {
                //Ignore error
            }
        }

        public static void GetAnswerB()
        {
            const int keySize = 14;
            try
            {
                var input = File.ReadAllLines("day6\\input.txt").First();
                int? marker = GetStartOfPackage(keySize, input);

                Console.WriteLine(marker.GetValueOrDefault(0));
            }
            catch
            {
                //Ignore error
            }
        }

        private static int? GetStartOfPackage(int keySize, string input)
        {
            int? marker = null;
            for (int index = keySize - 1; index < input.Length; index++)
            {
                var key = input.Substring(index + 1 - keySize, keySize);
                var keySet = new HashSet<char>(key.ToCharArray());
                if (keySet.Count == keySize)
                {
                    marker = index + 1;
                    break;
                }
            }

            return marker;
        }
    }

}