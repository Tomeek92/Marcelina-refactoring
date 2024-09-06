using Marcelina_Application.Dto;
using MediatR;

namespace Marcelina_Application.CQRS.Query.Uslugi.GetAll
{
    public class GetAllUslugiCommand : IRequest<IEnumerable<UslugaDto>>
    {
    }
}