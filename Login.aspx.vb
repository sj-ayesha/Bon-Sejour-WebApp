
Imports System.Data
Imports System.Data.SqlClient

Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim Utype As String

        Dim conStr As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString
        Using con As New SqlConnection(conStr)
            Dim cmd As New SqlCommand("SELECT * FROM UserTable WHERE Username= '" + txtUname.Text + "' AND UserPassword = '" + txtPass.Text + "' AND Ustatus='Active'", con)

            con.Open()

            Dim sda As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            sda.Fill(dt)

            If dt.Rows.Count <> 0 Then


                Utype = dt.Rows(0)(10).ToString().Trim()
                'Ustatus = dt.Rows(0)(11).ToString().Trim()

                If Utype = "Client" Then
                    Session("USERNAME") = txtUname.Text
                    Session("USERID") = dt.Rows(0).Item("UserID")
                    Response.Redirect("~/UserHome.aspx")

                ElseIf Utype = "Admin" Then
                    Session("USERNAME") = txtUname.Text
                    Response.Redirect("~/DashBoardAdmin.aspx")

                ElseIf Utype = "Hotel" Then
                    Session("USERNAME") = txtUname.Text
                    Response.Redirect("~/DashBoardHotel.aspx")

                End If


            Else
                lblError.Text = "Invalid Username or Password!"
            End If
        End Using
    End Sub
End Class
