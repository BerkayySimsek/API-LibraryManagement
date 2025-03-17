using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.Exceptions.Type;
using LibraryManagement.Models;

namespace LibraryManagement.Services.BusinessRules;

public class BookBusinessRules
{
    private IBookRepository _bookRepository;

    public BookBusinessRules(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void TitleMustBeUnique(string title)
    {
        bool isPresentTitle = _bookRepository.IsPresentByTitle(title);
        if (isPresentTitle)
        {
            throw new BusinessException("Kitap başlığı benzersiz olmalıdır.");
        }
    }

    public void IsbnMustBeUnique(string isbn)
    {
        bool countByIsbn = _bookRepository.IsPresentByIsbn(isbn);
        if (countByIsbn)
        {
            throw new BusinessException("Isbn numarası benzersiz olmalıdır.");
        }
    }

    public void BookNotFound(Book? book)
    {
        if (book is null)
        {
            throw new NotFoundException("İlgili kitap bulunamadı.");
        }
    }
}
