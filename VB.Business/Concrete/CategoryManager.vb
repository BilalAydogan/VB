Imports System.Linq.Expressions
Imports VB.DataAccess
Imports VB.Entity

Public Class CategoryManager
    Implements ICategoryService
    Private ReadOnly _uow As IUnitOfWork

    Public Sub New(ByVal uow As IUnitOfWork)
        _uow = uow
    End Sub
    Public Async Function AddAsync(ByVal Entity As Category) As Task(Of Category) Implements IGenericService(Of Category).AddAsync
        Await _uow.CategoryRepository.AddAsync(Entity)
        Await _uow.SaveChangeAsync()
        Return Entity
    End Function

    Public Async Function GetAllAsync(ByVal Optional Filter As Expression(Of Func(Of Category, Boolean)) = Nothing, Optional IncludeProperties As String() = Nothing) As Task(Of IEnumerable(Of Category)) Implements IGenericService(Of Category).GetAllAsync
        Return Await _uow.CategoryRepository.GetAllAsync(Filter, IncludeProperties)
    End Function

    Public Async Function GetAsync(ByVal Filter As Expression(Of Func(Of Category, Boolean)), ParamArray IncludeProperties As String()) As Task(Of Category) Implements IGenericService(Of Category).GetAsync
        Return Await _uow.CategoryRepository.GetAsync(Filter, IncludeProperties)
    End Function

    Public Async Function RemoveAsync(ByVal Entity As Category) As Task Implements IGenericService(Of Category).RemoveAsync
        Await _uow.CategoryRepository.RemoveAsync(Entity)
        Await _uow.SaveChangeAsync()
    End Function

    Public Async Function UpdateAsync(ByVal Entity As Category) As Task Implements IGenericService(Of Category).UpdateAsync
        Await _uow.CategoryRepository.UpdateAsync(Entity)
        Await _uow.SaveChangeAsync()
    End Function
End Class
