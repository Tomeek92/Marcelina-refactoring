using Marcelina_Application.Dto;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Users.Update
{
    public class UpdateUserCommand : UserDto, IRequest
    {
    }
}