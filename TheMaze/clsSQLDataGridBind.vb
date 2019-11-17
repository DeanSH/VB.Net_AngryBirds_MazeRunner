Imports System.Data.Entity
Imports Microsoft.Win32.SafeHandles
Imports System.Runtime.InteropServices

Public Class clsSQLDataGridBind : Implements IDisposable

    Private aDb As angrybirds3Entities = New angrybirds3Entities()
    Private aDb2 As angrybirds3Entities = New angrybirds3Entities()
    Private aDb3 As angrybirds3Entities = New angrybirds3Entities()

#Region "PlayersList"
    Private lcPlayersBindingSource As BindingSource
    Private lcPlayers As DbSet(Of player)
    Private Function lPlayersList() As BindingSource 'List(Of tblplayer)
        ' Make a fresh connection
        aDb.SaveChanges() ' Make sure we saved any changes
        aDb.Dispose() 'Going for a new connection/fresh, get rid of this one
        aDb = New angrybirds3Entities()

        lcPlayers = aDb.players '' should get fresh players
        lcPlayers.Load() ' using a DBSet 

        ' Set up Data binding source, binding DBSet with Binding
        If (lcPlayersBindingSource IsNot Nothing) Then
            lcPlayersBindingSource.Dispose()
        End If

        lcPlayersBindingSource = New BindingSource() ' Here
        lcPlayersBindingSource.DataSource = lcPlayers.Local


        Return lcPlayersBindingSource ' This is then passed to the Control's DataSource
    End Function

    Private Sub upDatePlayersList(pPlayersList As BindingSource) 'List(Of tblplayer))
        ' Probably could be a bit more careful here.
        aDb.SaveChanges()

    End Sub

    'Public ReadOnly 
    Public Property PlayersBinding() As BindingSource
        Get
            Return lPlayersList()

        End Get
        Set(ByVal Value As BindingSource)
            upDatePlayersList(Value)
        End Set
    End Property
#End Region

#Region "GamesList"
    Private lcPlayersBindingSource2 As BindingSource
    Private lcPlayers2 As DbSet(Of game)
    Private Function lGamesList() As BindingSource 'List(Of tblplayer)
        ' Make a fresh connection
        aDb2.SaveChanges() ' Make sure we saved any changes
        aDb2.Dispose() 'Going for a new connection/fresh, get rid of this one
        aDb2 = New angrybirds3Entities()

        lcPlayers2 = aDb2.games '' should get fresh players
        lcPlayers2.Load() ' using a DBSet 

        ' Set up Data binding source, binding DBSet with Binding
        If (lcPlayersBindingSource2 IsNot Nothing) Then
            lcPlayersBindingSource2.Dispose()
        End If

        lcPlayersBindingSource2 = New BindingSource() ' Here
        lcPlayersBindingSource2.DataSource = lcPlayers2.Local


        Return lcPlayersBindingSource2 ' This is then passed to the Control's DataSource
    End Function

    Private Sub upDateGamesList(pPlayersList As BindingSource) 'List(Of tblplayer))
        ' Probably could be a bit more careful here.
        aDb2.SaveChanges()

    End Sub

    'Public ReadOnly 
    Public Property GamesBinding() As BindingSource
        Get
            Return lGamesList()

        End Get
        Set(ByVal Value As BindingSource)
            upDateGamesList(Value)
        End Set
    End Property
#End Region

#Region "GamePlayersList"
    Private lcPlayersBindingSource3 As BindingSource
    Private lcPlayers3 As DbSet(Of gameplayer)
    Private Function lGPlayersList() As BindingSource 'List(Of tblplayer)
        ' Make a fresh connection
        aDb3.SaveChanges() ' Make sure we saved any changes
        aDb3.Dispose() 'Going for a new connection/fresh, get rid of this one
        aDb3 = New angrybirds3Entities()

        lcPlayers3 = aDb3.gameplayers '' should get fresh players
        lcPlayers3.Load() ' using a DBSet 

        ' Set up Data binding source, binding DBSet with Binding
        If (lcPlayersBindingSource3 IsNot Nothing) Then
            lcPlayersBindingSource3.Dispose()
        End If

        lcPlayersBindingSource3 = New BindingSource() ' Here
        lcPlayersBindingSource3.DataSource = lcPlayers3.Local


        Return lcPlayersBindingSource3 ' This is then passed to the Control's DataSource
    End Function

    Private Sub upDateGPlayersList(pPlayersList As BindingSource) 'List(Of tblplayer))
        ' Probably could be a bit more careful here.
        aDb3.SaveChanges()

    End Sub

    'Public ReadOnly 
    Public Property GPlayersBinding() As BindingSource
        Get
            Return lGPlayersList()

        End Get
        Set(ByVal Value As BindingSource)
            upDateGPlayersList(Value)
        End Set
    End Property
#End Region

    Public Sub SaveChanges()
        aDb.SaveChanges()
        aDb2.SaveChanges()
        aDb3.SaveChanges()
    End Sub

#Region "IDisposable Support"
    ' IDisposable attributes
    '-----------------------
    ' Flag: Has Dispose already been called?
    Dim disposed As Boolean = False
    ' Instantiate a SafeHandle instance.
    Dim handle As SafeHandle = New SafeFileHandle(IntPtr.Zero, True)
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then

            If disposing Then
                ' TODO: dispose managed state (managed objects).
                lcPlayersBindingSource.Dispose()
                'aDb.Dispose()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub


#End Region
End Class