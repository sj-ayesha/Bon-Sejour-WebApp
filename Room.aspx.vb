
Imports System.Data
Imports System.Data.SqlClient

Partial Class Room
    Inherits System.Web.UI.Page

    Private con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString())
    Private cmd As New SqlCommand
    'Dim RoomImg As Image
    'Dim lblType As Label
    'Dim lblPrice As Label




    Private Sub Room_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            'For Each item As ListViewItem In listviewRoom.Items
            '    RoomImg = DirectCast(item.FindControl("RoomImg"), Image)
            '    lblType = DirectCast(item.FindControl("lblType"), Label)
            '    lblPrice = DirectCast(item.FindControl("lblType"), Label)

            '    If lblType IsNot Nothing Then
            '        Response.Write(lblType.Text)
            '    End If

            '    If lblPrice IsNot Nothing Then
            '        Response.Write(lblPrice.Text)
            '    End If
            'Next

            If Request.QueryString("id") IsNot Nothing Then
                LoadRoomByHotelID()
            End If
        End If
    End Sub

    Private Sub LoadRoomByHotelID()
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString)
            Using cmd As New SqlCommand("LoadRoomByHotelID", con)

                Using sda As New SqlDataAdapter()

                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@H_ID", SqlDbType.Int).Value = Request.QueryString("id")

                    sda.SelectCommand = cmd

                    Using dt As New DataTable()
                        sda.Fill(dt)
                        listviewRoom.DataSource = dt
                        listviewRoom.DataBind()
                    End Using
                End Using

                '    con.Open()

                'Dim reader As SqlDataReader = cmd.ExecuteReader()

                'While (reader.Read())

                '    'RoomImg.ImageUrl = reader(1)
                '    lblType.Text = reader(1)
                '    lblPrice.Text = reader(2)

                '    'txtDescri.Text = reader(2)
                '    't.Text = reader(3)
                'End While

            End Using
        End Using
    End Sub

    Private Sub listviewRoom_ItemCommand(sender As Object, e As ListViewCommandEventArgs) Handles listviewRoom.ItemCommand
        If Session("USERNAME") IsNot Nothing And e.CommandName = "BookCommand" Then
            Response.Redirect("~/Booking.aspx?id=" & e.CommandArgument)
        Else
            ErrorMsg.Text = "You should Sign In/ Sign Up to proceed with booking"
        End If
    End Sub

End Class
