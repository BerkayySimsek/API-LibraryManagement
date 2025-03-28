﻿using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Authors;
using LibraryManagement.Services.Abstracts;

namespace LibraryManagement.Services.Concretes;

public class AuthorService : IAuthorService
{
    private IAuthorRepository _authorRepository;
    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public void Add(AuthorAddRequestDto dto)
    {
        Author author = ConvertToAuthor(dto);
        _authorRepository.Add(author);
    }

    public void Delete(int id)
    {
        Author author = _authorRepository.GetById(id);
        _authorRepository.Delete(author);
    }

    public List<AuthorResponseDto> GetAll()
    {
        List<Author> authors = _authorRepository.GetAll();
        List<AuthorResponseDto> responses = ConvertToResponseDtoList(authors);
        return responses;
    }

    public AuthorResponseDto? GetById(int id)
    {
        Author author = _authorRepository.GetById(id);
        AuthorResponseDto response = ConvertToResponseDto(author);
        return response;
    }
    private Author ConvertToAuthor(AuthorAddRequestDto dto)
    {
        return new Author
        {
            FirstName = dto.FirstName,
            SurName = dto.SurName,
            BirthDate = new DateTime(dto.BirthYear, dto.BirthMonth, dto.BirthDay)
        };
    }
    private AuthorResponseDto ConvertToResponseDto(Author author)
    {
        return new AuthorResponseDto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            SurName = author.SurName,
            BirthYear = author.BirthDate.Year,
            BirthMonth = $"{author.BirthDate.Month}. Ay -> {GetMonthName(author.BirthDate.Month)}",
            BirthDay = author.BirthDate.Day,
        };
    }
    private List<AuthorResponseDto> ConvertToResponseDtoList(List<Author> authors)
    {
        return authors.Select(x => ConvertToResponseDto(x)).ToList();
    }
    private string GetMonthName(int month)
    {
        //if (month == 1)
        //{
        //    return "Ocak";
        //}
        //else if (month == 2)
        //{
        //    return "Şubat";
        //}

        return month switch
        {
            1 => "Ocak",
            2 => "Şubat",
            3 => "Mart",
            4 => "Nisan",
            5 => "Mayıs",
            6 => "Haziran",
            7 => "Temmuz",
            8 => "Ağustos",
            9 => "Eylül",
            10 => "Ekim",
            11 => "Kasım",
            12 => "Aralık",
        };
    }
}
