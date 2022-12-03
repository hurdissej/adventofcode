namespace Day1;

public static class Day1
{
    public static int Execute(string[] input) => input.Aggregate((0,0), (x, y) => Process(y, x)).Item1;

    private static (int highestTotal, int runningTotal) Process(string input, (int highestTotal, int runningTotal) totals) =>
        input == "" 
            ? (Math.Max(totals.highestTotal, totals.runningTotal), 0) 
            : (totals.highestTotal, (totals.runningTotal + int.Parse(input)));
}