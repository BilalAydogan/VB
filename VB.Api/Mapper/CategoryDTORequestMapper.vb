Imports AutoMapper
Imports VB.Entity

Public Class CategoryDTORequestMapper
    Inherits Profile
    Public Sub New()
        CreateMap(Of Category, CategoryDTORequest)()
        CreateMap(Of CategoryDTORequest, Category)()
    End Sub
End Class
