using AutoMapper;
using Marcelina_Domain.Interfaces;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Szkolenia.Delete
{
    public class DeleteSzkolenieCommandHandler : IRequestHandler<DeleteSzkolenieCommand>
    {
        private readonly ISzkolenieRepository _szkolenieRepository;
        private readonly IMapper _mapper;

        public DeleteSzkolenieCommandHandler(ISzkolenieRepository szkolenieRepository, IMapper mapper)
        {
            _szkolenieRepository = szkolenieRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteSzkolenieCommand request, CancellationToken cancellationToken)
        {
            await _szkolenieRepository.Delete(request.Id);
        }
    }
}