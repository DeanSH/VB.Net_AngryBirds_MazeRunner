'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class character
    Public Property char_id As Integer
    Public Property char_name As String

    Public Overridable Property gameplayers As ICollection(Of gameplayer) = New HashSet(Of gameplayer)

End Class
