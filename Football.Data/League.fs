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

    let private convertJsonBody<'a> (resp : HttpResponseBody) : 'a option =
        match resp with
        | Text json ->
            JsonConvert.DeserializeObject<'a> json |> Some
        | _ -> None

    let get (ApiToken token) (season : int) (league : FootballLeague) : LeagueDto option Async =
        let leagueCode = leagueToCode league
        let url =
            sprintf "http://api.football-data.org/v2/competitions/%s/matches" leagueCode

        async {
            let! resp =
                Http.AsyncRequest (url, ["season", sprintf "%d" season], ["X-Auth-Token", token])

            return
                match resp.StatusCode with
                | SuccessCode ->
                    convertJsonBody<LeagueDto> resp.Body
                | _ -> None
        }