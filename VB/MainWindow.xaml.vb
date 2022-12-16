Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents

Namespace DynamicComboBoxItemsSource

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Dim list As List(Of TestData) = New List(Of TestData)()
            For i As Integer = 0 To 10 - 1
                list.Add(New TestData() With {.Text = "Row" & i, .Number = i})
            Next

            Me.grid.ItemsSource = list
        End Sub

        Private Sub PART_Editor_PopupOpening(ByVal sender As Object, ByVal e As RoutedEventArgs)
        End Sub
    End Class

    Public Class TestData

        Public Property Text As String

        Public Property Number As Integer
    End Class

    Public Class TextToItemsSourceConverter
        Implements IValueConverter

'#Region "IValueConverter Members"
        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
            Dim list As List(Of TestData) = New List(Of TestData) From {New TestData() With {.Text = "Text0", .Number = 0}, New TestData() With {.Text = "Text1", .Number = 1}, New TestData() With {.Text = "Text2", .Number = 2}, New TestData() With {.Text = "Text3", .Number = 3}, New TestData() With {.Text = "Text4", .Number = 4}, New TestData() With {.Text = "Text5", .Number = 5}, New TestData() With {.Text = "Text6", .Number = 6}, New TestData() With {.Text = "Text7", .Number = 7}, New TestData() With {.Text = "Text8", .Number = 8}, New TestData() With {.Text = "Text9", .Number = 9}, New TestData() With {.Text = "Text10", .Number = 10}}
            Dim text As String = TryCast(value, String)
            If String.IsNullOrEmpty(text) Then Return list
            If Equals(text, "Row0") Then list.RemoveRange(1, 2)
            If Equals(text, "Row3") Then list.RemoveRange(4, 3)
            Return list
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
'#End Region
    End Class
End Namespace
