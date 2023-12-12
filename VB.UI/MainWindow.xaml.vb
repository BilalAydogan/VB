Imports System.Net.Http
Imports System.Text
Imports DevExpress.Xpf.Core
Imports Newtonsoft.Json.Linq

''' <summary>
''' Interaction logic for MainWindow.xaml
''' </summary>
Partial Public Class MainWindow
    Inherits ThemedWindow
    Public Sub New()
        InitializeComponent()
        KategorileriGetir()
    End Sub

    Private Sub ctgbutton_Click(sender As Object, e As RoutedEventArgs) Handles ctgbutton.Click
        Dim apiUrl As String = "https://localhost:65374/AddCategory"
        Dim kategoriAdi As String = category.Text

        ' API'ye gönderilecek veri oluşturuluyor
        Dim jsonData As String = $"{{""name"": ""{kategoriAdi}""}}"

        ' HttpClient oluşturuluyor
        Using client As New HttpClient()
            ' JSON verisi gönderiliyor
            Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

            ' API'ye POST isteği yapılıyor
            Dim response = client.PostAsync(apiUrl, content).Result

            ' Yanıt kontrolü
            If response.IsSuccessStatusCode Then
                MessageBox.Show("Kategori başarıyla eklendi.")
                KategorilerListView.Items.Clear()
                KategorileriGetir()
            Else
                MessageBox.Show($"API isteği başarısız oldu. HTTP durumu: {response.StatusCode}")
            End If
        End Using
    End Sub
    Private Sub KategorileriGetir()
        Dim apiUrl As String = "https://localhost:65374/GetCategories"

        Using client As New HttpClient()
            Dim response = client.GetAsync(apiUrl).Result

            If response.IsSuccessStatusCode Then
                Dim jsonString = response.Content.ReadAsStringAsync().Result
                Dim kategoriler As JArray = JArray.Parse(jsonString)

                ' Kategorileri ListView'e ekleyin
                For Each kategori As JObject In kategoriler
                    Dim kategoriAdi As String = kategori("name").ToString()

                    Dim listViewItem As New ListViewItem()
                    listViewItem.Content = New With {.KategoriAdi = kategoriAdi}
                    KategorilerListView.Items.Add(listViewItem)
                Next
            Else
                MessageBox.Show($"API isteği başarısız oldu. HTTP durumu: {response.StatusCode}")
            End If
        End Using
    End Sub
End Class