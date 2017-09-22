
Imports System.Data
Imports System.Data.SqlClient

Partial Class UserManagementAdmin
    Inherits System.Web.UI.Page


    Private Sub UserManagementAdmin_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            Me.BindRepeater()
        End If

        'Populating DropdownList in BindType
        If Not Me.IsPostBack Then
            BindType()
        End If

    End Sub

    'Populating DrodownList TypeUser
    Private Sub BindType()
        Dim conn As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString
        Using con As New SqlConnection(conn)

            Using cmd As New SqlCommand("SELECT DISTINCT TypeUser FROM UserTable")
                cmd.CommandType = CommandType.Text
                cmd.Connection = con

                Using sda As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet()
                    sda.Fill(ds)
                    ddlType.DataSource = ds.Tables(0)
                    ddlType.DataTextField = "TypeUser"
                    ddlType.DataBind()
                End Using

            End Using

        End Using

        ddlType.Items.Insert(0, New ListItem("All", ""))
    End Sub

    'Filter User by Type
    Protected Sub ddlType_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim dt As New DataTable()
        Dim constr2 As String = ConfigurationManager.ConnectionStrings("connectionstringlocal").ConnectionString
        Using conne As New SqlConnection(constr2)

            conne.Open()

            If ddlType.SelectedValue <> "" Then
                Dim cmd As New SqlCommand("SELECT * FROM UserTable WHERE TypeUser = @TypeUserFilter", conne)
                cmd.Parameters.AddWithValue("@TypeUserFilter", ddlType.SelectedValue)

                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                Dim cmd2 As New SqlCommand("SELECT * FROM UserTable", conne)
                Dim da2 As New SqlDataAdapter(cmd2)
                da2.Fill(dt)
            End If

            conne.Close()
            RepeaterUser.DataSource = dt
            RepeaterUser.DataBind()


        End Using
    End Sub

    Private Sub BindRepeater()
        Dim constr As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString

        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("UserSelect")
                cmd.Parameters.AddWithValue("@Action", "SELECT")

                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = con
                    sda.SelectCommand = cmd

                    Using dt As New DataTable()
                        sda.Fill(dt)
                        RepeaterUser.DataSource = dt
                        RepeaterUser.DataBind()
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Protected Sub Insert(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Response.Redirect("~/RegistrationEditAdmin.aspx")
        Me.BindRepeater()
    End Sub

    Protected Sub OnDelete(sender As Object, e As EventArgs)
        'Find the reference of the repeater item
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim user_ID As Integer = Integer.Parse(TryCast(item.FindControl("lblUserID"), Label).Text)

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

    Protected Sub RepeaterUser_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles RepeaterUser.ItemCommand
        If e.CommandName = "EditCommand" Then
            Response.Redirect("~/RegistrationEditAdmin.aspx?id=" & e.CommandArgument)
        End If
    End Sub

    Protected Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        Dim dt As New DataTable()
        Dim constring As String = ConfigurationManager.ConnectionStrings("connectionstringlocal").ConnectionString
        Using con As New SqlConnection(constring)

            con.Open()

            If txtUsername.Text <> "" Then
                Dim cmd As New SqlCommand("SELECT * FROM UserTable WHERE Username LIKE @UsernameFilter", con)
                cmd.Parameters.AddWithValue("@UsernameFilter", "%" + txtUsername.Text + "%")

                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                Dim cmd2 As New SqlCommand("SELECT * FROM UserTable", con)
                Dim da2 As New SqlDataAdapter(cmd2)
                da2.Fill(dt)
            End If

            'Using sda As New SqlDataAdapter("SELECT UserID, Title, LastName, OtherName, Gender, PhoneNum, UAddress, EmailAdd, Username, TypeUser FROM UserTable WHERE Username LIKE'" + txtUsername.Text + "%'", con)
            '    Using data As New DataTable()
            '        sda.Fill(data)
            '        RepeaterUser.DataSource = data
            '        RepeaterUser.DataBind()

            '    End Using
            'End Using

            con.Close()

            RepeaterUser.DataSource = dt
            RepeaterUser.DataBind()
        End Using
    End Sub
End Class
