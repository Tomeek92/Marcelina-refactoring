using Marcelina_Application.Dto;
using MediatR;

namespace Marcelina_Application.CQRS.Query.Szkolenia.GetAll
{
    public class GetAllSzkoleniaQuery : IRequest<IEnumerable<SzkolenieDto>>
    {
    }
}