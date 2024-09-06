using Marcelina_Application.Dto;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Szkolenia.Update
{
    public class UpdateSzkolenieCommand : SzkolenieDto, IRequest
    {
    }
}