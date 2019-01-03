namespace FootballLeague.Data

open FSharp.Data
open Newtonsoft.Json

module FootballLeague =

    let (|SuccessCode|_|) c =
        if c >= 200 && c <= 299 then
            Some ()
        else None

    let private leagueToCode (league : League) =
        match league with
        | PremierLeague -> "PL"
        | Championship -> "ELC"

    let private convertJsonBody<'a> (resp : HttpResponseBody) : 'a option =
        match resp with
        | Text json ->
            JsonConvert.DeserializeObject<'a> json |> Some
        | _ -> None

    let get (ApiToken token) (season : int) (league : League) : LeagueDto option Async =
        let leagueCode = leagueToCode league
        let url =
            sprintf "http://api.football-data.org/v2/competitions/%s/matches"
                leagueCode

        async {
            let! resp =
                Http.AsyncRequest (url, ["season", sprintf "%d" season], ["X-Auth-Token", token])

            match resp.StatusCode with
            | SuccessCode ->
                return convertJsonBody<LeagueDto> resp.Body
            | _ -> return None
        }