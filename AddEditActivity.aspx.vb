
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class AddEditActivity
    Inherits System.Web.UI.Page

    Dim ActImage As String
    Private con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString())
    Private cmd As New SqlCommand
    Private cmd2 As New SqlCommand
    Private rdr As SqlDataReader
    Dim addflag As Boolean = False

    Private Sub AddEditActivity_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            If Request.QueryString("id") Is Nothing Then
                btnAdd.Text = "Add Activity"
            Else
                btnAdd.Text = "Update Activity"
                LoadActivityByID()
            End If

            BindActivity()

        End If
    End Sub

    Private Sub LoadActivityByID()
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString)
            Using cmd As New SqlCommand("LoadByHotelActivityID", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.Add("@HAID", SqlDbType.Int).Value = Request.QueryString("id")

                con.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader()

                While (reader.Read())
                    ddlHotelName.Text = reader(1)
                    txtActivityName.Text = reader(2)
                    txtDescri.Text = reader(3)
                    txtPrice.Text = reader(4)
                End While

            End Using
        End Using
    End Sub

    Private Sub BindActivity()
        'Populating DropDownList
        If Not Me.IsPostBack Then
            Dim conn As String = ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString()
            Using con As New SqlConnection(conn)
                Using cmd As New SqlCommand("SELECT DISTINCT Hotel_ID, Hotel_name FROM Hotel")

                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    Using sda As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet()
                        sda.Fill(ds)
                        ddlHotelName.DataSource = ds.Tables(0)
                        ddlHotelName.DataTextField = "Hotel_name"
                        ddlHotelName.DataValueField = "Hotel_ID"
                        ddlHotelName.DataBind()
                    End Using
                End Using
            End Using

            ddlHotelName.Items.Insert(0, New ListItem("--Select Hotel--", "0"))

        End If
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If btnAdd.Text = "Update Activity" Then
            UpdateActivity()
        Else
            AddActivity()
        End If

        Response.Redirect("~/ActivityManagementHotel.aspx")
    End Sub

    Private Sub UpdateActivity()
        If FileUploadHotelActivityPhoto.HasFile Then
            Dim FileExtension As String = System.IO.Path.GetExtension(FileUploadHotelActivityPhoto.FileName)
            If Not FileExtension.ToLower = ".jpg" And Not FileExtension.ToLower = ".png" And
                Not FileExtension = ".gif" Then
                lblStatus.Text = "only .jpg, .png or .gif extension is allowed"
                lblStatus.ForeColor = System.Drawing.Color.Red
            Else
                Dim fileSize As Integer = FileUploadHotelActivityPhoto.PostedFile.ContentLength
                If fileSize >= 2097125 Then
                    lblStatus.Text = "Maximum size (2MB) exceeded"
                    lblStatus.ForeColor = System.Drawing.Color.Red
                End If
            End If
        End If

        If FileUploadHotelActivityPhoto.HasFile Then
            ActImage = Path.GetFileName(FileUploadHotelActivityPhoto.PostedFile.FileName)
            FileUploadHotelActivityPhoto.PostedFile.SaveAs(Server.MapPath("~/ActivityImages/" + ActImage))
        End If

        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString)
            Using cmd2 As New SqlCommand("UpdateActivity", con)
                cmd2.CommandType = CommandType.StoredProcedure

                cmd2.Parameters.Add("@HAID", SqlDbType.Int).Value = Request.QueryString("id")
                cmd2.Parameters.Add("@Hname", SqlDbType.NVarChar, 255).Value = ddlHotelName.Text
                cmd2.Parameters.Add("@ActName", SqlDbType.NVarChar, 255).Value = txtActivityName.Text
                cmd2.Parameters.Add("@ActPrice", SqlDbType.NVarChar, 255).Value = txtPrice.Text
                cmd2.Parameters.Add("@ActImg", SqlDbType.NVarChar, 255).Value = ActImage

                con.Open()
                cmd2.ExecuteNonQuery()

            End Using
        End Using
    End Sub

    Private Sub AddActivity()
        If addflag = False Then



            If FileUploadHotelActivityPhoto.HasFile Then
                Dim FileExtension As String = System.IO.Path.GetExtension(FileUploadHotelActivityPhoto.FileName)
                If Not FileExtension.ToLower = ".jpg" And Not FileExtension.ToLower = ".png" And
                    Not FileExtension = ".gif" Then
                    lblStatus.Text = "only .jpg, .png or .gif extension is allowed"
                    lblStatus.ForeColor = System.Drawing.Color.Red
                Else
                    Dim fileSize As Integer = FileUploadHotelActivityPhoto.PostedFile.ContentLength
                    If fileSize >= 2097125 Then
                        lblStatus.Text = "Maximum size (2MB) exceeded"
                        lblStatus.ForeColor = System.Drawing.Color.Red
                    End If
                End If

                ActImage = Path.GetFileName(FileUploadHotelActivityPhoto.PostedFile.FileName)
                FileUploadHotelActivityPhoto.PostedFile.SaveAs(Server.MapPath("~/ActivityImages/" + ActImage))
            End If

            'Insert into ActivityTable
            Dim ActID As String
            Dim HotID As String = ddlHotelName.SelectedValue

            cmd.Connection = con

            con.Open()

            cmd.CommandText = "INSERT INTO Activity(A_Name, A_Descri, A_Price, A_Image) values (@ActName, @ActDescri, @ActPrice, @ActPhoto) SELECT A_ID FROM Activity WHERE A_ID=SCOPE_IDENTITY()"

            cmd.Parameters.AddWithValue("@ActName", txtActivityName.Text.ToString())
            cmd.Parameters.AddWithValue("@ActDescri", txtDescri.Text.ToString())
            cmd.Parameters.AddWithValue("@ActPrice", txtPrice.Text.ToString())
            cmd.Parameters.AddWithValue("@ActPhoto", ActImage)

            rdr = cmd.ExecuteReader()
            rdr.Read()

            ActID = rdr(0).ToString()
            rdr.Close()

            cmd.Parameters.Clear()

            FileUploadHotelActivityPhoto.SaveAs(Server.MapPath("~/ActivityImages/" + FileUploadHotelActivityPhoto.FileName))

            'Insert into Hotel_Activity Table

            cmd2.Connection = con

            cmd2.CommandText = "INSERT INTO Hotel_Activity(A_ID, Hotel_ID) values (@Act_ID, @H_ID)"
            cmd2.Parameters.AddWithValue("@Act_ID", ActID)
            cmd2.Parameters.AddWithValue("@H_ID", HotID)

            cmd2.ExecuteNonQuery()

            con.Close()


            lblMessage.Text = "Add Successful!"

        End If

        addflag = True

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("~/ActivityManagementHotel.aspx")
    End Sub
End Class
