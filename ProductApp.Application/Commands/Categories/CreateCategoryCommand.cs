using MediatR;
using ProductApp.Domain.Categories.Entities;
using System.Text.Json.Serialization;

namespace ProductApp.Application.Commands.Categories
{
    [method: JsonConstructor]
    public class CreateCategoryCommand(string name, int userId) : IRequest<Category>
    {
        public string Name { get; set; } = name;
        public int UserId { get; set; } = userId;
    }
}
