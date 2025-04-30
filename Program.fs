module MicroMLAstVisualizer.App

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.AspNetCore.Http
open FSharp.Text.Lexing

open Lexer
open Parser
open JsonParsing

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    let app = builder.Build()

    app.MapGet("/", Func<HttpContext, Task>(fun ctx ->
        task {
            try
                let input = """{"key": 123, "other": true}""" // Sample JSON-like test input
                let lexbuf = LexBuffer<char>.FromString input
                let result = Parser.start Lexer.read lexbuf
                do! ctx.Response.WriteAsync(sprintf "Parsed AST: %A" result)
            with ex ->
                do! ctx.Response.WriteAsync($"Error: {ex.Message}")
        }
    )) |> ignore

    app.Run()
    0
