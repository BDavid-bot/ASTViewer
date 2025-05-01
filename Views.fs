module Views

open Giraffe.ViewEngine
open Giraffe.ViewEngine.HtmlElements
open Giraffe.ViewEngine.Attributes

let mainPage =
    html [] [
        head [] [
            title [] [ str "MicroML AST Viewer" ]
            link [ attr "rel" "stylesheet"; attr "href" "/style.css" ]
        ]
        body [] [
            h1 [] [ str "Hi" ]
            p [] [ str "Page temp text" ]
        ]
    ]
