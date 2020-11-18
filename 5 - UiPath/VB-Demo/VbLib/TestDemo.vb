Imports System.IO

Public Class TestDemo
    Public Sub GetFullName(firstName As String, middleName As String, lastName As String)
        If middleName IsNot "" Or middleName IsNot Nothing Then
            Console.WriteLine($"{firstName} {middleName} {lastName}")
        Else
            Console.WriteLine($"{firstName} {lastName}")
        End If
    End Sub
    Public Function LoadFile() As List(Of String)
        Dim output As List(Of String) = New List(Of String)
        Dim lines As List(Of String) = File.ReadAllLines("text.txt").ToList()
        For i = 0 To lines.Count - 1
            If i Mod 2 = 0 Then
                output.Add(lines(i))
            End If
        Next
        Return output
    End Function
End Class
