﻿using System.Reflection.Metadata.Ecma335;

namespace LibraryManagement.Models;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Isbn { get; set; }

    public int Page { get; set; }
    public double Price { get; set; }
    public string? ImageUrl { get; set; }

    // Navigation Property
    public int CategoryId { get; set; }
    public Category? Category { get; set; } = new Category();
    public int AuthorId { get; set; }
    public Author? Author { get; set; } = new Author();
}
