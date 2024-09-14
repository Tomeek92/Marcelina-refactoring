using Marcelina_Application.CQRS.Command.Users.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MarcelinaRefactoringAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if (result == null)
                {
                    return Unauthorized("Nieprawidłowe dane logowania.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nieoczekiwany błąd: {ex.Message}");
            }
        }
    }
}
