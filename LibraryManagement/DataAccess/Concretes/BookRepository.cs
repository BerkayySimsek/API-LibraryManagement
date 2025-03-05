﻿using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.Models;

namespace LibraryManagement.DataAccess.Concretes;


// Single Responsibilitiy
// Open Closed
// Liskov Substitution Principle
// Interface Segregation Principle
public class BookRepository : IBookRepository
{

    BaseDbContext context = new BaseDbContext();

    public void Add(Book book)
    {
        context.Books.Add(book);
        context.SaveChanges();
    }

    public void Delete(Book book)
    {
        context.Books.Remove(book);
        context.SaveChanges();
    }

    public List<Book> GetAll()
    {
        List<Book> books = context.Books.ToList();
        return books;
    }

    public List<Book> GetAllByPriceRange(double min, double max)
    {
        List<Book> books = context.Books.Where(x => x.Price <= max && x.Price >= min).ToList();
        return books;
    }

    public Book? GetById(int id)
    {
        Book? book = context.Books.Find(id);
        return book;
    }

    public Book? GetByIsbn(string isbn)
    {
        Book? book = context.Books.FirstOrDefault(x => x.Isbn == isbn);
        return book;
    }

    public void Update(Book book)
    {
        context.Books.Update(book);
        context.SaveChanges();
    }
}
