using Application.Categories.Commands.CreateCategory;
using Application.Categories.Commands.DeleteCategory;
using Application.Categories.Commands.UpdateCategory;
using Application.Categories.DTO;
using Application.Categories.Queries.GetCategories;
using Application.Categories.Queries.GetCategory;
using MediatR;

namespace WebApi.Endpoints;

public static class Categories
{
    public static void MapCategoriesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes
        .MapGroup("/api/Categories");

        group.MapGet("/", GetCategories)
        .WithName("GetCategories");

        group.MapGet("/{id}", GetCategory)
        .WithName("GetCategory");

        group.MapPost("/", CreateCategory)
        .WithName("CreateCategory");

        group.MapPut("/{id}", UpdateCategory)
        .WithName("UpdateCategory");

        group.MapDelete("/{id}", DeleteCategory)
        .WithName("DeleteCategory");
    }

    public async static Task<IEnumerable<CategoryDto>> GetCategories(ISender sender)
    {
        return await sender.Send(new GetCategoriesQuery());
    }

    public async static Task<CategoryDto> GetCategory(ISender sender, int id)
    {
        return await sender.Send(new GetCategoryQuery(id));
    }

    public async static Task<int> CreateCategory(ISender sender, CreateCategoryCommand command)
    {
        return await sender.Send(command);
    }

     public async static Task<IResult> UpdateCategory(ISender sender, int id, UpdateCategoryCommand command)
     {
         if (id != command.Id) return Results.BadRequest();
         await sender.Send(command);
         return Results.NoContent();
     }

    public async static Task<IResult> DeleteCategory(ISender sender, int id)
    {
        await sender.Send(new DeleteCategoryCommand(id));
        return Results.NoContent();
    }
}
