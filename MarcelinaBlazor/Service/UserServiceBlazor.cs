using Marcelina_Application.CQRS.Command.Users.Login;
using Marcelina_Application.Dto;
using System.Text.Json;


namespace MarcelinaBlazor.Service
{
    public class UserServiceBlazor
    {
        private readonly HttpClient _httpClient;
        private readonly string? _apiBaseUrl;
        public UserServiceBlazor(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["ApiBaseUrl"];
        }
        public async Task<UserDto> Login(LoginUserCommand userCommand)
        {
            try
            {

                var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}api/User/login", userCommand);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var userDto = JsonSerializer.Deserialize<UserDto>(responseContent);
                    Console.WriteLine(userDto);
                    if (userDto == null)
                    {
                        throw new Exception("Odpowiedź nie zawiera poprawnych danych JSON.");
                    }

                    return userDto;
                }
                else
                {
                    throw new Exception($"Błąd przy logowaniu: {response.StatusCode}, Treść odpowiedzi: {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Błąd podczas logowania: {ex.Message}");
            }
        }
    }
}
