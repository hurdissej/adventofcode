namespace Day2;

public static class Day2 
{
    public static int Execute(string[] input)
    {
        return input
            .Select(game => game.Split(' ').Take(2))
            .Select(twoSide => (ParseLhs(twoSide.First()), ParseRhs(twoSide.Last())))
            .Select(GetScore)
            .Sum();
    }

    private static int GetScore((RPS lhs, WLD rhs) input)
    {
        switch (input.lhs)
        {
            case RPS.Scissors:
            {
                if (input.rhs == WLD.Win) return Scores[WLD.Win.ToString()] + Scores[RPS.Rock.ToString()];
                if (input.rhs == WLD.Draw) return Scores[WLD.Draw.ToString()] + Scores[RPS.Scissors.ToString()];
                if (input.rhs == WLD.Lose) return Scores[WLD.Lose.ToString()] + Scores[RPS.Paper.ToString()];
                return 0;
            }
            case RPS.Paper:
            {
                if (input.rhs == WLD.Win) return Scores[WLD.Win.ToString()] + Scores[RPS.Scissors.ToString()];
                if (input.rhs == WLD.Draw) return Scores[WLD.Draw.ToString()] + Scores[RPS.Paper.ToString()];
                if (input.rhs == WLD.Lose) return Scores[WLD.Lose.ToString()] + Scores[RPS.Rock.ToString()];
                return 0;
            }
            case RPS.Rock:
            {
                if (input.rhs == WLD.Win) return Scores[WLD.Win.ToString()] + Scores[RPS.Paper.ToString()];
                if (input.rhs == WLD.Draw) return Scores[WLD.Draw.ToString()] + Scores[RPS.Rock.ToString()];
                if (input.rhs == WLD.Lose) return Scores[WLD.Lose.ToString()] + Scores[RPS.Scissors.ToString()];
                return 0;
            }
            default:
                throw new ArgumentException();
        }
    }

    private static RPS ParseLhs(string input)
    {
        switch (input)
        {
            case "A": return RPS.Rock;
            case "B": return RPS.Paper;
            case "C": return RPS.Scissors;
            default: throw new ArgumentException("Not a valid input");
        }   
    }
    
    private static WLD ParseRhs(string input)
    {
        switch (input)
        {
            case "X": return WLD.Lose;
            case "Y": return WLD.Draw;
            case "Z": return WLD.Win;
            default: throw new ArgumentException("Not a valid input");
        }   
    }

    private static Dictionary<string, int> Scores = new Dictionary<string, int>()
    {
        { "Rock", 1 },
        { "Paper", 2 },
        { "Scissors", 3 },
        { "Win", 6 },
        { "Draw", 3 },
        { "Lose", 0 },
    };

    private enum RPS
    {
        Rock,
        Paper,
        Scissors
    }
    private enum WLD
    {
        Win,
        Lose,
        Draw
    }
}