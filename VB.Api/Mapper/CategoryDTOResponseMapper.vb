Imports AutoMapper
Imports VB.Entity

Public Class CategoryDTOResponseMapper
    Inherits Profile
    Public Sub New()
        CreateMap(Of Category, CategoryDTOResponse)()
        CreateMap(Of CategoryDTOResponse, Category)()
    End Sub
End Class
