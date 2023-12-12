Imports AutoMapper
Imports Microsoft.AspNetCore.Mvc
Imports VB.Business
Imports VB.Entity

<ApiController>
<Route("[Action]")>
Public Class CategoryController
    Inherits Controller
    Private ReadOnly _categoryService As ICategoryService
    Private ReadOnly _mapper As IMapper
    Public Sub New(mapper As IMapper, categoryService As ICategoryService)
        _mapper = mapper
        _categoryService = categoryService
    End Sub
    <HttpGet("/GetCategories")>
    Public Async Function GetCategories() As Task(Of IActionResult)
        Dim category = Await _categoryService.GetAllAsync(Function(x) True)
        Dim categoryDTOResponseList As New List(Of CategoryDTOResponse)()

        For Each item In category
            categoryDTOResponseList.Add(_mapper.Map(Of CategoryDTOResponse)(item))
        Next


        Return Ok(categoryDTOResponseList)
    End Function
    <HttpPost("/AddCategory")>
    Public Async Function AddCategory(categoryDTORequest As CategoryDTORequest) As Task(Of IActionResult)
        Dim category As Category = _mapper.Map(Of Category)(categoryDTORequest)
        Await _categoryService.AddAsync(category)
        Dim categoryDTOResponse As CategoryDTOResponse = _mapper.Map(Of CategoryDTOResponse)(category)

        Return Ok(categoryDTOResponse)
    End Function

End Class
