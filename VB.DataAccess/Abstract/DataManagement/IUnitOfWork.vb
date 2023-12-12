Public Interface IUnitOfWork
    ReadOnly Property CategoryRepository As ICategoryRepository
    Function SaveChangeAsync() As Task(Of Integer)
End Interface
