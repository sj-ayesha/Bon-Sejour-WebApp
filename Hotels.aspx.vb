
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Hotels
    Inherits System.Web.UI.Page
    Private Sub Hotels_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            'bindHotelImg()
            Dim constr As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString
            Dim dt As New DataTable()
            Dim conn As New SqlConnection(constr)

            Using conn
                Dim ad As New SqlDataAdapter("SELECT * FROM Hotel", conn)
                ad.Fill(dt)
            End Using

            listviewHotel.DataSource = dt
            listviewHotel.DataBind()

        End If


    End Sub

    Private Sub listviewHotel_ItemCommand(sender As Object, e As ListViewCommandEventArgs) Handles listviewHotel.ItemCommand
        If e.CommandName = "HotelNameCommand" Then
            Response.Redirect("~/Room.aspx?id=" & e.CommandArgument)
        End If
    End Sub
End Class
