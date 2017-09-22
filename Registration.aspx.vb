
Imports System.Data.SqlClient
Imports System.Data

Partial Class Registration
    Inherits System.Web.UI.Page
    Private con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString())
    Private cmd As New SqlCommand

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Try
            cmd.Connection = con

            con.Open()

            cmd.CommandText = "INSERT INTO UserTable(Title,LastName,OtherName,Gender,PhoneNum,UAddress,EmailAdd,Username, UserPassword) values (@Title, @LastName, @OtherName, @Gender, @PhoneNum, @Address, @EmailAdd, @Username, @Password)"

            cmd.Parameters.AddWithValue("@Title", ddlTitle.SelectedItem.Text.ToString())
            cmd.Parameters.AddWithValue("@LastName", Lname.Text.ToString())
            cmd.Parameters.AddWithValue("@OtherName", txtOname.Text.ToString())
            cmd.Parameters.AddWithValue("@Gender", Gender.SelectedItem.Text.ToString())
            cmd.Parameters.AddWithValue("@PhoneNum", txtPhone.Text.ToString())
            cmd.Parameters.AddWithValue("@Address", Add.Text.ToString())
            cmd.Parameters.AddWithValue("@EmailAdd", eAdd.Text.ToString())
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text.ToString())
            cmd.Parameters.AddWithValue("@Password", txtpass.Text.ToString())

            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            con.Close()

            lblMessage.Text = "Registered Successfully!"

            Response.Redirect("~/Login.aspx")

        Catch ex As Exception
            lblMessage.Text = ex.Message.ToString()
        End Try

    End Sub
End Class
