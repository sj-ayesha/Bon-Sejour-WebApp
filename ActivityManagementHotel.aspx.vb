
Imports System.Data
Imports System.Data.SqlClient

Partial Class ActivityManagementHotel
    Inherits System.Web.UI.Page

    Private Sub ActivityManagementHotel_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.BindRepeaterActivity()
        End If
    End Sub

    Private Sub BindRepeaterActivity()
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString

        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("ActivitySelect")
                cmd.Parameters.AddWithValue("@Action", "SELECT")

                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = con
                    sda.SelectCommand = cmd

                    Using dt As New DataTable()
                        sda.Fill(dt)
                        RepeaterActivity.DataSource = dt
                        RepeaterActivity.DataBind()
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Protected Sub Insert(sender As Object, e As EventArgs) Handles btnAddActivity.Click
        Response.Redirect("~/AddEditActivity.aspx")
    End Sub

    Protected Sub RepeaterActivity_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles RepeaterActivity.ItemCommand
        If e.CommandName = "EditCommand" Then

            Response.Redirect("~/AddEditActivity.aspx?id=" & e.CommandArgument)
        End If
    End Sub
End Class
