// Learn more about F# at http://fsharp.org

open Hopac
open HttpFs.Client
open FSharp.Json

type User =
  { userId: int option
    id: int option
    title: string option
    body: string option }

[<EntryPoint>]
let main argv =
    let body =
        Request.createUrl Get "https://jsonplaceholder.typicode.com/posts"
        |> Request.responseAsString
        |> run
        |> Json.deserialize<User list>
        |> Seq.map (fun x -> String.length (Option.get x.body))

    Seq.iter 
        (printfn "%i") body

    0 // return an integer exit code
