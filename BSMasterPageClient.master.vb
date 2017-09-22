
Partial Class BSMasterPageClient
    Inherits System.Web.UI.MasterPage

    Private Sub BSMasterPageClient_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Session("USERNAME") Is Nothing Then
            lblWelcome.Text = "Welcome " + Session("USERNAME")
            lbtnLogIn.Text = "Sign Out"
            lbtnSignUp.Visible = False
            lbtnCart.Visible = True

        Else
            lblWelcome.Text = " "
            lbtnLogIn.Text = "Sign In"
        End If
    End Sub

    Private Sub lbtnCart_Click(sender As Object, e As EventArgs) Handles lbtnCart.Click
        Response.Redirect("~/CheckOutSummary.aspx")
    End Sub

    Private Sub lbtnLogIn_Click(sender As Object, e As EventArgs) Handles lbtnLogIn.Click
        If Not Session("USERNAME") Is Nothing Then
            Session.Remove("USERNAME")
            Response.Redirect("~/UserHome.aspx")
        Else
            Response.Redirect("~/Login.aspx")
        End If
    End Sub

    Private Sub lbtnSignUp_Click(sender As Object, e As EventArgs) Handles lbtnSignUp.Click
        Response.Redirect("~/Registration.aspx")
    End Sub


End Class

