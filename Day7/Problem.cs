namespace AdventOfCode2022.Day7
{
    public static class Problem
    {
        class Node
        {
            public string Id { get; set; } = string.Empty;
            public Node? Parent { get; set; }
            public List<Node> Children { get; private set; } = new List<Node>();
            public string Type { get; set; } = string.Empty;
            public int Size { get; set; } = 0;
            public int  GetTreeSize()
            {
                if (Type == "DIR") return Children.Select(n => n.GetTreeSize()).Sum();

                return Size;
            }
        }

        public static void GetAnswerA()
        {
            List<Node> nodeList = GetNodeList();

            Console.WriteLine(nodeList.Select(n => new {size = n.GetTreeSize()}).Where(n => n.size < 100000).Sum(n => n.size));
        }

        private static string GetDirectory(string[] sections)
        {
            return sections[2];
        }

        private static bool IsFile(string[] sections)
        {
            return  int.TryParse(sections[0], out int _);
        }

        private static bool IsCDMoveUp(string[] sections)
        {
            return sections[2] == "..";
        }

        private static bool IsCDRoot(string[] sections)
        {
            return sections[2] == "/";
        }

        private static bool IsCD(string[] sections)
        {
            return sections.Length > 2 && sections[0] == "$" && sections[1] == "cd"; 
        }


        public static void GetAnswerB()
        {
            List<Node> nodeList = GetNodeList();

            int minRequiredSpace = 30000000 - (70000000 - nodeList.First(n => n.Id == "\\").GetTreeSize());
            Console.WriteLine(nodeList.Select(n => new { size = n.GetTreeSize() }).Where(n => n.size >= minRequiredSpace).OrderBy(n => n.size).First());
        }

        private static List<Node> GetNodeList()
        {
            var nodeList = new List<Node>() { };
            try
            {
                var input = File.ReadAllLines("day7\\input.txt");
                var rootNode = new Node() { Id = "\\", Type = "DIR" };
                nodeList.Add(rootNode);
                var currentNode = rootNode;

                foreach (var line in input)
                {
                    var commandSplit = line.Split(' ');
                    if (IsCD(commandSplit))
                    {
                        if (IsCDRoot(commandSplit))
                        {
                            currentNode = rootNode;
                        }
                        else if (IsCDMoveUp(commandSplit) && currentNode.Parent != null)
                        {
                            currentNode = currentNode.Parent;
                        }
                        else
                        {
                            var directory = GetDirectory(commandSplit);
                            Node? newDirectory = currentNode.Children.FirstOrDefault(c => c.Id == directory);
                            if (newDirectory == null)
                            {
                                newDirectory = new Node() { Id = directory, Parent = currentNode, Type = "DIR" };
                                nodeList.Add(newDirectory);
                                currentNode.Children.Add(newDirectory);

                            }
                            currentNode = newDirectory;
                        }
                    }
                    else if (IsFile(commandSplit))
                    {
                        var fileName = commandSplit[1];
                        Node? newFile = currentNode.Children.FirstOrDefault(c => c.Id == fileName);
                        if (newFile == null)
                        {
                            newFile = new Node() { Id = fileName, Parent = currentNode, Size = int.Parse(commandSplit[0]) };
                            currentNode.Children.Add(newFile);

                        }
                    }
                }


            }
            catch
            {
                //Ignore error
            }

            return nodeList;
        }
    }

}