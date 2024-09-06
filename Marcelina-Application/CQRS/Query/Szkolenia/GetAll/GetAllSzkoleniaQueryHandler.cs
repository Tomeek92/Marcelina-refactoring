using AutoMapper;
using Marcelina_Application.Dto;
using Marcelina_Domain.Interfaces;
using MediatR;

namespace Marcelina_Application.CQRS.Query.Szkolenia.GetAll
{
    public class GetAllSzkoleniaQueryHandler : IRequestHandler<GetAllSzkoleniaQuery, IEnumerable<SzkolenieDto>>
    {
        private readonly ISzkolenieRepository _szkolenieRepository;
        private readonly IMapper _mapper;

        public GetAllSzkoleniaQueryHandler(ISzkolenieRepository szkolenieRepository, IMapper mapper)
        {
            _szkolenieRepository = szkolenieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SzkolenieDto>> Handle(GetAllSzkoleniaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var getAll = await _szkolenieRepository.GetAll();
                var mapp = _mapper.Map<IEnumerable<SzkolenieDto>>(getAll);
                return mapp;
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd mapowania {ex.Message}");
            }
        }
    }
}