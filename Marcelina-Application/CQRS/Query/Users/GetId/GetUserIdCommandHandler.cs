using AutoMapper;
using Marcelina_Application.Dto;
using Marcelina_Domain.Interfaces;
using MediatR;

namespace Marcelina_Application.CQRS.Query.Users.GetId
{
    public class GetUserIdCommandHandler : IRequestHandler<GetUserIdCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserIdCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingUser = await _userRepository.GetElementById(request.Id);
                var mapp = _mapper.Map<UserDto>(existingUser);
                return mapp;
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania {ex.Message}");
            }
        }
    }
}