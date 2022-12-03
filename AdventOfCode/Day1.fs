module Day1

open System;

let f2 ((highest:int, total:int), item:string) =  
    if item = "" 
    then 
        (Math.Max(highest,total), 0)
    else            
        (highest, (total + (item |> int)))

let execute (input:string[]) =
    let (a, _) = Array.fold(fun item result -> f2(item, result)) (0,0) input
    printfn $"{a}"