
Partial Class BookingManagement
    Inherits System.Web.UI.Page

    Private Sub BookingManagement_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.BindRepeaterBooking()
        End If
    End Sub

    Private Sub BindRepeaterBooking()

    End Sub
End Class
