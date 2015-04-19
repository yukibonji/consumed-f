﻿// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
namespace Consumed

open CLIParsing
open Railway
open Validation
open Handling

module program =

    [<EntryPoint>]
    let main argv = 
        printfn "%A" argv

        let exec() = 
            match parse argv with
            | Success(Command(cmd)) -> 
            (
                let validationResult = ( cmd |> validateCommand )
                match validationResult with
                | Success(cmd) -> 
                (
                    printfn "Command validated = %A" cmd
                  
                )                
                | Failure(ArgumentEmpty x) -> printfn "Argument empty = %A" x   
                | Failure(ArgumentStructure x) -> printfn "Argument structure invalid = %A" x
            )  
            | Success(Query(qry)) -> printfn "Query not implemented"     
            | Failure ArgumentsMissing -> printfn "Arguments missing, expecting at least two"
            | Failure NotFound -> printfn "Could not find command or query. Check arguments."
            | Failure(KeyLooksLikeValue k) -> printfn "Key %s looks like a value" k
            | Failure(KeyMissing k) -> printfn "Key %s missing" k

        exec()

        0 // return an integer exit code
