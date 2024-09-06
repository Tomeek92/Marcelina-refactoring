using Marcelina_Application.Dto;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Szkolenia.Delete
{
    public class DeleteSzkolenieCommand : SzkolenieDto, IRequest
    {
        public int Id { get; set; }

        public DeleteSzkolenieCommand(int id)
        {
            Id = id;
        }
    }
}