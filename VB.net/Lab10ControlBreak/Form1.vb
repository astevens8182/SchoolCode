'Author: Alex Stevens
'Date: 4/3/18
'Assginment: lab 10
Option Strict On
Imports System.IO
Public Class Form1
    Dim textIn As New StreamReader(New FileStream("Books.txt", FileMode.Open, FileAccess.Read))
    Dim bookList As New List(Of Books)
    Dim textInBooks As New StreamReader(New FileStream("BookSales.txt", FileMode.Open, FileAccess.Read))
    Dim bookSalesList As New List(Of BookSales)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Do While textIn.Peek <> -1
            Dim row As String = textIn.ReadLine
            Dim columns() As String = row.Split(CChar("|"))
            Dim txtbooks As New Books
            txtbooks.BookID = columns(0)
            txtbooks.Title = columns(1)
            txtbooks.Author = columns(2)
            txtbooks.Price = Convert.ToDecimal(columns(3))
            bookList.Add(txtbooks)
        Loop
        textIn.Close()

        Do While textInBooks.Peek <> -1
            Dim row As String = textInBooks.ReadLine
            Dim columns() As String = row.Split(CChar("|"))
            Dim txtinBookSales As New BookSales
            txtinBookSales.BookIdent = columns(0)
            txtinBookSales.DateSold = Convert.ToDateTime(columns(1))
            txtinBookSales.QuantitySold = Convert.ToInt32(columns(2))
            bookSalesList.Add(txtinBookSales)
        Loop
        textInBooks.Close()

        Dim booksquery = From Books In bookList
                         Join BookSales In bookSalesList
                             On Books.BookID Equals BookSales.BookIdent
                         Order By Books.BookID Ascending, BookSales.DateSold Ascending, BookSales.QuantitySold Descending
                         Select Books.BookID, BookSales.DateSold, BookSales.QuantitySold, Books.Price

        Dim bookids As String = ""
        Dim count As Integer = 0
        Dim subTotalq As Decimal = 0
        Dim subTotalp As Decimal = 0
        Dim subTotalr As Decimal = 0

        Dim tempcount As Integer = 1
        For Each Books In booksquery
            If Books.BookID <> bookids Then
                lvBookSales.Items.Add(Books.BookID)
                bookids = Books.BookID
            Else
                lvBookSales.Items.Add("")
            End If
            lvBookSales.Items(count).SubItems.Add(Books.DateSold.ToShortDateString)
            lvBookSales.Items(count).SubItems.Add(Books.QuantitySold.ToString)
            lvBookSales.Items(count).SubItems.Add(Books.Price.ToString("c2"))
            lvBookSales.Items(count).SubItems.Add((Books.Price * Books.QuantitySold).ToString("c2"))

            count += 1







        Next

    End Sub
End Class
