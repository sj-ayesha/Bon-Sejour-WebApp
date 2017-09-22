
Imports System.Data
Imports System.Data.SqlClient

Partial Class RegistrationAdmin
    Inherits System.Web.UI.Page
    Dim addflag As Boolean = False

    Private con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString())
    Private cmd As New SqlCommand

    Private Sub RegistrationAdmin_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Request.QueryString("id") Is Nothing Then

                btnRegister.Text = "Register"

            Else

                lblPass.Visible = False
                txtpass.Visible = False

                lblConfPass.Visible = False
                passConfirm.Visible = False

                btnRegister.Text = "Update User"
                LoadUserByID()
            End If
        End If
    End Sub

    Private Sub LoadUserByID()
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString)
            Using cmd As New SqlCommand("LoadUserByID", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Request.QueryString("id")

                con.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader()

                While (reader.Read())
                    ddlTitle.Text = reader(1)
                    Lname.Text = reader(2)
                    txtOname.Text = reader(3)
                    Gender.SelectedValue = reader(4)
                    txtPhone.Text = reader(5)
                    Add.Text = reader(6)
                    eAdd.Text = reader(7)
                    txtUsername.Text = reader(8)
                    ddlTypeUser.Text = reader(11).ToString()
                    ddlstatus.Text = reader(12).ToString()
                End While

            End Using
        End Using
    End Sub


    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If btnRegister.Text = "Update User" Then
            UpdateUser()
        Else
            AddUser()
        End If


        Response.Redirect("~/UserManagementAdmin.aspx")
    End Sub

    Private Sub UpdateUser()
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString)
            Using cmd2 As New SqlCommand("UpdateUser", con)
                cmd2.CommandType = CommandType.StoredProcedure

                cmd2.Parameters.Add("@UserID", SqlDbType.Int).Value = Request.QueryString("id")
                cmd2.Parameters.Add("@Title", SqlDbType.NVarChar, 255).Value = ddlTitle.SelectedItem.Text
                cmd2.Parameters.Add("@LastName", SqlDbType.NVarChar, 255).Value = Lname.Text
                cmd2.Parameters.Add("@OtherName", SqlDbType.NVarChar, 255).Value = txtOname.Text
                cmd2.Parameters.Add("@Gender", SqlDbType.NVarChar, 255).Value = Gender.SelectedItem.Text
                cmd2.Parameters.Add("@PhoneNum", SqlDbType.NVarChar, 255).Value = txtPhone.Text
                cmd2.Parameters.Add("@UAddress", SqlDbType.NVarChar, 255).Value = Add.Text
                cmd2.Parameters.Add("@EmailAdd", SqlDbType.NVarChar, 255).Value = eAdd.Text
                cmd2.Parameters.Add("@Username", SqlDbType.NVarChar, 255).Value = txtUsername.Text
                cmd2.Parameters.Add("@TypeUser", SqlDbType.NVarChar, 255).Value = ddlTypeUser.SelectedItem.Text
                cmd2.Parameters.Add("@Ustatus", SqlDbType.NVarChar, 255).Value = ddlstatus.SelectedItem.Text

                con.Open()
                cmd2.ExecuteNonQuery()

            End Using
        End Using
    End Sub

    Private Sub AddUser()
        If addflag = False Then
            Try
                cmd.Connection = con
                con.Open()

                cmd.CommandText = "INSERT INTO UserTable(Title, LastName, OtherName, Gender, PhoneNum, UAddress, EmailAdd, Username, UserPassword, TypeUser) values (@Title, @LastName, @OtherName, @Gender, @PhoneNum, @UAddress, @EmailAdd, @Username, @UserPassword, @TypeUser)"

                cmd.Parameters.AddWithValue("@Title", ddlTitle.SelectedItem.Text.ToString())
                cmd.Parameters.AddWithValue("@LastName", Lname.Text.ToString())
                cmd.Parameters.AddWithValue("@OtherName", txtOname.Text.ToString())
                cmd.Parameters.AddWithValue("@Gender", Gender.SelectedItem.Text.ToString())
                cmd.Parameters.AddWithValue("@PhoneNum", txtPhone.Text.ToString())
                cmd.Parameters.AddWithValue("@UAddress", Add.Text.ToString())
                cmd.Parameters.AddWithValue("@EmailAdd", eAdd.Text.ToString())
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text.ToString())
                cmd.Parameters.AddWithValue("@UserPassword", txtpass.Text.ToString())
                cmd.Parameters.AddWithValue("@TypeUser", ddlTypeUser.SelectedItem.Text.ToString())

                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()

                con.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub


End Class
