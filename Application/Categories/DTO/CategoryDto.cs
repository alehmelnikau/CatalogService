namespace Application.Categories.DTO;

public class CategoryDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Image { get; set; }

    public int? ParentCategoryId { get; set; }
}
