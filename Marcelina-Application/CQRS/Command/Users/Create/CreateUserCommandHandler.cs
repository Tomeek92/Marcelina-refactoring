using AutoMapper;
using Marcelina_Domain.Enties.Users;
using Marcelina_Domain.Interfaces;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Users.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapp = _mapper.Map<User>(request);
                var result = await _userRepository.Create(mapp, request.PasswordHash);
                if (!result.Succeeded)
                {
                    throw new Exception("Błąd podczas tworzenia użytkownika: " + string.Join(", ", result.Errors.Select(e => e.Description))); //<- przejść przez wszystkie błędy w kolekcji Errors i wybrać tylko ich opisy (Description), ignorując inne informacje, takie jak kody błędów.
                }
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania {ex.Message}");
            }
        }
    }
}