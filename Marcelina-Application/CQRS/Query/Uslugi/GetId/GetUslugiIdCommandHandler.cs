using AutoMapper;
using Marcelina_Application.Dto;
using Marcelina_Domain.Interfaces;
using MediatR;

namespace Marcelina_Application.CQRS.Query.Uslugi.GetId
{
    public class GetUslugiIdCommandHandler : IRequestHandler<GetUslugiIdCommand, UslugaDto>
    {
        private readonly IUslugaRepository _uslugaRepository;
        private readonly IMapper _mapper;

        public GetUslugiIdCommandHandler(IUslugaRepository uslugaRepository, IMapper mapper)
        {
            _uslugaRepository = uslugaRepository;
            _mapper = mapper;
        }

        public async Task<UslugaDto> Handle(GetUslugiIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var getUsluga = await _uslugaRepository.GetElementById(request.Id);
                var mapp = _mapper.Map<UslugaDto>(getUsluga);
                return mapp;
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania {ex.Message}");
            }
        }
    }
}