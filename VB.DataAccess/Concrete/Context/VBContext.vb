Imports Microsoft.EntityFrameworkCore
Imports VB.Entity

Partial Public Class VBContext
    Inherits DbContext
    Public Sub New()
    End Sub

    Public Sub New(ByVal options As DbContextOptions(Of VBContext))
        MyBase.New(options)
    End Sub
    Public Overridable Property Category As DbSet(Of Category)
    Protected Overrides Sub OnConfiguring(ByVal optionsBuilder As DbContextOptionsBuilder)
        optionsBuilder.UseSqlServer("Data Source=.\BILAL; Initial Catalog=VBDB; Integrated Security=true; TrustServerCertificate=True")
    End Sub
End Class
