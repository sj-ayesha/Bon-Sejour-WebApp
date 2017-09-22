
Partial Class DashBoardHotel
    Inherits System.Web.UI.Page

    Protected Sub imgbtnRoom_Click(sender As Object, e As ImageClickEventArgs) Handles imgbtnRoom.Click
        Response.Redirect("~/RoomManagementHotel.aspx")
    End Sub

    Private Sub imgbtnBooking_Click(sender As Object, e As ImageClickEventArgs) Handles imgbtnBooking.Click
        Response.Redirect("~/BookingManagement.aspx")
    End Sub

    Private Sub lnkbtnBooking_Click(sender As Object, e As EventArgs) Handles lnkbtnBooking.Click
        Response.Redirect("~/BookingManagement.aspx")
    End Sub

    Private Sub lnkbtnRoom_Click(sender As Object, e As EventArgs) Handles lnkbtnRoom.Click
        Response.Redirect("~/RoomManagementHotel.aspx")
    End Sub


End Class
