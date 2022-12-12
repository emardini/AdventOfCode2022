namespace AdventOfCode2022.Day8
{
    public static class Problem
    {
      

        public static void GetAnswerA()
        {
            int visCount = 0;
            try
            {
                (int size, int[,] treeGrid) = GetMatrix("day8\\input.txt");                

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (IsVisible(treeGrid, row, col, size))
                            visCount++;
                    }
                }

            }
            catch 
            { }
            Console.WriteLine(visCount);
        }

        private static (int size, int[,] matrix) GetMatrix(string fileName)
        {
            var input = File.ReadAllLines(fileName);
            var size = input.Length;
            var treeGrid = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                var values = input[row].ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
                for (int col = 0; col < size; col++)
                    treeGrid[row, col] = values[col];
            }

            return (size, treeGrid);
        }

        private static bool IsVisible(int[,] treeGrid, int row, int col, int size)
        {
            if (row == 0 || row == size - 1 || col == 0 || col == size - 1) return true;

            var isVisibleRowUp = true;
            for(int rowUp = 0; rowUp < row; rowUp++)
            {
                if (treeGrid[rowUp, col] >= treeGrid[row, col] )
                {
                    isVisibleRowUp = false;
                    break;
                }
            }
            if(isVisibleRowUp) return true;

            var isVisibleRowDown = true;
            for (int rowDown = size-1; rowDown > row; rowDown--)
            {
                if (treeGrid[rowDown, col] >= treeGrid[row, col])
                {
                    isVisibleRowDown = false;
                    break;
                }
            }
            if(isVisibleRowDown) return true;

            var isVisibleColUp = true;
            for (int colUp = 0; colUp < col; colUp++)
            {
                if (treeGrid[row, colUp] >= treeGrid[row, col])
                {
                    isVisibleColUp = false;
                    break;
                }
            }
            if(isVisibleColUp) return true;

            var isVisibleColDown = true;
            for (int colDown = size-1; colDown > col; colDown--)
            {
                if (treeGrid[row, colDown] >= treeGrid[row, col])
                {
                    isVisibleColDown = false;
                    break;
                }
            }

            return isVisibleColDown;

        }

        private static int GetScenicScore(int[,] treeGrid, int row, int col, int size)
        {
            if (row == 0 || row == size - 1 || col == 0 || col == size - 1) return 0;

            var scUp = 0;
            for (int rowUp = row-1; rowUp >= 0; rowUp--)
            {
                if (treeGrid[rowUp, col] >= treeGrid[row, col])
                {
                    scUp++;
                    break;
                }

                scUp++;
            }


            var scDown = 0;
            for (int rowDown = row+1; rowDown < size; rowDown++)
            {
                if (treeGrid[rowDown, col] >= treeGrid[row, col])
                {
                    scDown++;
                    break;
                }

                scDown++;
            }
            

            var scLeft = 0;
            for (int colLeft = col-1; colLeft >= 0; colLeft--)
            {
                if (treeGrid[row, colLeft] >= treeGrid[row, col])
                {
                    scLeft++;
                    break;
                }

                scLeft++;
            }


            var scRight = 0;
            for (int colRight = col+1; colRight < size; colRight++)
            {
                if (treeGrid[row, colRight] >= treeGrid[row, col])
                {
                    scRight++;
                    break;
                }

                scRight++;
            }

            return scUp*scDown*scLeft*scRight;

        }

        public static void GetAnswerB()
        {
            var maxScenicScore = 0;
            try
            {
                (int size, int[,] treeGrid) = GetMatrix("day8\\input.txt");

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        var sc = GetScenicScore(treeGrid, row, col, size);
                        if (sc > maxScenicScore)
                            maxScenicScore = sc;
                    }
                }

            }
            catch
            { }
            Console.WriteLine(maxScenicScore);
        }

    }

}