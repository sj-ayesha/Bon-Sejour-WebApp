
Imports System.Data
Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim conStr As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString
        Using con As New SqlConnection(conStr)
            Dim ImgPath As String = "~/UploadImages/"

            Dim sda As New SqlDataAdapter("SELECT H_Image FROM Hotel", con)
            Dim dt As New DataTable()

            sda.Fill(dt)
            imgLeMeridien.ImageUrl = ImgPath + dt.Rows(0)("H_Image").ToString()
            imgHilton.ImageUrl = ImgPath + dt.Rows(1)("H_Image").ToString()
            imgTamassa.ImageUrl = ImgPath + dt.Rows(2)("H_Image").ToString()
        End Using
    End Sub
    Protected Sub View_Click(sender As Object, e As EventArgs) Handles View.Click
        Response.Redirect("~/Hotels.aspx")
    End Sub
End Class
