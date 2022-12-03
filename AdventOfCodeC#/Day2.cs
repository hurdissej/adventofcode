namespace Day2;

public static class Day2 
{
    public static int Execute(string[] input)
    {
        return input
            .Select(game => game.Split(' ').Take(2))
            .Select(twoSide => (Parse(twoSide.First()), Parse(twoSide.Last())))
            .Select(GetScore)
            .Sum();
    }

    private static int GetScore((RPS lhs, RPS rhs) input)
    {
        switch (input.rhs)
        {
            case RPS.Scissors:
            {
                int score = 3;
                if (input.lhs == RPS.Scissors) score += 3;
                if (input.lhs == RPS.Paper) score += 6;
                return score;
            }
            case RPS.Paper:
            {
                int score = 2;
                if (input.lhs == RPS.Paper) score += 3;
                if (input.lhs == RPS.Rock) score += 6;
                return score;
            }
            case RPS.Rock:
            {
                int score = 1;
                if (input.lhs == RPS.Rock) score += 3;
                if (input.lhs == RPS.Scissors) score += 6;
                return score;
            }
            default:
                throw new ArgumentException();
        }
    }

    private static RPS Parse(string input)
    {
        switch (input)
        {
            case "A": case "X": return RPS.Rock;
            case "B": case "Y": return RPS.Paper;
            case "C": case "Z": return RPS.Scissors;
            default: throw new ArgumentException("Not a valid input");
        }   
    }

    private enum RPS
    {
        Rock,
        Paper,
        Scissors
    }
}