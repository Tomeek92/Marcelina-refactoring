using AutoMapper;
using Marcelina_Domain.Enties.Szkolenia;
using Marcelina_Domain.Interfaces;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Szkolenia.Update
{
    public class UpdateSzkolenieCommandHandler : IRequestHandler<UpdateSzkolenieCommand>
    {
        private readonly ISzkolenieRepository _szkolenieRepository;
        private readonly IMapper _mapper;

        public UpdateSzkolenieCommandHandler(ISzkolenieRepository szkolenieRepository, IMapper mapper)
        {
            _szkolenieRepository = szkolenieRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateSzkolenieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapp = _mapper.Map<Szkolenie>(request);
                await _szkolenieRepository.Update(mapp);
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania {ex.Message}");
            }
        }
    }
}