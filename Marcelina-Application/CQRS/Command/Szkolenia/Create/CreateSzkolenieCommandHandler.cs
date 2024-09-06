using AutoMapper;
using Marcelina_Domain.Enties.Szkolenia;
using Marcelina_Domain.Interfaces;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Szkolenia.Create
{
    public class CreateSzkolenieCommandHandler : IRequestHandler<CreateSzkolenieCommand>
    {
        private readonly ISzkolenieRepository _szkolenieRepository;
        private readonly IMapper _mapper;

        public CreateSzkolenieCommandHandler(ISzkolenieRepository szkolenieRepository, IMapper mapper)
        {
            _szkolenieRepository = szkolenieRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateSzkolenieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapp = _mapper.Map<Szkolenie>(request);
                await _szkolenieRepository.Create(mapp);
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd mapowania {ex.Message}");
            }
        }
    }
}