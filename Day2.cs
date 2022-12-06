namespace AdventOfCode2022
{
    public static class Day2
    {
        private static Dictionary<char, int>  playValues = new() { {'X', 1}, {'Y', 2}, {'Z', 3}};
        public static void GetAnswerA()
        {

            try
            {
                var lines = File.ReadAllLines("day2-input.txt");
                var  result = lines.Select(l => l.Trim().Split(' '))
                            .Select(l => (l[0][0], l[1][0]));
                Console.WriteLine(result.Select(r => GetScore(r.Item1, r.Item2)).Sum());
                Console.WriteLine(result.Select(r => GetScoreForOutcome(r.Item1, r.Item2)).Sum());
            }
            catch
            {
                //Ignore error
            }                    
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