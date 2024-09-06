using Marcelina_Application.Dto;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Users.Create
{
    public class CreateUserCommand : UserDto, IRequest
    {
        public UserDto UserDto { get; set; }

        public CreateUserCommand(UserDto userDto)
        {
            UserDto = userDto;
        }
    }
}