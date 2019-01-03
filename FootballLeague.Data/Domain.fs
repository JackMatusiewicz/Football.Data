namespace FootballLeague.Data

open System

type ApiToken = Token of string

type League =
    | PremierLeague
    | Championship

type SeasonDto =
    {
        id : int
        startDate : DateTime
        endDate : DateTime
        currentMatchday : int
    }

type ScorePairDto =
    {
        homeTeam : Nullable<int>
        awayTeam : Nullable<int>
    }

type ScoreDto =
    {
        winner : string
        duration : string
        fullTime : ScorePairDto
        halfTime : ScorePairDto
        extraTime : ScorePairDto
        penalties : ScorePairDto
    }

type TeamDto =
    {
        id : int
        name : string
    }

type RefereeDto =
    {
        id : int
        name : string
    }

type MatchDto =
    {
        id : int
        season : SeasonDto
        utcDate : DateTime
        matchday : Nullable<int>
        stage : string
        group : string
        lastUpdated : DateTime
        score : ScoreDto
        homeTeam : TeamDto
        awayTeam : TeamDto
        referees : RefereeDto array
    }

type AreaDto =
    {
        id : int
        name : string
    }

type CompetitionDto =
    {
        id : int
        area : AreaDto
        name : string
        code : string
        plan : string
        lastUpdated : DateTime
    }

type LeagueDto =
    {
        count : int
        comptetion : CompetitionDto
        matches : MatchDto array
    }