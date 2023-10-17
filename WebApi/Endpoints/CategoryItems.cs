using Application.Categories.Commands.CreateCategory;
using Application.Categories.Commands.DeleteCategory;
using Application.Categories.Commands.UpdateCategory;
using Application.Categories.DTO;
using Application.Categories.Queries.GetCategories;
using Application.Categories.Queries.GetCategory;
using Application.Categories.Queries.GetCategoryItem;
using Application.CategoryItems.Commands.CreateCategoryItem;
using Application.CategoryItems.Commands.DeleteCategoryItem;
using Application.CategoryItems.Commands.UpdateCategoryItem;
using Application.CategoryItems.DTO;
using Application.CategoryItems.Queries.GetCategoryItems;
using MediatR;

namespace WebApi.Endpoints;

public static class CategoryItems
{
    public static void MapCategoryItemsEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes
        .MapGroup("/api/CategoryItems");

        group.MapGet("/", GetCategoryItems)
        .WithName("GetCategoryItems");

        group.MapGet("/{id}", GetCategoryItem)
        .WithName("GetCategoryItem");

        group.MapPost("/", CreateCategoryItem)
        .WithName("CreateCategoryItem");

        group.MapPut("/{id}", UpdateCategoryItem)
        .WithName("UpdateCategoryItem");

        group.MapDelete("/{id}", DeleteCategoryItem)
        .WithName("DeleteCategoryItem");
    }

    public async static Task<IEnumerable<CategoryItemDto>> GetCategoryItems(ISender sender)
    {
        return await sender.Send(new GetCategoryItemsQuery());
    }

    public async static Task<CategoryItemDto> GetCategoryItem(ISender sender, int id)
    {
        return await sender.Send(new GetCategoryItemQuery(id));
    }

    public async static Task<int> CreateCategoryItem(ISender sender, CreateCategoryItemCommand command)
    {
        return await sender.Send(command);
    }

    public async static Task<IResult> UpdateCategoryItem(ISender sender, int id, UpdateCategoryItemCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async static Task<IResult> DeleteCategoryItem(ISender sender, int id)
    {
        await sender.Send(new DeleteCategoryItemCommand(id));
        return Results.NoContent();
    }
}
