Imports Microsoft.AspNetCore.Http
Imports Microsoft.EntityFrameworkCore
Imports System.Threading.Tasks
Imports VB.Entity
Public Class UnitOfWork
    Implements IUnitOfWork

    Private ReadOnly _context As VBContext
    Private ReadOnly _contextAccessor As IHttpContextAccessor
    Public Sub New(ByVal contextAccessor As IHttpContextAccessor, ByVal context As VBContext)
        _contextAccessor = contextAccessor
        _context = context

        CategoryRepository = New CategoryRepository(_context)

    End Sub
    Public ReadOnly Property CategoryRepository As ICategoryRepository Implements IUnitOfWork.CategoryRepository
    Public Function SaveChangeAsync() As Task(Of Integer) Implements IUnitOfWork.SaveChangeAsync
        Return _context.SaveChangesAsync()
    End Function
End Class
