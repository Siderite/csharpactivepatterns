// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 


    // create an active pattern
    let (|Int|_|) str =
       match System.Int32.TryParse(str) with
       | (true,int) -> Some(int)
       | _ -> None

    // create an active pattern
    let (|Bool|_|) str =
       match System.Boolean.TryParse(str) with
       | (true,bool) -> Some(bool)
       | _ -> None

    // create a function to call the patterns
    let testParse str = 
        match str with
        | Int i -> printfn "The value is an int '%i'" i
        | Bool b -> printfn "The value is a bool '%b'" b
        | _ -> printfn "The value '%s' is something else" str

    // test
    testParse "12"
    testParse "true"
    testParse "abc"

    System.Console.ReadKey() |> ignore

    0 // return an integer exit code
