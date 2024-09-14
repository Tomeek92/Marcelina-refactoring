using AutoMapper;
using Marcelina_Application.Dto;
using Marcelina_Domain.Enties.Users;
using Marcelina_Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Marcelina_Application.CQRS.Command.Users.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, SignInManager<User> signIn, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _signInManager = signIn;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {

            try
            {
             
                var user = _mapper.Map<User>(request);
                var existingUser = await _userRepository.FindByEmailAsync(user.Email);
                if (existingUser == null)
                {
                    throw new Exception("Nie znaleziono użytkownika");
                }
                var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, isPersistent: false, lockoutOnFailure: false);
                if (!result.Succeeded)
                {
                    throw new Exception("Nieprawidłowe dane logowania");
                }
                var userDto = _mapper.Map<UserDto>(existingUser);
                return userDto;
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania {ex.Message}");
            }
        }
    }
}