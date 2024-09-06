using Marcelina_Application.Dto;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Szkolenia.Create
{
    public class CreateSzkolenieCommand : SzkolenieDto, IRequest
    {
    }
}