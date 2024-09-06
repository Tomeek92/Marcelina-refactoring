using AutoMapper;
using Marcelina_Application.Dto;
using Marcelina_Domain.Interfaces;
using MediatR;

namespace Marcelina_Application.CQRS.Query.Uslugi.GetAll
{
    public class GetAllUslugiCommandHandler : IRequestHandler<GetAllUslugiCommand, IEnumerable<UslugaDto>>
    {
        private readonly IUslugaRepository _uslugaRepository;
        private readonly IMapper _mapper;

        public GetAllUslugiCommandHandler(IUslugaRepository uslugaRepository, IMapper mapper)
        {
            _uslugaRepository = uslugaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UslugaDto>> Handle(GetAllUslugiCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var getAll = await _uslugaRepository.GetAll();
                var mapp = _mapper.Map<IEnumerable<UslugaDto>>(getAll);
                return mapp;
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania {ex.Message}");
            }
        }
    }
}