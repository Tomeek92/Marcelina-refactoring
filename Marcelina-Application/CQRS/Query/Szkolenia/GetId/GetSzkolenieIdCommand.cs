using Marcelina_Application.Dto;
using MediatR;

namespace Marcelina_Application.CQRS.Query.Szkolenia.GetId
{
    public class GetSzkolenieIdCommand : IRequest<SzkolenieDto>
    {
        public int Id { get; set; }

        public GetSzkolenieIdCommand(int id)
        {
            Id = id;
        }
    }
}