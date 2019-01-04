namespace Football.Data

open FSharp.Data
open Newtonsoft.Json

module League =

    let private (|SuccessCode|_|) c =
        if c >= 200 && c <= 299 then
            Some ()
        else None

    let private leagueToCode (league : FootballLeague) =
        match league with
        | PremierLeague -> "PL"
        | Championship -> "ELC"

    let private deserialise<'a> (resp : HttpResponseBody) : Result<'a, ApiError> =
        match resp with
        | Text json ->
            JsonConvert.DeserializeObject<'a> json |> Ok
        | _ ->
            {
                ErrorCode = 400
                Message = "Unable to deserialise the response json"
            } |> Error

    let get (ApiToken token) (season : int) (league : FootballLeague) : Result<LeagueDto, ApiError> Async =
        let leagueCode = leagueToCode league
        let url =
            sprintf "http://api.football-data.org/v2/competitions/%s/matches" leagueCode

        async {
            let! resp =
                Http.AsyncRequest (url, ["season", sprintf "%d" season], ["X-Auth-Token", token])

            return
                match resp.StatusCode with
                | SuccessCode ->
                    deserialise<LeagueDto> resp.Body
                | _ ->
                    deserialise<ApiError> resp.Body
                    |> Result.bind Error
        }