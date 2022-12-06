namespace AdventOfCode2022
{
    public static class Day2
    {
        private static Dictionary<char, int>  playValues = new Dictionary<char, int>{{'X', 1}, {'Y', 2}, {'Z', 3}};
        public static void GetAnswerA()
        {

            var result = new List<(char A, char B)>();
            try
            {
                using StreamReader reader = new("day2-input.txt");
    
                do
                {
                    var line = (reader.ReadLine() ?? "").Trim();
                    var splitLine = line.Split(' ');
                    result.Add((splitLine[0][0], splitLine[1][0]));
                    
                }
                while (reader.Peek() != -1);               
            }
            catch
            {
                //Ignore error
            }

           
            Console.WriteLine(result.Select(r => GetScore(r.A, r.B)).Sum());
            Console.WriteLine(result.Select(r => GetScoreForOutcome(r.A, r.B)).Sum());
        }
        private static int GetScore(char otherPlay, char myPlay)
        {
            var playValue = playValues[myPlay];
            var outcomePoints = GetOutcomePoints(otherPlay, myPlay);

            return playValue + outcomePoints;

        }

        private static int GetScoreForOutcome(char otherPlay, char myOutcome)
        {
            var myPlay = DecidePlay(otherPlay, myOutcome);
            var playValue = playValues[myPlay];
            var outcomePoints = GetOutcomePoints(otherPlay, myPlay);

            return playValue + outcomePoints;

        }

        private static int GetOutcomePoints(char otherPlay, char myPlay)
        {
            if (myPlay == 'Z' && otherPlay == 'C' || myPlay == 'X' && otherPlay == 'A' || myPlay == 'Y' && otherPlay == 'B') return 3;

            if (myPlay == 'Z' && otherPlay == 'B' || myPlay == 'X' && otherPlay == 'C' || myPlay == 'Y' && otherPlay == 'A') return 6;

            return 0;
        }

        private static char DecidePlay(char otherPlay, char myOutcome)
        {
            if (myOutcome == 'Y')
            {              
                if (otherPlay == 'A') return 'X';
                if (otherPlay == 'B') return 'Y';
                if (otherPlay == 'C') return 'Z';
            }

            if(myOutcome == 'Z')
            {            
                if (otherPlay == 'A') return 'Y';
                if (otherPlay == 'B') return 'Z';
                if (otherPlay == 'C') return 'X';
            }

            if (otherPlay == 'A') return 'Z';
            if (otherPlay == 'B') return 'X';
            return 'Y';
           
        }
    }

}