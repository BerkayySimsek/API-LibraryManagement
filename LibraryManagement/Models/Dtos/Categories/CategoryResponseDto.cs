namespace LibraryManagement.Models.Dtos.Categories;

public class CategoryResponseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }

    //public static implicit operator CategoryResponseDto(Category category)
    //{
    //    return new CategoryResponseDto { Id = category.Id, Name = category.Name };
    //}

    //public static explicit operator CategoryResponseDto(Category category)
    //{
    //    return new CategoryResponseDto { Id = category.Id, Name = category.Name };
    //}
}
