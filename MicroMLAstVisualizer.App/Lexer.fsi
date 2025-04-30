
module Lexer
open FSharp.Text.Lexing
open System
open Parser/// Rule read
val read: lexbuf: LexBuffer<char> -> token
/// Rule read_string
val read_string: str: string -> ignorequote: bool -> lexbuf: LexBuffer<char> -> token
