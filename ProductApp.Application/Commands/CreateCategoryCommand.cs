using MediatR;
using ProductApp.Domain.Products.Entities;

namespace ProductApp.Application.Commands
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public string Name { get; set; }
        public int UserId { get; set; }

        public CreateCategoryCommand(string name,int userId)
        {
            Name = name;
            UserId = userId;
        }
    }
}
