using AutoMapper;
using Marcelina_Domain.Interfaces;
using Marcelina_Domain.Uslugi;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Uslugi.Update
{
    public class UpdateUslugiCommandHandler : IRequestHandler<UpdateUslugiCommand>
    {
        private readonly IUslugaRepository _uslugaRepository;
        private readonly IMapper _mapper;

        public UpdateUslugiCommandHandler(IUslugaRepository uslugaRepository, IMapper mapper)
        {
            _uslugaRepository = uslugaRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateUslugiCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapp = _mapper.Map<Usluga>(request);
                await _uslugaRepository.Update(mapp);
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania {ex.Message}");
            }
        }
    }
}