using AutoMapper;
using Marcelina_Domain.Interfaces;
using Marcelina_Domain.Uslugi;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Uslugi.Create
{
    public class CreateUslugiCommandHandler : IRequestHandler<CreateUslugiCommand>
    {
        private readonly IUslugaRepository _uslugaRepository;
        private readonly IMapper _mapper;

        public CreateUslugiCommandHandler(IUslugaRepository uslugaRepository, IMapper mapper)
        {
            _uslugaRepository = uslugaRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateUslugiCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapp = _mapper.Map<Usluga>(request);
                await _uslugaRepository.Create(mapp);
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania {ex.Message}");
            }
        }
    }
}