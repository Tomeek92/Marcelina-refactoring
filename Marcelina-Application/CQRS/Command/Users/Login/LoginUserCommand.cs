using Marcelina_Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Marcelina_Application.CQRS.Command.Users.Login
{
    public class LoginUserCommand : IRequest<SignInResult>
    {
        public UserDto UserDto { get; set; }

        public LoginUserCommand(UserDto userDto)
        {
            UserDto = userDto;
        }
    }
}