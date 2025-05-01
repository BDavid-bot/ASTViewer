module Program

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe
open Views  // <-- Import the new module

let webApp =
    mainPage |> htmlView

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)

    builder.Services.AddGiraffe() |> ignore

    let app = builder.Build()

    app.UseStaticFiles() |> ignore
    app.UseGiraffe(webApp)

    app.Run()
    0
