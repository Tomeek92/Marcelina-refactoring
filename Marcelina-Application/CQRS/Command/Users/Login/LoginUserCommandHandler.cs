using AutoMapper;
using Marcelina_Domain.Enties.Users;
using Marcelina_Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Marcelina_Application.CQRS.Command.Users.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, SignInResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<SignInResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var user = _mapper.Map<User>(request.UserDto);
                var existingUser = await _userRepository.FindByEmailAsync(user.Email);
                if (existingUser == null)
                {
                    return SignInResult.Failed;
                }
                var result = await _userRepository.LoginAsync(existingUser, request.UserDto.Password);
                return result;
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania {ex.Message}");
            }
        }
    }
}