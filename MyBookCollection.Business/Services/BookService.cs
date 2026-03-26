using MyBookCollection.Business.Dtos;
using MyBookCollection.Business.Extensions;
using MyBookCollection.Business.Interfaces;
using MyBookCollection.Business.Models;
using MyBookCollection.Data.Entities;
using MyBookCollection.Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;

namespace MyBookCollection.Business.Services;

public class BookService(IBookRepository bookRepository) : IBookService
{
    private readonly IBookRepository _bookRepository = bookRepository;

    public async Task<ServiceResult<int>> CreateBookAsync(AddBookForm form)
    {
        if (form == null)
            return ServiceResult<int>.Error("Ogiltig data");

        try
        {
            var entity = form.ToEntity();

            await _bookRepository.CreateAsync(entity);
            await _bookRepository.SaveAsync();

            return ServiceResult<int>.Ok(entity.Id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ServiceResult<int>.Error("Nåt gick fel, försök igen");
        }
    }

    public async Task<IEnumerable<BookModel>> GetAllBooksAsync()
    {
        var entities = await _bookRepository.GetAllAsync();
        var books = entities.Select(entity => entity.ToModel());
        return books;
    }

    public async Task<ServiceResult<BookModel>> GetBookAsync(Expression<Func<BookEntity, bool>> expression)
    {
        try
        {
            var entity = await _bookRepository.GetAsync(expression);
            if (entity == null)
                return ServiceResult<BookModel>.Error("Ingen bok hittades");

            var book = entity.ToModel();

            return ServiceResult<BookModel>.Ok(book);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ServiceResult<BookModel>.Error("Fel vid hämtning av bok");
        }
    }

    public async Task<ServiceResult> UpdateBookAsync(Expression<Func<BookEntity, bool>> expression, UpdateBookForm updatedBook)
    {
        if (updatedBook == null)
            return ServiceResult.Error("Ogiltig data");

        try
        {
            var existingEntity = await _bookRepository.GetAsync(expression);
            if (existingEntity == null)
                return ServiceResult.Error("Ingen bok hittades");

            var updatedEntity = updatedBook.ToEntiy();

            _bookRepository.Update(existingEntity, updatedEntity);
            await _bookRepository.SaveAsync();
            return ServiceResult.Ok();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ServiceResult.Error("Nåt gick fel, bok ej uppdaterad");
        }
    }

    public async Task<ServiceResult> DeleteBookAsync(Expression<Func<BookEntity, bool>> expression)
    {
        if (expression == null)
            return ServiceResult.Error("Ingen bok hittades");

        try
        {
            var entity = await _bookRepository.GetAsync(expression);
            if (entity == null)
                return ServiceResult.Error("Ingen bok hittades");

            _bookRepository.Delete(entity!);
            await _bookRepository.SaveAsync();

            return ServiceResult.Ok();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ServiceResult.Error("Nåt gick fel, bok ej raderad");
        }
    }
}
