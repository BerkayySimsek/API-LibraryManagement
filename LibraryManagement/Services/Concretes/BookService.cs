using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.Exceptions.Type;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Books;
using LibraryManagement.Services.Abstracts;
using LibraryManagement.Services.BusinessRules;
using LibraryManagement.Services.ValidationRules;

namespace LibraryManagement.Services.Concretes;

public class BookService : IBookService
{
    private IBookRepository _bookRepository;
    private BookBusinessRules _bookBusinessRules;

    public BookService(IBookRepository bookRepository, BookBusinessRules bookBusinessRules)
    {
        _bookRepository = bookRepository;
        _bookBusinessRules = bookBusinessRules;
    }

    public void Add(BookAddRequestDto dto)
    {
        BookValidationRules.BookAddValidator(dto);
        _bookBusinessRules.TitleMustBeUnique(dto.Title);
        _bookBusinessRules.IsbnMustBeUnique(dto.Isbn);
        Book book = ConvertToTable(dto);
        _bookRepository.Add(book);
    }

    public void Delete(int id)
    {
        Book book = _bookRepository.GetById(id);
        _bookRepository.Delete(book);
    }

    public List<BookResponseDto> GetAll()
    {
        List<Book> books = _bookRepository.GetAll();
        List<BookResponseDto> responses = ConvertToResponseDtoList(books);
        return responses;
    }

    public BookResponseDto? GetById(int id)
    {
        Book? book = _bookRepository.GetById(id);
        _bookBusinessRules.BookNotFound(book);
        BookResponseDto dto = ConvertToResponseDto(book);
        return dto;
    }

    private List<BookResponseDto> ConvertToResponseDtoList(List<Book> books)
    {
        //1. Yöntem
        //List<BookResponseDto> responses= new List<BookResponseDto>();

        //foreach (Book book in books)
        //{
        //    BookResponseDto dto=ConvertToResponseDto(book);
        //    responses.Add(dto);
        //}
        //return responses;

        // 2. Yöntem
        return books.Select(x => ConvertToResponseDto(x)).ToList();
    }
    private BookResponseDto ConvertToResponseDto(Book book)
    {
        BookResponseDto dto = new BookResponseDto()
        {
            AuthorId = book.AuthorId,
            AuthorName = $"{book.Author.FirstName} {book.Author.SurName}",
            CategoryId = book.CategoryId,
            CategoryName = book.Category.Name,
            Id = book.Id,
            Isbn = book.Isbn,
            Page = book.Page,
            Price = book.Price,
            Title = book.Title,
        };
        return dto;
    }
    private Book ConvertToTable(BookAddRequestDto dto)
    {
        Book book = new Book()
        {
            Title = dto.Title,
            AuthorId = dto.AuthorId,
            CategoryId = dto.CategoryId,
            Isbn = dto.Isbn,
            Page = dto.Page,
            Price = dto.Price,
        };
        return book;
    }
}
