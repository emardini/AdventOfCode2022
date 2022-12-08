namespace AdventOfCode2022.Day5
{
    public static class Problem
    {
        public static void GetAnswerA()
        {

            try
            {
                var lines = File.ReadAllLines("day5\\input-test.txt");
                var stackLines = lines
                    .TakeWhile(x => x[1] != '1')
                    .Reverse()
                    .ToList();
                var stackItems = stackLines
                    .Select(i => i.Slice(4))
                    .SelectMany((slices, stackOrder) => slices.Select((slice, stackNumber) => new { slice = slice.Trim(), stackNumber, stackOrder}))
                    .Where(item => item.slice != "");

                var stacks = stackItems.GroupBy(x => x.stackNumber)
                    .Select(g => new Stack<string>(g.OrderBy(i => i.stackOrder).Select(i => i.slice)))
                    .ToList();
           
                var instructions = lines.Skip(stackLines.Count + 1)
                    .Select(l => l.Trim())
                    .Where(l => l != "")
                    .Select(l => l.Split(" "))
                    .Select(l => new { move = int.Parse(l[1]), from = int.Parse(l[3]), to = int.Parse(l[5])})
                    .ToList();

                foreach(var instruction in instructions)
                {
                    ExecuteInstructionCrateMover9000(instruction.move, instruction.from, instruction.to, stacks);
                }

                var message = string.Join(string.Empty, stacks.Select(s => s.Pop()[1]));

                Console.WriteLine(message);
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
                var lines = File.ReadAllLines("day5\\input.txt");
                var stackLines = lines
                    .TakeWhile(x => x[1] != '1')
                    .Reverse()
                    .ToList();
                var stackItems = stackLines
                    .Select(i => i.Slice(4))
                    .SelectMany((slices, stackOrder) => slices.Select((slice, stackNumber) => new { slice = slice.Trim(), stackNumber, stackOrder }))
                    .Where(item => item.slice != "");

                var stacks = stackItems.GroupBy(x => x.stackNumber)
                    .Select(g => new Stack<string>(g.OrderBy(i => i.stackOrder).Select(i => i.slice)))
                    .ToList();

                var instructions = lines.Skip(stackLines.Count + 1)
                    .Select(l => l.Trim())
                    .Where(l => l != "")
                    .Select(l => l.Split(" "))
                    .Select(l => new { move = int.Parse(l[1]), from = int.Parse(l[3]), to = int.Parse(l[5]) })
                    .ToList();

                foreach (var instruction in instructions)
                {
                    ExecuteInstructionCrateMover9001(instruction.move, instruction.from, instruction.to, stacks);
                }

                var message = string.Join(string.Empty, stacks.Select(s => s.Pop()[1]));

                Console.WriteLine(message);
            }
            catch
            {
                //Ignore error
            }
        }

        private static IEnumerable<string> Slice(this string input, int sliceSize)
        {
            var sections = (int)Math.Ceiling(input.Length / (double)sliceSize);
            return Enumerable.Range(0, sections)
                .Select(x => input.Substring(x*sliceSize, Math.Min(sliceSize, input.Length - x*sliceSize)));
        }

        private static void ExecuteInstructionCrateMover9000(int move, int from, int to, List<Stack<string>> stacks)
        {
            for(int i = 0; i < move; i++)
            {
                var item = stacks[from - 1].Pop();
                stacks[to-1].Push(item);
            }
        }

        private static void ExecuteInstructionCrateMover9001(int move, int from, int to, List<Stack<string>> stacks)
        {
            var items = Enumerable.Range(0, move).Select(_ => stacks[from - 1].Pop()).Reverse();
            foreach(var item in items)
            {
                stacks[to - 1].Push(item);
            }
        }

    }

}