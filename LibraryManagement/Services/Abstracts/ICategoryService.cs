using LibraryManagement.Models.Dtos.Categories;
using System.Xml.Serialization;

namespace LibraryManagement.Services.Abstracts;

public interface ICategoryService
{
    List<CategoryResponseDto> GetAll();
    void Add(CategoryAddRequestDto categoryAddRequestDto);
    void Delete(int id);
    CategoryResponseDto GetById(int id);
}
