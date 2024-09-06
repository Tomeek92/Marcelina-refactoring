using Marcelina_Application.Dto;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Uslugi.Update
{
    public class UpdateUslugiCommand : UslugaDto, IRequest
    {
    }
}