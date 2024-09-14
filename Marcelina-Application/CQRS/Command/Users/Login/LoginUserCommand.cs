using Marcelina_Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Marcelina_Application.CQRS.Command.Users.Login
{
    public class LoginUserCommand : IRequest<UserDto>
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; }
        public string Password { get; set; } = null!;

        public LoginUserCommand()
        {

        }
    }
}