// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let rec get_length = function | [] -> 0 | _ :: list -> get_length list + 1
let rec reverse = function | [] -> [] | item :: list -> reverse list @ [item]

let say_hi whomst times =
    for _ in 1..times do
        printfn "Hello, %s" whomst
    times

[<EntryPoint>]
let main argv =
    let name = "Daniel"
    let times = say_hi name 5
    printf "Now printed \"Hello, %s\", %i times\n\n\n" name times
    times