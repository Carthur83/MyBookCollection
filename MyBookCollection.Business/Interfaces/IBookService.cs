using MyBookCollection.Business.Dtos;
using MyBookCollection.Business.Models;
using MyBookCollection.Business.Services;
using MyBookCollection.Data.Entities;
using System.Linq.Expressions;

namespace MyBookCollection.Business.Interfaces;

public interface IBookService
{
    Task<ServiceResult<int>> CreateBookAsync(AddBookForm form);
    Task<IEnumerable<BookModel>> GetAllBooksAsync();
    Task<ServiceResult<BookModel>> GetBookAsync(Expression<Func<BookEntity, bool>> expression);
    Task<ServiceResult> UpdateBookAsync(Expression<Func<BookEntity, bool>> expression, UpdateBookForm updatedBook);
    Task<ServiceResult> DeleteBookAsync(Expression<Func<BookEntity, bool>> expression);
}
