using MyBookCollection.Business.Dtos;
using MyBookCollection.Business.Models;
using MyBookCollection.Data.Entities;

namespace MyBookCollection.Business.Extensions;

public static class MappingExtensions
{
    public static BookEntity ToEntity(this AddBookForm form)
    {
        return new BookEntity
        {
            Title = form.Title,
            Author = form.Author,
            Condition   = form.Condition,
            Type = form.Type,
            Edition = form.Edition,
            PublishedYear = form.PublishedYear,
            Description = form.Description,
            ImageFileName = form.ImageFileName,
        };
    }

    public static BookModel ToModel(this BookEntity entity)
    {
        return new BookModel
        {
            Id = entity.Id,
            Title = entity.Title,
            Author = entity.Author,
            Condition = entity.Condition,
            Type = entity.Type,
            Edition = entity.Edition,
            PublishedYear = entity.PublishedYear,
            Description= entity.Description,
            ImageFileName = entity.ImageFileName,
        };
    }

    public static BookEntity ToEntiy(this UpdateBookForm form)
    {
        return new BookEntity
        {
            Id = form.Id,
            Title = form.Title,
            Author = form.Author,
            Condition = form.Condition,
            Type = form.Type,
            Edition = form.Edition,
            PublishedYear = form.PublishedYear,
            Description = form.Description,
            ImageFileName = form.ImageFileName,
        };
    }

    public static UpdateBookForm ToUpdateForm(this BookModel model)
    {
        return new UpdateBookForm
        {
            Id = model.Id,
            Title = model.Title,
            Author = model.Author,
            Condition = model.Condition,
            Type = model.Type,
            Edition = model.Edition,
            PublishedYear = model.PublishedYear,
            Description = model.Description,
            ImageFileName = model.ImageFileName,
        };
    }
}

