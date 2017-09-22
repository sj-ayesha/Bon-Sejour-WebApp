
Partial Class BSMasterPageHotel
    Inherits System.Web.UI.MasterPage

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Session("USERNAME") = Nothing
        Response.Redirect("~/Default.aspx")
    End Sub
End Class

