module dotCRFSuite.FSharp
open dotCRFSuite.Wrapper
open System
open System.Collections.Generic

type Tagger with
    member this.Tag (input:seq<seq<(string*obj)>>) =
        let _input = input |> Seq.map (fun t -> t |> Seq.map KeyValuePair<string,Object>) |> Seq.toArray
        this.Tag _input
        
type Trainer with
    member this.Append ((input:seq<seq<(string*obj)>>), (output: seq<string>)) =
        let _input = input |> Seq.map (fun t -> t |> Seq.map KeyValuePair<string,Object>) |> Seq.toArray
        this.Append(_input, output)
