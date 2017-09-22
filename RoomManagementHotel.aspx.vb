
Imports System.Data
Imports System.Data.SqlClient

Partial Class RoomManagementHotel
    Inherits System.Web.UI.Page

    Private Sub RoomManagementHotel_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.BindRepeater()
        End If
    End Sub

    Private Sub BindRepeater()
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString

        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("RoomSelect")
                cmd.Parameters.AddWithValue("@Action", "SELECT")

                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = con
                    sda.SelectCommand = cmd

                    Using dt As New DataTable()
                            sda.Fill(dt)
                            RepeaterRoom.DataSource = dt
                            RepeaterRoom.DataBind()
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Protected Sub Insert(sender As Object, e As EventArgs) Handles btnAddRoom.Click
        Response.Redirect("~/AddEditRoom.aspx")
    End Sub

    Protected Sub OnDelete(sender As Object, e As EventArgs)
        'Find the reference of the repeater item
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim user_ID As Integer = Integer.Parse(TryCast(item.FindControl("lblID"), Label).Text)

        Dim constr As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("UserDelete")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@UserID", user_ID)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
        Me.BindRepeater()
    End Sub
    Protected Sub RepeaterRoom_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles RepeaterRoom.ItemCommand
        If e.CommandName = "EditCommand" Then

            Response.Redirect("~/AddEditRoom.aspx?id=" & e.CommandArgument)
        End If
    End Sub
End Class
