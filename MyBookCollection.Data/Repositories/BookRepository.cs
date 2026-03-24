using MyBookCollection.Data.Contexts;
using MyBookCollection.Data.Entities;
using MyBookCollection.Data.Interfaces;

namespace MyBookCollection.Data.Repositories;

public class BookRepository(DataContext context) : BaseRepository<BookEntity>(context), IBookRepository
{
    private readonly DataContext _context = context;
}
