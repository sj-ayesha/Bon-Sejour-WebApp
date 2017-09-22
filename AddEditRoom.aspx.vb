
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class AddEditRoom
    Inherits System.Web.UI.Page

    Dim addflag As Boolean = False
    Dim filename As String
    Dim RoomImg As String
    Private con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString())
    Private cmd As New SqlCommand
    Private cmd2 As New SqlCommand
    Private cmd3 As New SqlCommand
    Private rdr As SqlDataReader
    Dim HID As Integer

    Private Sub AddEditRoom_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If Request.QueryString("id") Is Nothing Then
                btnAdd.Text = "Add Room"
            Else
                btnAdd.Text = "Update Room"
                LoadRoomByID()
            End If

            BindHotel()
        End If
    End Sub

    Private Sub LoadRoomByID()
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString)
            Using cmd As New SqlCommand("LoadRoomByID", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.Add("@R_ID", SqlDbType.Int).Value = Request.QueryString("id")

                con.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader()

                While (reader.Read())
                    'ddlHotelName.Text = reader(1)
                    HID = reader(0)
                    ddlTypeRoom.Text = reader(3)
                    numRoom.Text = reader(4)
                    txtPrice.Text = reader(5)
                End While

            End Using
        End Using
    End Sub

    Private Sub BindHotel()
        'ddlHotelName.Items.Clear()
        'ddlHotelName.SelectedIndex = -1
        'ddlHotelName.SelectedValue = Nothing
        'ddlHotelName.ClearSelection()

        'Populating DropDownList
        If Not Me.IsPostBack Then
            Dim conn As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString()
            Using con As New SqlConnection(conn)
                Dim query As String = "SELECT DISTINCT Hotel_ID, Hotel_name FROM Hotel"
                Dim cmdquery As New SqlCommand(query)

                cmdquery.CommandType = CommandType.Text
                cmdquery.Connection = con

                'ddlHotelName.Items.Insert(0, New ListItem("--Select Hotel--", "0"))

                Using sda As New SqlDataAdapter(cmdquery)
                    Dim ds As New DataSet()
                    sda.Fill(ds)
                    ddlHotelName.DataSource = ds.Tables(0)
                    ddlHotelName.DataTextField = "Hotel_name"
                    ddlHotelName.DataValueField = "Hotel_ID"
                    ddlHotelName.DataBind()
                End Using

            End Using
            ddlHotelName.Items.FindByValue(HID).Selected = True
            ddlHotelName.Enabled = False
            '    Using cmd As New SqlCommand("SELECT DISTINCT Hotel_ID, Hotel_name FROM Hotel")

            '        cmd.CommandType = CommandType.Text
            '        cmd.Connection = con
            '        Using sda As New SqlDataAdapter(cmd)
            '            Dim ds As New DataSet()
            '            sda.Fill(ds)
            '            ddlHotelName.DataSource = ds.Tables(0)
            '            ddlHotelName.DataTextField = "Hotel_name"
            '            ddlHotelName.DataValueField = "Hotel_ID"
            '            ddlHotelName.DataBind()
            '        End Using
            '    End Using
            'End Using



        End If
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If btnAdd.Text = "Update Room" Then
            UpdateRoom()
        Else
            AddRoom()
        End If


        Response.Redirect("~/RoomManagementHotel.aspx")
    End Sub

    Private Sub UpdateRoom()
        If FileUploadRoomImgIcon.HasFile Then
            Dim FileExtension As String = System.IO.Path.GetExtension(FileUploadRoomImgIcon.FileName)
            If Not FileExtension.ToLower = ".jpg" And Not FileExtension.ToLower = ".png" And
                Not FileExtension = ".gif" Then
                lblStatus.Text = "only .jpg, .png or .gif extension is allowed"
                lblStatus.ForeColor = System.Drawing.Color.Red
            Else
                Dim fileSize As Integer = FileUploadRoomImgIcon.PostedFile.ContentLength
                If fileSize >= 2097125 Then
                    lblStatus.Text = "Maximum size (2MB) exceeded"
                    lblStatus.ForeColor = System.Drawing.Color.Red
                End If
            End If
        End If

        If FileUploadRoomImgIcon.HasFile Then
            filename = Path.GetFileName(FileUploadRoomImgIcon.PostedFile.FileName)
            FileUploadRoomImgIcon.PostedFile.SaveAs(Server.MapPath("~/RoomImages/" + filename))

        End If

        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString)
            Using cmd2 As New SqlCommand("UpdateRoom", con)
                cmd2.CommandType = CommandType.StoredProcedure

                cmd2.Parameters.Add("@R_ID", SqlDbType.Int).Value = Request.QueryString("id")
                cmd2.Parameters.Add("@TRoom", SqlDbType.NVarChar, 255).Value = ddlTypeRoom.Text
                cmd2.Parameters.Add("@NRoom", SqlDbType.NVarChar, 255).Value = numRoom.Text
                cmd2.Parameters.Add("@Prix", SqlDbType.NVarChar, 255).Value = txtPrice.Text
                cmd2.Parameters.Add("@Img", SqlDbType.NVarChar, 255).Value = filename

                con.Open()
                cmd2.ExecuteNonQuery()

            End Using
        End Using
    End Sub

    Private Sub AddRoom()


        If addflag = False Then

            If FileUploadRoomImgIcon.HasFile Then
                For Each file In FileUploadRoomImgIcon.PostedFiles
                    filename = Path.GetFileName(file.FileName)
                    file.SaveAs(Server.MapPath("~/RoomImages/" + filename))
                Next
            End If
            'If FileUploadRoomImgIcon.HasFile Then
            '    Dim FileExtension As String = System.IO.Path.GetExtension(FileUploadRoomImgIcon.FileName)
            '    If Not FileExtension.ToLower = ".jpg" And Not FileExtension.ToLower = ".png" And
            '        Not FileExtension = ".gif" Then
            '        lblStatus.Text = "only .jpg, .png or .gif extension is allowed"
            '        lblStatus.ForeColor = System.Drawing.Color.Red
            '    Else
            '        Dim fileSize As Integer = FileUploadRoomImgIcon.PostedFile.ContentLength
            '        If fileSize >= 2097125 Then
            '            lblStatus.Text = "Maximum size (2MB) exceeded"
            '            lblStatus.ForeColor = System.Drawing.Color.Red
            '        End If
            '    End If

            Dim hotelid As String = ddlHotelName.SelectedValue
            Dim imageid As String
            Dim roomtypeid As String

            'InsertImage in ImageTable
            cmd.Connection = con
            con.Open()

            cmd.CommandText = "INSERT INTO ImageTable (Images) values (@R_Image) SELECT Image_ID FROM ImageTable WHERE Image_ID=SCOPE_IDENTITY()"
            cmd.Parameters.AddWithValue("@R_Image", filename)

            rdr = cmd.ExecuteReader()
            rdr.Read()

            imageid = rdr(0).ToString()
            rdr.Close()
            cmd.Parameters.Clear()

            lbltest.Text = RoomImg
            FileUploadRoomImgIcon.SaveAs(Server.MapPath("~/RoomImages/" + FileUploadRoomImgIcon.FileName))

            'Insert TypeRoom, Price, NumRoom in RoomTypeTable
            cmd2.Connection = con

            cmd2.CommandText = "INSERT INTO RoomTypeTable(TypeRoom, NumRoom, Price) values (@TypeRoom, @NumRoom, @Price) SELECT roomType_ID FROM RoomTypeTable WHERE roomType_ID=SCOPE_IDENTITY()"

            cmd2.Parameters.AddWithValue("@TypeRoom", ddlTypeRoom.SelectedItem.Text.ToString())
            cmd2.Parameters.AddWithValue("@NumRoom", numRoom.Text.ToString())
            cmd2.Parameters.AddWithValue("@Price", txtPrice.Text.ToString())

            rdr = cmd2.ExecuteReader()
            rdr.Read()

            roomtypeid = rdr(0).ToString()
            rdr.Close()

            cmd2.Parameters.Clear()

            'Insert into RoomTable
            cmd3.Connection = con

            cmd3.CommandText = "INSERT INTO RoomTable(roomType_ID, Hotel_ID, Image_ID) values (@rid, @hid, @imid)"
            cmd3.Parameters.AddWithValue("@rid", roomtypeid)
            cmd3.Parameters.AddWithValue("@hid", hotelid)
            cmd3.Parameters.AddWithValue("@imid", imageid)

            cmd3.ExecuteNonQuery()

            con.Close()


            lblMessage.Text = "Add Successful!"
        End If

        addflag = True
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("~/RoomManagementHotel.aspx")
    End Sub

End Class
