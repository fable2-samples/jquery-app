module App

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser

module JQuery =

    type IJQuery =
        interface end

    [<Emit("window['$']($0)")>]
    let select (selector: string) : IJQuery = jsNative

    [<Emit("window['$']($0)")>]
    let ready (handler: unit -> unit) : unit = jsNative

    [<Emit("$2.css($0, $1)")>]
    let css (prop: string) (value: string) (el: IJQuery) : IJQuery = jsNative

    [<Emit("$1.addClass($0)")>]
    let addClass (className: string) (el: IJQuery) : IJQuery = jsNative

    [<Emit("$1.click($0)")>]
    let click (handler: obj -> unit) (el: IJQuery) : IJQuery = jsNative

JQuery.ready (fun () ->
    let div = JQuery.select "#main"

    div
    |> JQuery.css "background-color" "red"
    |> JQuery.click (fun ev -> console.log("Clicked"))
    |> JQuery.addClass "fancy-class"
    |> ignore
)

// jQuery 
// record type
// https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/records
// class type
// https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/classes
type JqueryClass(elem) =
  let e = elem
  member x.Select(selector) =
    JQuery.select selector

// Alternatively import from node module and cast using a class type
let jq = importDefault<JqueryClass> "jquery" 
let main = jq.Select "main"