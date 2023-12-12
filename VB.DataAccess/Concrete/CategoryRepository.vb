Imports Microsoft.EntityFrameworkCore
Imports VB.Entity
Public Class CategoryRepository
    Inherits Repository(Of Category)
    Implements ICategoryRepository

    Public Sub New(context As DbContext)
        MyBase.New(context)
    End Sub
End Class
