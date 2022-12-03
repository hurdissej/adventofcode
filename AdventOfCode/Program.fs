open System.IO

let getInput day =
    let filename = Path.Combine(__SOURCE_DIRECTORY__, $"Input/{day}.txt")
    File.ReadAllLines(filename)

let input = getInput("Day2")

Day1.execute 
    input
