using Marcelina_Application.Dto;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Users.Delete
{
    public class DeleteUserCommand : UserDto, IRequest
    {
        public string Id { get; set; }

        public DeleteUserCommand(string id)
        {
            Id = id;
        }
    }
}