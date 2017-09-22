
Partial Class DefaultAdmin
    Inherits System.Web.UI.Page

    Protected Sub imgbtnHotel_Click(sender As Object, e As ImageClickEventArgs) Handles imgbtnHotel.Click
        Response.Redirect("~/HotelManagementAdmin.aspx")
    End Sub
    Protected Sub imgbtnUser_Click(sender As Object, e As ImageClickEventArgs) Handles imgbtnUser.Click
        Response.Redirect("~/UserManagementAdmin.aspx")
    End Sub

    Private Sub lnkbtnHotel_Click(sender As Object, e As EventArgs) Handles lnkbtnHotel.Click
        Response.Redirect("~/HotelManagementAdmin.aspx")
    End Sub

    Private Sub lnkbtnUser_Click(sender As Object, e As EventArgs) Handles lnkbtnUser.Click
        Response.Redirect("~/UserManagementAdmin.aspx")
    End Sub
End Class
