Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class AddHotelAdmin
    Inherits System.Web.UI.Page
    Dim addflag As Boolean = False

    Private con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ToString())
    Private cmd As New SqlCommand
    Dim HotelImage As String

    Protected Sub AddHotelAdmin_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("id") Is Nothing Then
                btnAdd.Text = "Add Hotel"
            Else
                btnAdd.Text = "Update Hotel"
                LoadHotelByID()
            End If
        End If
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If btnAdd.Text = "Update Hotel" Then
            UpdateHotel()
        Else
            AddHotel()
        End If

        Response.Redirect("~/HotelManagementAdmin.aspx")

    End Sub

    Public Sub AddHotel()
        If addflag = False Then


            If FileUploadHotelImage.HasFile Then
                Dim FileExtension As String = System.IO.Path.GetExtension(FileUploadHotelImage.FileName)
                If Not FileExtension.ToLower = ".jpg" And Not FileExtension.ToLower = ".png" And
                    Not FileExtension = ".gif" Then
                    lblStatus.Text = "only .jpg, .png or .gif extension is allowed"
                    lblStatus.ForeColor = System.Drawing.Color.Red
                Else
                    Dim fileSize As Integer = FileUploadHotelImage.PostedFile.ContentLength
                    If fileSize >= 2097125 Then
                        lblStatus.Text = "Maximum size (2MB) exceeded"
                        lblStatus.ForeColor = System.Drawing.Color.Red
                    End If
                End If
            End If

            If FileUploadHotelImage.HasFile Then
                HotelImage = Path.GetFileName(FileUploadHotelImage.PostedFile.FileName)
                FileUploadHotelImage.PostedFile.SaveAs(Server.MapPath("~/UploadImages/" + HotelImage))

            End If

            Try
                cmd.Connection = con
                con.Open()

                cmd.CommandText = "INSERT INTO Hotel(Hotel_name, Hotel_Descri, Hotel_Add, H_Image) values (@Hotel_name, @Hotel_Descri, @Hotel_Add, @H_Image)"

                cmd.Parameters.AddWithValue("@Hotel_name", Hname.Text.ToString())
                cmd.Parameters.AddWithValue("@Hotel_Descri", txtDescri.Text.ToString())
                cmd.Parameters.AddWithValue("@Hotel_Add", txtAdd.Text.ToString())
                'cmd.Parameters.AddWithValue("@H_Image", Server.MapPath("~/UploadImages/" + HotelImage))
                cmd.Parameters.AddWithValue("@H_Image", HotelImage)

                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()

                con.Close()

                FileUploadHotelImage.SaveAs(Server.MapPath("~/UploadImages/" + FileUploadHotelImage.FileName))

                lblMessage.Text = "Add Successful!"


            Catch ex As Exception
                lblMessage.Text = ex.Message.ToString()
            End Try

            addflag = True
        End If
    End Sub

    Public Sub UpdateHotel()
        If FileUploadHotelImage.HasFile Then
            Dim FileExtension As String = System.IO.Path.GetExtension(FileUploadHotelImage.FileName)
            If Not FileExtension.ToLower = ".jpg" And Not FileExtension.ToLower = ".png" And
                Not FileExtension = ".gif" Then
                lblStatus.Text = "only .jpg, .png or .gif extension is allowed"
                lblStatus.ForeColor = System.Drawing.Color.Red
            Else
                Dim fileSize As Integer = FileUploadHotelImage.PostedFile.ContentLength
                If fileSize >= 2097125 Then
                    lblStatus.Text = "Maximum size (2MB) exceeded"
                    lblStatus.ForeColor = System.Drawing.Color.Red
                End If
            End If
        End If

        If FileUploadHotelImage.HasFile Then
            HotelImage = Path.GetFileName(FileUploadHotelImage.PostedFile.FileName)
            FileUploadHotelImage.PostedFile.SaveAs(Server.MapPath("~/UploadImages/" + HotelImage))

        End If

        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString)
            Using cmd2 As New SqlCommand("UpdateHotel", con)
                cmd2.CommandType = CommandType.StoredProcedure

                cmd2.Parameters.Add("@Hotel_ID", SqlDbType.Int).Value = Request.QueryString("id")
                cmd2.Parameters.Add("@Hotel_name", SqlDbType.NVarChar, 255).Value = Hname.Text
                cmd2.Parameters.Add("@Hotel_Descri", SqlDbType.NVarChar, 255).Value = txtDescri.Text
                cmd2.Parameters.Add("@Hotel_Add", SqlDbType.NVarChar, 255).Value = txtAdd.Text
                cmd2.Parameters.Add("@H_Image", SqlDbType.NVarChar, 255).Value = HotelImage

                con.Open()
                cmd2.ExecuteNonQuery()

            End Using
        End Using

    End Sub

    Private Sub LoadHotelByID()
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionStringLocal").ConnectionString)
            Using cmd As New SqlCommand("LoadHotelByID", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.Add("@Hotel_ID", SqlDbType.Int).Value = Request.QueryString("id")

                con.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader()

                While (reader.Read())
                    Hname.Text = reader(1)
                    txtDescri.Text = reader(2)
                    txtAdd.Text = reader(3)
                End While

            End Using
        End Using
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("~/HotelManagementAdmin.aspx")
    End Sub
End Class
