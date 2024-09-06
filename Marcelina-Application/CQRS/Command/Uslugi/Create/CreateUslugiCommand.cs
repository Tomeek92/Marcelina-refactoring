using Marcelina_Application.Dto;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Uslugi.Create
{
    public class CreateUslugiCommand : UslugaDto, IRequest
    {
    }
}