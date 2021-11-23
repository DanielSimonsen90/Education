// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let rec quicksort = function 
    | [] -> [] 
    | x :: xs -> 
        let smaller = List.filter((>) x) xs
        let larger = List.filter((<=) x) xs
        quicksort smaller @ [x] @ quicksort larger

let rec get_length = function | [] -> 0 | _ :: list -> get_length list + 1
let rec reverse = function | [] -> [] | item :: list -> reverse list @ [item]

//let rec factorialAcc = function
//    | 0 -> 1 | 1 -> 1
//    | length -> List.reduce(fun result item -> result * item) [1..length]
let rec factorial = function
    | n when n <= 1 -> 1
    | n -> n * factorial(n - 1)

let factorialAcc n =
    let rec intern (acc: int) (list: List<int>) = 
        match list with 
        | [] -> acc
        | head::tail -> intern (acc * head) tail
            
    intern 1 [1..n]
    

let rec fibonacci = function
    | n when n <= 2 -> 1
    | n -> fibonacci(n - 2) + fibonacci(n - 1)
        
let fibonacciAcc n =
    let rec intern left right steps =
        match steps with
        | 0 -> 1
        | _ -> intern right (right + left) (steps - 1)
    intern 0 1 n

let say_hi whomst times =
    for _ in 1..times do
        printfn "Hello, %s" whomst
    times

let my_map mapping list =
    let rec helper (rest, acc) =
        match rest with
        | [] -> acc
        | head::tail -> helper(tail, acc @ [mapping head])
    helper(list, [])

      

[<EntryPoint>]
let main argv =
    let rand = Random();
    let listToString list = List.foldBack(fun item result -> result + $"{item.ToString()}, ") list "";

    let list = List.init(rand.Next())(rand.Next);
    let listString = listToString(list);

    let length = get_length(list);
    let factorial = factorial(length);
    let fibonacci = fibonacci(length);

    let sortedString = listToString(quicksort(list));
    let reverseString = listToString(reverse(list));

    printf($"List: [{listString}]\n\nSorted: {sortedString}\n\nReverse: {reverseString}\n\nLength: {length}\nFactorial: {factorial}\nFibonacci: {fibonacci}\n");
    0