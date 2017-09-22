
Imports System.Data
Imports System.Data.SqlClient

Partial Class Booking
    Inherits System.Web.UI.Page
    Dim addflag As Boolean = False
    Private con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString())
    Private cmd As New SqlCommand
    Private cmd2 As New SqlCommand
    Private rdr As SqlDataReader
    Dim price, NumDays, num_of_person As Integer

    Private Sub Booking_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then


            Dim conn As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString()
                Using con As New SqlConnection(conn)
                    Dim query As String = "SELECT DISTINCT Hotel_ID, Hotel_name FROM Hotel"
                    Dim cmdquery As New SqlCommand(query)

                    cmdquery.CommandType = CommandType.Text
                    cmdquery.Connection = con

                    Using sda As New SqlDataAdapter(cmdquery)
                        Dim ds As New DataSet()
                        sda.Fill(ds)
                        ddlHotelName.DataSource = ds.Tables(0)
                        ddlHotelName.DataTextField = "Hotel_name"
                        ddlHotelName.DataValueField = "Hotel_ID"
                        ddlHotelName.DataBind()
                        'H_id = "Hotel_ID"
                    End Using

                End Using
            End If
            ddlHotelName.Items.Insert(0, New ListItem("--Select Hotel--", "0"))

        'If Not Me.IsPostBack Then
        '    Dim conn2 As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString()
        '    Using con2 As New SqlConnection(conn2)
        '        'Dim query2 As String = "SELECT DISTINCT roomType_ID, TypeRoom FROM RoomTypeTable"
        '        Dim query2 As String = "Select H.Hotel_ID, H.Hotel_name, R.TypeRoom,rt.roomType_ID from Hotel H left join RoomTable rt on H.Hotel_ID = rt.Hotel_ID left join RoomTypeTable R on rt.roomType_ID = R.roomType_ID where H.Hotel_ID=@H_id;"
        '        Dim cmdquery2 As New SqlCommand(query2)

        '        cmdquery2.CommandType = CommandType.Text
        '        cmdquery2.Connection = con

        '        Using sda2 As New SqlDataAdapter(cmdquery2)
        '            Dim ds2 As New DataSet()
        '            sda2.Fill(ds2)
        '            ddlTypeRoom.DataSource = ds2.Tables(0)
        '            ddlTypeRoom.DataTextField = "TypeRoom"
        '            ddlTypeRoom.DataValueField = "roomType_ID"
        '            ddlTypeRoom.DataBind()
        '        End Using

        '    End Using
        'End If
        ddlTypeRoom.Items.Insert(0, New ListItem("--Select Room Type--", "0"))


        If Request.QueryString("id") IsNot Nothing Then
            'Split values obtained from Room Page
            Dim commandArgs As String() = Request.QueryString("id").Split(New Char() {","c})
            Dim HotelID As String = commandArgs(0)
            Dim RoomTypeID As String = commandArgs(1)

            'Populate Type Dropdown list
            '======================================================================
            Dim conn1 As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString()
            Using con1 As New SqlConnection(conn1)
                'Dim query2 As String = "SELECT DISTINCT roomType_ID, TypeRoom FROM RoomTypeTable"
                Dim query01 As String = "Select H.Hotel_ID, H.Hotel_name, R.TypeRoom,rt.roomType_ID from Hotel H left join RoomTable rt on H.Hotel_ID = rt.Hotel_ID left join RoomTypeTable R on rt.roomType_ID = R.roomType_ID where H.Hotel_ID=@H_id"
                Dim cmdquery02 As New SqlCommand(query01)

                Try

                    cmdquery02.CommandType = CommandType.Text
                    cmdquery02.Connection = con1

                    cmdquery02.Parameters.AddWithValue("@H_id", HotelID)

                    Using sda02 As New SqlDataAdapter(cmdquery02)
                        Dim ds02 As New DataSet()
                        sda02.Fill(ds02)
                        ddlTypeRoom.DataSource = ds02.Tables(0)
                        ddlTypeRoom.DataTextField = "TypeRoom"
                        ddlTypeRoom.DataValueField = "roomType_ID"
                        ddlTypeRoom.DataBind()
                    End Using
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
            '======================================================================

            'Set Selected value to the dropdown list (Hotel, Type Room) + disable
            ddlHotelName.Items.FindByValue(HotelID).Selected = True
            ddlHotelName.Enabled = False

            ddlTypeRoom.Items.FindByValue(RoomTypeID).Selected = True
            ddlTypeRoom.Enabled = False

        End If

    End Sub

    Protected Sub btnReserve_Click(sender As Object, e As EventArgs) Handles btnReserve.Click
        AddReservation()
        EvalPay()
    End Sub

    Private Sub AddReservation()
        If addflag = False Then
            Try

                cmd.Connection = con

                con.Open()

                cmd.CommandText = "INSERT INTO Cart(UID, HID, RTID, CIn, COut, NumP, Price) values (@UID, @HID, @RTID, @CIn, @COut, @NumP, @Price)"

                cmd.Parameters.AddWithValue("@UID", Session("USERID"))
                cmd.Parameters.AddWithValue("@HID", ddlHotelName.SelectedValue.ToString())
                cmd.Parameters.AddWithValue("@RTID", ddlTypeRoom.SelectedValue.ToString())
                cmd.Parameters.AddWithValue("@CIn", txtCheckIn.Text.ToString())
                cmd.Parameters.AddWithValue("@COut", txtCheckOut.Text.ToString())
                cmd.Parameters.AddWithValue("@NumP", txtNumP.Text.ToString())
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text.ToString())

                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                con.Close()

            Catch ex As Exception

            End Try
        End If





        'Dim cartCookie As HttpCookie = New HttpCookie("UserCookie")
        'cartCookie("c_HotelID") = ddlHotelName.SelectedValue
        'cartCookie("c_TypeRoomID") = ddlTypeRoom.SelectedValue
        'cartCookie("c_CheckIn") = txtCheckIn.Text.ToString()
        'cartCookie("c_CheckOut") = txtCheckOut.Text.ToString()
        'cartCookie("c_NumP") = txtNumP.Text.ToString()
        'cartCookie("c_Price") = txtPrice.Text.ToString()
        'cartCookie.Expires = Now.AddDays(1)
        'Response.Cookies.Add(cartCookie)
        Response.Redirect("~/CheckOutSummary.aspx")



        'Dim rt As String = ddlTypeRoom.SelectedValue
        'Dim hid As String = ddlHotelName.SelectedValue
        'Dim RID As String

        'If addflag = False Then
        '    Try


        '        cmd.Connection = con

        '        con.Open()

        '        'cmd.CommandText = "INSERT INTO Reservation(Check_In, Check_Out, NumPerson) values (@CheckIN, @CheckOUT, @Nperson SELECT Reserv_ID FROM ReservationTable WHERE Reserv_ID = SCOPE_IDENTITY()"
        '        cmd.CommandText = "INSERT INTO ReservationTable(room_ID, UserID,CheckInDate, CheckOutDate, NumPerson) values ((SELECT room_ID FROM RoomTable WHERE roomType_ID = @rt AND Hotel_ID = @HID), 18, @CIN, @COUT, @numP) SELECT Reserv_ID FROM ReservationTable WHERE Reserv_ID = SCOPE_IDENTITY()"

        '        cmd.Parameters.AddWithValue("@rt", rt)
        '        cmd.Parameters.AddWithValue("@HID", hid)
        '        cmd.Parameters.AddWithValue("@CIN", txtCheckIn.Text.ToString())
        '        cmd.Parameters.AddWithValue("@COUT", txtCheckOut.Text.ToString())
        '        cmd.Parameters.AddWithValue("@numP", txtNumP.Text.ToString())

        '        rdr = cmd.ExecuteReader()
        '        rdr.Read()

        '        RID = rdr(0).ToString()
        '        rdr.Close()

        '        cmd.Parameters.Clear()


        '        'cmd.ExecuteNonQuery()
        '        'cmd.Parameters.Clear()
        '        'con.Close()

        '        cmd2.Connection = con

        '        cmd2.CommandText = "INSERT INTO PaymentTable(Payment, Reserv_ID) values (@Pay, @RID)"
        '        cmd2.Parameters.AddWithValue("@Pay", txtPrice.Text.ToString())
        '        cmd2.Parameters.AddWithValue("@RID", RID)

        '        cmd2.ExecuteNonQuery()

        '        con.Close()



        '        lblMessage.Text = "Add Successful!"

        '    Catch ex As Exception
        '        lblMessage.Text = ex.Message.ToString()

        '    End Try

        '    Response.Redirect("~/CheckOutSummary.aspx")

        'End If
    End Sub

    Protected Sub ddlHotelName_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim conn2 As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString()
        Using con2 As New SqlConnection(conn2)
            'Dim query2 As String = "SELECT DISTINCT roomType_ID, TypeRoom FROM RoomTypeTable"
            Dim query2 As String = "Select H.Hotel_ID, H.Hotel_name, R.TypeRoom,rt.roomType_ID from Hotel H left join RoomTable rt on H.Hotel_ID = rt.Hotel_ID left join RoomTypeTable R on rt.roomType_ID = R.roomType_ID where H.Hotel_ID=@H_id"
            Dim cmdquery2 As New SqlCommand(query2)

            Try

                cmdquery2.CommandType = CommandType.Text
                cmdquery2.Connection = con2

                cmdquery2.Parameters.AddWithValue("@H_id", ddlHotelName.SelectedValue)

                Using sda2 As New SqlDataAdapter(cmdquery2)
                    Dim ds2 As New DataSet()
                    sda2.Fill(ds2)
                    ddlTypeRoom.DataSource = ds2.Tables(0)
                    ddlTypeRoom.DataTextField = "TypeRoom"
                    ddlTypeRoom.DataValueField = "roomType_ID"
                    ddlTypeRoom.DataBind()

                    If ddlTypeRoom.Items.Count > 1 Then
                        ddlTypeRoom.Enabled = True
                    Else
                        ddlTypeRoom.Enabled = False
                    End If

                End Using
            Catch ex As Exception
                Throw ex
            End Try
        End Using
    End Sub
    Protected Sub Price_SelectedIndexChanged(sender As Object, e As EventArgs)

        'Dim conn3 As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString()
        'Using con3 As New SqlConnection(conn3)
        '    Dim query3 As String = "select Price from RoomTypeTable where roomType_ID=@R_id"
        '    Dim query4 As String = "select DATEDIFF(day,@CIN,@COUT) As NumDays"

        '    Dim cmdquery3 As New SqlCommand(query3)
        '    Dim cmdquery4 As New SqlCommand(query4)

        '    Try

        '        cmdquery3.CommandType = CommandType.Text
        '        cmdquery4.CommandType = CommandType.Text

        '        cmdquery3.Connection = con3
        '        cmdquery4.Connection = con3

        '        con3.Open()

        '        cmdquery3.Parameters.AddWithValue("@R_id", ddlTypeRoom.SelectedValue)
        '        cmdquery4.Parameters.AddWithValue("@CIN", txtCheckIn.Text.ToString())
        '        cmdquery4.Parameters.AddWithValue("@COUT", txtCheckOut.Text.ToString())

        '        Dim dr As SqlDataReader
        '        dr = cmdquery3.ExecuteReader

        '        If dr.HasRows Then
        '            dr.Read()
        '            num_of_person = Convert.ToInt32(txtNumP.Text)
        '            total = Convert.ToInt32(dr.Item("Price")) * NumDays
        '            'txtPrice.Text = dr.Item("Price")
        '            txtPrice.Text = total.ToString()

        '            lbltest.Text = Convert.ToString(NumDays) + Convert.ToString(num_of_person)

        '            dr.Close()
        '        End If


        '        Dim dr2 As SqlDataReader
        '        dr2 = cmdquery4.ExecuteReader

        '        If dr2.HasRows Then
        '            dr2.Read()
        '            'txtPrice.Text = dr.Item("Price")
        '            NumDays = Convert.ToInt32(dr2.Item("NumDays"))
        '            'lbltest.Text = NumDays
        '            dr.Close()
        '        End If


        '        con3.Close()

        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Using

    End Sub
    Protected Sub btnEvaluatePrice_Click(sender As Object, e As EventArgs) Handles btnEvaluatePrice.Click
        EvalPay()
    End Sub

    Private Sub EvalPay()
        Dim conn3 As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString()
        Using con3 As New SqlConnection(conn3)
            Dim query3 As String = "select Price from RoomTypeTable where roomType_ID=@R_id"

            Dim cmdquery3 As New SqlCommand(query3)

            Try

                cmdquery3.CommandType = CommandType.Text

                cmdquery3.Connection = con3

                con3.Open()

                cmdquery3.Parameters.AddWithValue("@R_id", ddlTypeRoom.SelectedValue)

                Dim dr As SqlDataReader
                dr = cmdquery3.ExecuteReader

                If dr.HasRows Then
                    dr.Read()
                    price = Convert.ToInt32(dr.Item("Price"))
                    dr.Close()
                End If

                'Calculate payment per day & per person
                num_of_person = Convert.ToInt32(txtNumP.Text)
                NumDays = DateDiff("d", txtCheckIn.Text, txtCheckOut.Text)
                txtPrice.Text = (price * NumDays) * num_of_person


                con3.Close()

            Catch ex As Exception
                Throw ex
            End Try
        End Using
    End Sub
End Class
