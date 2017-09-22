
Imports System.Data
Imports System.Data.SqlClient

Partial Class CheckOutSummary
    Inherits System.Web.UI.Page


    Private con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString())
    Private cmd As New SqlCommand
    Private cmd1 As New SqlCommand
    Private rdr As SqlDataReader

    Private Sub CheckOutSummary_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.BindRepeaterCart()
        End If
    End Sub

    Private Sub BindRepeaterCart()
        Dim constr As String = ConfigurationManager.ConnectionStrings("connectionstringlocal").ConnectionString

        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("CartSelect")
                cmd.Parameters.AddWithValue("@ACTION", "SELECT")
                cmd.Parameters.AddWithValue("@UID", SqlDbType.Int).Value = Session("USERID")

                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = con
                    sda.SelectCommand = cmd

                    Using dt As New DataTable()
                        sda.Fill(dt)
                        RepeaterCart.DataSource = dt

                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            RepeaterCart.DataBind()
                        Else
                            RepeaterCart.Visible = False
                        End If

                    End Using
                End Using
            End Using
        End Using
    End Sub

    Protected Sub lnkDelete_Click(sender As Object, e As EventArgs)
        Dim item As RepeaterItem = TryCast(TryCast(sender, LinkButton).Parent, RepeaterItem)
        Dim cid As Integer = Integer.Parse(TryCast(item.FindControl("lblCID"), Label).Text)

        Dim constr As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("CartDelete")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@CID", cid)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
        Me.BindRepeaterCart()
    End Sub
    Protected Sub btnCheckOut_Click(sender As Object, e As EventArgs)
        Dim RID As String
        Try
            'cmd.Connection = con
            cmd1.Connection = con
            con.Open()

            'For Each ri As RepeaterItem In RepeaterCart.Items

            '    cmd.Connection = con
            '    con.Open()

            '    Dim lblHotelID As Label = DirectCast(ri.FindControl("lblHotel_ID"), Label)
            '    Dim lblTypeRoomID As Label = DirectCast(ri.FindControl("lblTypeRoomID"), Label)
            '    Dim lblCIn As Label = DirectCast(ri.FindControl("lblCIn"), Label)
            '    Dim lblCOut As Label = DirectCast(ri.FindControl("lblCOut"), Label)
            '    Dim lblNumP As Label = DirectCast(ri.FindControl("lblNumP"), Label)
            '    Dim lblPrice As Label = DirectCast(ri.FindControl("lblPrice"), Label)

            '    Dim HotelIDTxt As String = lblHotelID.Text
            '    Dim TypeRoomIDTxt As String = lblTypeRoomID.Text
            '    Dim CInTxt As String = lblCIn.Text
            '    Dim COutTxt As String = lblCOut.Text
            '    Dim NumPTxt As Integer = lblNumP.Text
            '    Dim PriceTxt As Integer = lblPrice.Text

            '    cmd.CommandText = "INSERT INTO ReservationTable(room_ID, UserID,CheckInDate, CheckOutDate, NumPerson) values ((SELECT room_ID FROM RoomTable WHERE roomType_ID = @rt AND Hotel_ID = @HID), @UID, @CIN, @COUT, @numP) SELECT Reserv_ID FROM ReservationTable WHERE Reserv_ID = SCOPE_IDENTITY()"

            '    cmd.Parameters.AddWithValue("@rt", TypeRoomIDTxt)
            '    cmd.Parameters.AddWithValue("@HID", HotelIDTxt)
            '    cmd.Parameters.AddWithValue("@CIN", CInTxt)
            '    cmd.Parameters.AddWithValue("@COUT", COutTxt)
            '    cmd.Parameters.AddWithValue("@numP", NumPTxt)
            '    cmd.Parameters.AddWithValue("@UID", Session("USERID"))

            '    RID = rdr(0).ToString()
            '    rdr.Close()
            '    cmd.Parameters.Clear()


            '    cmd.ExecuteNonQuery()
            '    cmd.Parameters.Clear()
            '    con.Close()


            '    cmd1.Connection = con
            '    con.Open()
            '    cmd1.CommandText = "INSERT INTO PaymentTable(Payment, Reserv_ID) values (@Pay, @RID)"
            '    cmd1.Parameters.AddWithValue("@Pay", PriceTxt)
            '    cmd1.Parameters.AddWithValue("@RID", RID)

            '    cmd1.ExecuteNonQuery()
            '    con.Close()

            '    'cmd1.CommandText = "INSERT INTO ReservationTable(room_ID, UserID,CheckInDate, CheckOutDate, NumPerson) values ((SELECT room_ID FROM RoomTable WHERE roomType_ID = @rt AND Hotel_ID = @HID), 18, @CIN, @COUT, @numP) SELECT Reserv_ID FROM ReservationTable WHERE Reserv_ID = SCOPE_IDENTITY()"

            'Next


            cmd.CommandText = "DELETE FROM Cart WHERE UID=@UID"

            cmd.Parameters.AddWithValue("@UID", Session("USERID"))

            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            con.Close()
        Catch ex As Exception

        End Try

        Response.Redirect("~/ThankYou.aspx")


    End Sub
    Protected Sub btnContinue_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/Hotels.aspx")
    End Sub
End Class
