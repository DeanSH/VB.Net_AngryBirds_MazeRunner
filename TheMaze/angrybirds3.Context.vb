﻿'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Linq

Partial Public Class angrybirds3Entities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=angrybirds3Entities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Property characters() As DbSet(Of character)
    Public Property games() As DbSet(Of game)
    Public Property gameobjects() As DbSet(Of gameobject)
    Public Property gameplayers() As DbSet(Of gameplayer)
    Public Property maps() As DbSet(Of map)
    Public Property objects() As DbSet(Of [object])
    Public Property players() As DbSet(Of player)
    Public Property ActiveGames() As DbSet(Of ActiveGame)
    Public Property MapNames() As DbSet(Of MapName)
    Public Property OnlinePlayers() As DbSet(Of OnlinePlayer)
    Public Property Top10() As DbSet(Of Top10)
    Public Property GamePlayerStats() As DbSet(Of GamePlayerStat)

    Public Overridable Function AddGameObject(pGameID As Nullable(Of Integer), pObjID As Nullable(Of Integer), pObjPos As String) As ObjectResult(Of String)
        Dim pGameIDParameter As ObjectParameter = If(pGameID.HasValue, New ObjectParameter("pGameID", pGameID), New ObjectParameter("pGameID", GetType(Integer)))

        Dim pObjIDParameter As ObjectParameter = If(pObjID.HasValue, New ObjectParameter("pObjID", pObjID), New ObjectParameter("pObjID", GetType(Integer)))

        Dim pObjPosParameter As ObjectParameter = If(pObjPos IsNot Nothing, New ObjectParameter("pObjPos", pObjPos), New ObjectParameter("pObjPos", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("AddGameObject", pGameIDParameter, pObjIDParameter, pObjPosParameter)
    End Function

    Public Overridable Function AddGamePlayer(pGameID As Nullable(Of Integer), pUserID As Nullable(Of Integer), pCharID As Nullable(Of Integer), pUserPos As String, pStartScore As Nullable(Of Integer)) As ObjectResult(Of String)
        Dim pGameIDParameter As ObjectParameter = If(pGameID.HasValue, New ObjectParameter("pGameID", pGameID), New ObjectParameter("pGameID", GetType(Integer)))

        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Dim pCharIDParameter As ObjectParameter = If(pCharID.HasValue, New ObjectParameter("pCharID", pCharID), New ObjectParameter("pCharID", GetType(Integer)))

        Dim pUserPosParameter As ObjectParameter = If(pUserPos IsNot Nothing, New ObjectParameter("pUserPos", pUserPos), New ObjectParameter("pUserPos", GetType(String)))

        Dim pStartScoreParameter As ObjectParameter = If(pStartScore.HasValue, New ObjectParameter("pStartScore", pStartScore), New ObjectParameter("pStartScore", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("AddGamePlayer", pGameIDParameter, pUserIDParameter, pCharIDParameter, pUserPosParameter, pStartScoreParameter)
    End Function

    Public Overridable Function AddGameSession(pUserID As Nullable(Of Integer), pMapName As String, pMapLayout As String) As ObjectResult(Of String)
        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Dim pMapNameParameter As ObjectParameter = If(pMapName IsNot Nothing, New ObjectParameter("pMapName", pMapName), New ObjectParameter("pMapName", GetType(String)))

        Dim pMapLayoutParameter As ObjectParameter = If(pMapLayout IsNot Nothing, New ObjectParameter("pMapLayout", pMapLayout), New ObjectParameter("pMapLayout", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("AddGameSession", pUserIDParameter, pMapNameParameter, pMapLayoutParameter)
    End Function

    Public Overridable Function AddUpdateMap(pUserID As Nullable(Of Integer), pMapName As String, pMapLayout As String) As ObjectResult(Of String)
        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Dim pMapNameParameter As ObjectParameter = If(pMapName IsNot Nothing, New ObjectParameter("pMapName", pMapName), New ObjectParameter("pMapName", GetType(String)))

        Dim pMapLayoutParameter As ObjectParameter = If(pMapLayout IsNot Nothing, New ObjectParameter("pMapLayout", pMapLayout), New ObjectParameter("pMapLayout", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("AddUpdateMap", pUserIDParameter, pMapNameParameter, pMapLayoutParameter)
    End Function

    Public Overridable Function AddUser(pUserName As String, pUserPass As String) As ObjectResult(Of String)
        Dim pUserNameParameter As ObjectParameter = If(pUserName IsNot Nothing, New ObjectParameter("pUserName", pUserName), New ObjectParameter("pUserName", GetType(String)))

        Dim pUserPassParameter As ObjectParameter = If(pUserPass IsNot Nothing, New ObjectParameter("pUserPass", pUserPass), New ObjectParameter("pUserPass", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("AddUser", pUserNameParameter, pUserPassParameter)
    End Function

    Public Overridable Function ChangePassword(pUserID As Nullable(Of Integer), pUserName As String, pNewPass As String) As ObjectResult(Of String)
        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Dim pUserNameParameter As ObjectParameter = If(pUserName IsNot Nothing, New ObjectParameter("pUserName", pUserName), New ObjectParameter("pUserName", GetType(String)))

        Dim pNewPassParameter As ObjectParameter = If(pNewPass IsNot Nothing, New ObjectParameter("pNewPass", pNewPass), New ObjectParameter("pNewPass", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("ChangePassword", pUserIDParameter, pUserNameParameter, pNewPassParameter)
    End Function

    Public Overridable Function CheckGameHasPlayers(pGameID As Nullable(Of Integer)) As ObjectResult(Of String)
        Dim pGameIDParameter As ObjectParameter = If(pGameID.HasValue, New ObjectParameter("pGameID", pGameID), New ObjectParameter("pGameID", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("CheckGameHasPlayers", pGameIDParameter)
    End Function

    Public Overridable Function CheckHighScore(pUserID As Nullable(Of Integer), pUserName As String, pScore As Nullable(Of Integer)) As ObjectResult(Of String)
        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Dim pUserNameParameter As ObjectParameter = If(pUserName IsNot Nothing, New ObjectParameter("pUserName", pUserName), New ObjectParameter("pUserName", GetType(String)))

        Dim pScoreParameter As ObjectParameter = If(pScore.HasValue, New ObjectParameter("pScore", pScore), New ObjectParameter("pScore", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("CheckHighScore", pUserIDParameter, pUserNameParameter, pScoreParameter)
    End Function

    Public Overridable Function CheckMapNameExists(pMapName As String) As ObjectResult(Of String)
        Dim pMapNameParameter As ObjectParameter = If(pMapName IsNot Nothing, New ObjectParameter("pMapName", pMapName), New ObjectParameter("pMapName", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("CheckMapNameExists", pMapNameParameter)
    End Function

    Public Overridable Function CheckOnlineStatus(pUserID As Nullable(Of Integer), pUserName As String) As ObjectResult(Of String)
        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Dim pUserNameParameter As ObjectParameter = If(pUserName IsNot Nothing, New ObjectParameter("pUserName", pUserName), New ObjectParameter("pUserName", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("CheckOnlineStatus", pUserIDParameter, pUserNameParameter)
    End Function

    Public Overridable Function DeletePlayer(pUserID As Nullable(Of Integer), pUserName As String) As ObjectResult(Of String)
        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Dim pUserNameParameter As ObjectParameter = If(pUserName IsNot Nothing, New ObjectParameter("pUserName", pUserName), New ObjectParameter("pUserName", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("DeletePlayer", pUserIDParameter, pUserNameParameter)
    End Function

    Public Overridable Function GetActiveGames() As ObjectResult(Of ActiveGame)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of ActiveGame)("GetActiveGames")
    End Function

    Public Overridable Function GetActiveGames(mergeOption As MergeOption) As ObjectResult(Of ActiveGame)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of ActiveGame)("GetActiveGames", mergeOption)
    End Function

    Public Overridable Function GetCharacterList() As ObjectResult(Of character)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of character)("GetCharacterList")
    End Function

    Public Overridable Function GetCharacterList(mergeOption As MergeOption) As ObjectResult(Of character)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of character)("GetCharacterList", mergeOption)
    End Function

    Public Overridable Function GetGameObjectStats(pGameID As Nullable(Of Integer)) As ObjectResult(Of gameobject)
        On Error Resume Next
        Dim pGameIDParameter As ObjectParameter = If(pGameID.HasValue, New ObjectParameter("pGameID", pGameID), New ObjectParameter("pGameID", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of gameobject)("GetGameObjectStats", pGameIDParameter)
    End Function

    Public Overridable Function GetGameObjectStats(pGameID As Nullable(Of Integer), mergeOption As MergeOption) As ObjectResult(Of gameobject)
        Dim pGameIDParameter As ObjectParameter = If(pGameID.HasValue, New ObjectParameter("pGameID", pGameID), New ObjectParameter("pGameID", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of gameobject)("GetGameObjectStats", mergeOption, pGameIDParameter)
    End Function

    Public Overridable Function GetGamePlayerStats(pGameID As Nullable(Of Integer)) As ObjectResult(Of GamePlayerStat)
        Dim pGameIDParameter As ObjectParameter = If(pGameID.HasValue, New ObjectParameter("pGameID", pGameID), New ObjectParameter("pGameID", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of GamePlayerStat)("GetGamePlayerStats", pGameIDParameter)
    End Function

    Public Overridable Function GetGamePlayerStats(pGameID As Nullable(Of Integer), mergeOption As MergeOption) As ObjectResult(Of GamePlayerStat)
        Dim pGameIDParameter As ObjectParameter = If(pGameID.HasValue, New ObjectParameter("pGameID", pGameID), New ObjectParameter("pGameID", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of GamePlayerStat)("GetGamePlayerStats", mergeOption, pGameIDParameter)
    End Function

    Public Overridable Function GetGamePlayerTable() As ObjectResult(Of gameplayer)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of gameplayer)("GetGamePlayerTable")
    End Function

    Public Overridable Function GetGamePlayerTable(mergeOption As MergeOption) As ObjectResult(Of gameplayer)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of gameplayer)("GetGamePlayerTable", mergeOption)
    End Function

    Public Overridable Function GetGameTable() As ObjectResult(Of game)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of game)("GetGameTable")
    End Function

    Public Overridable Function GetGameTable(mergeOption As MergeOption) As ObjectResult(Of game)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of game)("GetGameTable", mergeOption)
    End Function

    Public Overridable Function GetMapNames() As ObjectResult(Of MapName)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of MapName)("GetMapNames")
    End Function

    Public Overridable Function GetMapNames(mergeOption As MergeOption) As ObjectResult(Of MapName)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of MapName)("GetMapNames", mergeOption)
    End Function

    Public Overridable Function GetObjectList() As ObjectResult(Of [object])
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of [object])("GetObjectList")
    End Function

    Public Overridable Function GetObjectList(mergeOption As MergeOption) As ObjectResult(Of [object])
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of [object])("GetObjectList", mergeOption)
    End Function

    Public Overridable Function GetOnlinePlayers() As ObjectResult(Of OnlinePlayer)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of OnlinePlayer)("GetOnlinePlayers")
    End Function

    Public Overridable Function GetOnlinePlayers(mergeOption As MergeOption) As ObjectResult(Of OnlinePlayer)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of OnlinePlayer)("GetOnlinePlayers", mergeOption)
    End Function

    Public Overridable Function GetPlayerMapInfo(pUserID As Nullable(Of Integer), pMapName As String) As ObjectResult(Of String)
        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Dim pMapNameParameter As ObjectParameter = If(pMapName IsNot Nothing, New ObjectParameter("pMapName", pMapName), New ObjectParameter("pMapName", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("GetPlayerMapInfo", pUserIDParameter, pMapNameParameter)
    End Function

    Public Overridable Function GetPlayerTable() As ObjectResult(Of player)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of player)("GetPlayerTable")
    End Function

    Public Overridable Function GetPlayerTable(mergeOption As MergeOption) As ObjectResult(Of player)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of player)("GetPlayerTable", mergeOption)
    End Function

    Public Overridable Function GetTop10HighScores() As ObjectResult(Of Top10)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of Top10)("GetTop10HighScores")
    End Function

    Public Overridable Function GetTop10HighScores(mergeOption As MergeOption) As ObjectResult(Of Top10)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of Top10)("GetTop10HighScores", mergeOption)
    End Function

    Public Overridable Function IncreasePlayerScore(pGameID As Nullable(Of Integer), pUserID As Nullable(Of Integer)) As ObjectResult(Of String)
        Dim pGameIDParameter As ObjectParameter = If(pGameID.HasValue, New ObjectParameter("pGameID", pGameID), New ObjectParameter("pGameID", GetType(Integer)))

        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("IncreasePlayerScore", pGameIDParameter, pUserIDParameter)
    End Function

    Public Overridable Function LoginUser(pUserName As String, pUserPass As String) As ObjectResult(Of String)
        Dim pUserNameParameter As ObjectParameter = If(pUserName IsNot Nothing, New ObjectParameter("pUserName", pUserName), New ObjectParameter("pUserName", GetType(String)))

        Dim pUserPassParameter As ObjectParameter = If(pUserPass IsNot Nothing, New ObjectParameter("pUserPass", pUserPass), New ObjectParameter("pUserPass", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("LoginUser", pUserNameParameter, pUserPassParameter)
    End Function

    Public Overridable Function LogoutUser(pUserID As Nullable(Of Integer), pUserName As String) As ObjectResult(Of String)
        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Dim pUserNameParameter As ObjectParameter = If(pUserName IsNot Nothing, New ObjectParameter("pUserName", pUserName), New ObjectParameter("pUserName", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("LogoutUser", pUserIDParameter, pUserNameParameter)
    End Function

    Public Overridable Function RemoveGame(pGameID As Nullable(Of Integer)) As ObjectResult(Of String)
        Dim pGameIDParameter As ObjectParameter = If(pGameID.HasValue, New ObjectParameter("pGameID", pGameID), New ObjectParameter("pGameID", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("RemoveGame", pGameIDParameter)
    End Function

    Public Overridable Function RemoveGamePlayer(pUserID As Nullable(Of Integer)) As ObjectResult(Of String)
        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("RemoveGamePlayer", pUserIDParameter)
    End Function

    Public Overridable Function SetAdminStatus(pUserID As Nullable(Of Integer), pUserName As String, pAdmin As String) As ObjectResult(Of String)
        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Dim pUserNameParameter As ObjectParameter = If(pUserName IsNot Nothing, New ObjectParameter("pUserName", pUserName), New ObjectParameter("pUserName", GetType(String)))

        Dim pAdminParameter As ObjectParameter = If(pAdmin IsNot Nothing, New ObjectParameter("pAdmin", pAdmin), New ObjectParameter("pAdmin", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("SetAdminStatus", pUserIDParameter, pUserNameParameter, pAdminParameter)
    End Function

    Public Overridable Function SetGameObjPosition(pGameID As Nullable(Of Integer), pObjID As Nullable(Of Integer), pObjXY As String) As ObjectResult(Of String)
        Dim pGameIDParameter As ObjectParameter = If(pGameID.HasValue, New ObjectParameter("pGameID", pGameID), New ObjectParameter("pGameID", GetType(Integer)))

        Dim pObjIDParameter As ObjectParameter = If(pObjID.HasValue, New ObjectParameter("pObjID", pObjID), New ObjectParameter("pObjID", GetType(Integer)))

        Dim pObjXYParameter As ObjectParameter = If(pObjXY IsNot Nothing, New ObjectParameter("pObjXY", pObjXY), New ObjectParameter("pObjXY", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("SetGameObjPosition", pGameIDParameter, pObjIDParameter, pObjXYParameter)
    End Function

    Public Overridable Function SetGamePlayerPosition(pGameID As Nullable(Of Integer), pUserID As Nullable(Of Integer), pUserXY As String) As ObjectResult(Of GamePlayerStat)
        Dim pGameIDParameter As ObjectParameter = If(pGameID.HasValue, New ObjectParameter("pGameID", pGameID), New ObjectParameter("pGameID", GetType(Integer)))

        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Dim pUserXYParameter As ObjectParameter = If(pUserXY IsNot Nothing, New ObjectParameter("pUserXY", pUserXY), New ObjectParameter("pUserXY", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of GamePlayerStat)("SetGamePlayerPosition", pGameIDParameter, pUserIDParameter, pUserXYParameter)
    End Function

    Public Overridable Function SetGamePlayerPosition(pGameID As Nullable(Of Integer), pUserID As Nullable(Of Integer), pUserXY As String, mergeOption As MergeOption) As ObjectResult(Of GamePlayerStat)
        Dim pGameIDParameter As ObjectParameter = If(pGameID.HasValue, New ObjectParameter("pGameID", pGameID), New ObjectParameter("pGameID", GetType(Integer)))

        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Dim pUserXYParameter As ObjectParameter = If(pUserXY IsNot Nothing, New ObjectParameter("pUserXY", pUserXY), New ObjectParameter("pUserXY", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of GamePlayerStat)("SetGamePlayerPosition", mergeOption, pGameIDParameter, pUserIDParameter, pUserXYParameter)
    End Function

    Public Overridable Function SetGamePlayerScore(pGameID As Nullable(Of Integer), pUserID As Nullable(Of Integer), pScore As Nullable(Of Integer)) As ObjectResult(Of String)
        Dim pGameIDParameter As ObjectParameter = If(pGameID.HasValue, New ObjectParameter("pGameID", pGameID), New ObjectParameter("pGameID", GetType(Integer)))

        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Dim pScoreParameter As ObjectParameter = If(pScore.HasValue, New ObjectParameter("pScore", pScore), New ObjectParameter("pScore", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("SetGamePlayerScore", pGameIDParameter, pUserIDParameter, pScoreParameter)
    End Function

    Public Overridable Function SetLockedStatus(pUserID As Nullable(Of Integer), pUserName As String, pLocked As String) As ObjectResult(Of String)
        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Dim pUserNameParameter As ObjectParameter = If(pUserName IsNot Nothing, New ObjectParameter("pUserName", pUserName), New ObjectParameter("pUserName", GetType(String)))

        Dim pLockedParameter As ObjectParameter = If(pLocked IsNot Nothing, New ObjectParameter("pLocked", pLocked), New ObjectParameter("pLocked", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("SetLockedStatus", pUserIDParameter, pUserNameParameter, pLockedParameter)
    End Function

    Public Overridable Function UpdateHighScore(pUserID As Nullable(Of Integer), pUserName As String, pScore As Nullable(Of Integer)) As ObjectResult(Of String)
        Dim pUserIDParameter As ObjectParameter = If(pUserID.HasValue, New ObjectParameter("pUserID", pUserID), New ObjectParameter("pUserID", GetType(Integer)))

        Dim pUserNameParameter As ObjectParameter = If(pUserName IsNot Nothing, New ObjectParameter("pUserName", pUserName), New ObjectParameter("pUserName", GetType(String)))

        Dim pScoreParameter As ObjectParameter = If(pScore.HasValue, New ObjectParameter("pScore", pScore), New ObjectParameter("pScore", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("UpdateHighScore", pUserIDParameter, pUserNameParameter, pScoreParameter)
    End Function

End Class