﻿using AutoMapper;
using Marcelina_Application.Dto;
using Marcelina_Domain.Interfaces;
using MediatR;

namespace Marcelina_Application.CQRS.Query.Szkolenia.GetId
{
    public class GetSzkolenieIdCommandHandler : IRequestHandler<GetSzkolenieIdCommand, SzkolenieDto>
    {
        private readonly ISzkolenieRepository _szkolenieRepository;
        private readonly IMapper _mapper;

        public GetSzkolenieIdCommandHandler(ISzkolenieRepository szkolenieRepository, IMapper mapper)
        {
            _szkolenieRepository = szkolenieRepository;
            _mapper = mapper;
        }

        public async Task<SzkolenieDto> Handle(GetSzkolenieIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingSzkolenie = await _szkolenieRepository.GetElementById(request.Id);
                var mapp = _mapper.Map<SzkolenieDto>(existingSzkolenie);
                return mapp;
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd mapowania {ex.Message}");
            }
        }
    }
}