
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class HotelManagementAdmin
    Inherits System.Web.UI.Page
    Dim addflag As Boolean = False

    'binding repeater with records of db
    Private Sub hotelmanagementadmin_load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.bindrepeater()
        End If

        'Populating DropdownList in BindLocation
        If Not Me.IsPostBack Then
            BindLocation()
        End If

    End Sub

    'Populating DropDownList
    Private Sub BindLocation()
        Dim conn As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString
        Using con As New SqlConnection(conn)

            Using cmd As New SqlCommand("SELECT DISTINCT Hotel_Add FROM Hotel")
                cmd.CommandType = CommandType.Text
                cmd.Connection = con

                Using sda As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet()
                    sda.Fill(ds)
                    ddlHotelAdd.DataSource = ds.Tables(0)
                    ddlHotelAdd.DataTextField = "Hotel_Add"
                    ddlHotelAdd.DataBind()
                End Using

            End Using

        End Using

        ddlHotelAdd.Items.Insert(0, New ListItem("All", ""))

    End Sub

    'Filter Hotel By Location
    Protected Sub ddlHotelAdd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlHotelAdd.SelectedIndexChanged
        Dim dt As New DataTable()
        Dim constr2 As String = ConfigurationManager.ConnectionStrings("connectionstringlocal").ConnectionString
        Using conne As New SqlConnection(constr2)

            conne.Open()

            If ddlHotelAdd.SelectedValue <> "" Then
                Dim cmd As New SqlCommand("SELECT * FROM Hotel WHERE Hotel_Add = @H_AddFilter", conne)
                cmd.Parameters.AddWithValue("@H_AddFilter", ddlHotelAdd.SelectedValue)

                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                Dim cmd2 As New SqlCommand("SELECT * FROM Hotel", conne)
                Dim da2 As New SqlDataAdapter(cmd2)
                da2.Fill(dt)
            End If

            conne.Close()
            Repeater1.DataSource = dt
            Repeater1.DataBind()


        End Using

    End Sub

    Private Sub bindrepeater()
        Dim constr As String = ConfigurationManager.ConnectionStrings("connectionstringlocal").ConnectionString

        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("hotelselect")
                cmd.Parameters.AddWithValue("@action", "select")

                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = con
                    sda.SelectCommand = cmd

                    Using dt As New DataTable()
                        sda.Fill(dt)
                        Repeater1.DataSource = dt
                        Repeater1.DataBind()
                    End Using
                End Using
            End Using
        End Using

    End Sub

    'inserting records to repeater
    Protected Sub Insert(sender As Object, e As EventArgs) Handles btnAdd.Click
        Response.Redirect("~/AddEditHotelAdmin.aspx")

        Me.bindrepeater()
    End Sub

    Protected Sub OnDelete(sender As Object, e As EventArgs)
        'Find the reference of the repeater item
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim hotelId As Integer = Integer.Parse(TryCast(item.FindControl("lblHotel_ID"), Label).Text)

        Dim constr As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("HotelDelete")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Hotel_ID", hotelId)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
        Me.bindrepeater()
    End Sub
    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        If e.CommandName = "EditCommand" Then
            Response.Redirect("~/AddEditHotelAdmin.aspx?id=" & e.CommandArgument)
        End If
    End Sub

End Class

