namespace Football.Data

open System
open Newtonsoft.Json

type ApiToken = ApiToken of string

type FootballLeague =
    | PremierLeague
    | Championship

type ApiError =
    {
        [<JsonProperty("errorCode")>]
        ErrorCode : int
        [<JsonProperty("message")>]
        Message : string
    }

type SeasonDto =
    {
        [<JsonProperty("id")>]
        Id : int
        [<JsonProperty("startDate")>]
        StartDate : DateTime
        [<JsonProperty("endDate")>]
        EndDate : DateTime
        [<JsonProperty("currentMatchday")>]
        CurrentMatchday : int
    }

type ScorePairDto =
    {
        [<JsonProperty("homeTeam")>]
        HomeTeam : Nullable<int>
        [<JsonProperty("awayTeam")>]
        AwayTeam : Nullable<int>
    }

type ScoreDto =
    {
        [<JsonProperty("winner")>]
        Winner : string
        [<JsonProperty("duration")>]
        Duration : string
        [<JsonProperty("fullTime")>]
        FullTime : ScorePairDto
        [<JsonProperty("halfTime")>]
        HalfTime : ScorePairDto
        [<JsonProperty("extraTime")>]
        ExtraTime : ScorePairDto
        [<JsonProperty("penalties")>]
        Penalties : ScorePairDto
    }

type TeamDto =
    {
        [<JsonProperty("id")>]
        Id : int
        [<JsonProperty("name")>]
        Name : string
    }

type RefereeDto =
    {
        [<JsonProperty("id")>]
        Id : int
        [<JsonProperty("name")>]
        Name : string
    }

type MatchDto =
    {
        [<JsonProperty("id")>]
        Id : int
        [<JsonProperty("season")>]
        Season : SeasonDto
        [<JsonProperty("utcDate")>]
        UtcDate : DateTime
        [<JsonProperty("matchday")>]
        Matchday : Nullable<int>
        [<JsonProperty("stage")>]
        Stage : string
        [<JsonProperty("group")>]
        Group : string
        [<JsonProperty("lastUpdated")>]
        LastUpdated : DateTime
        [<JsonProperty("score")>]
        Score : ScoreDto
        [<JsonProperty("homeTeam")>]
        HomeTeam : TeamDto
        [<JsonProperty("awayTeam")>]
        AwayTeam : TeamDto
        [<JsonProperty("referees")>]
        Referees : RefereeDto array
    }

type AreaDto =
    {
        [<JsonProperty("id")>]
        Id : int
        [<JsonProperty("name")>]
        Name : string
    }

type CompetitionDto =
    {
        [<JsonProperty("id")>]
        Id : int
        [<JsonProperty("area")>]
        Area : AreaDto
        [<JsonProperty("name")>]
        Name : string
        [<JsonProperty("code")>]
        Code : string
        [<JsonProperty("plan")>]
        Plan : string
        [<JsonProperty("lastUpdated")>]
        LastUpdated : DateTime
    }

type LeagueDto =
    {
        [<JsonProperty("count")>]
        Count : int
        [<JsonProperty("competition")>]
        Comptetion : CompetitionDto
        [<JsonProperty("matches")>]
        Matches : MatchDto array
    }