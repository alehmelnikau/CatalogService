using Application.Categories.DTO;
using Application.CategoryItems.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryItem, CategoryItemDto>();
    }
}
