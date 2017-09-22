
Partial Class BSMasterPageAdmin
    Inherits System.Web.UI.MasterPage
    Protected Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Session("USERNAME") = Nothing
        Response.Redirect("~/Default.aspx")
    End Sub
End Class

