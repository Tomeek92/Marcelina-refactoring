using AutoMapper;
using Marcelina_Domain.Interfaces;
using Marcelina_Domain.Uslugi;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Uslugi.Delete
{
    public class DeleteUslugiCommandHandler : IRequestHandler<DeleteUslugiCommand>
    {
        private readonly IUslugaRepository _uslugaRepository;
        private readonly IMapper _mapper;

        public DeleteUslugiCommandHandler(IUslugaRepository uslugaRepository, IMapper mapper)
        {
            _uslugaRepository = uslugaRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteUslugiCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapp = _mapper.Map<Usluga>(request.Id);
                await _uslugaRepository.Delete(mapp.Id);
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania {ex.Message}");
            }
        }
    }
}