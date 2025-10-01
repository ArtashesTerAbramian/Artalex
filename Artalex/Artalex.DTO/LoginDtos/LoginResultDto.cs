namespace Artalex.DTO.LoginDtos;

public class LoginResultDto
{
    public string Token { get; set; } = default!;
    public DateTime Expiration { get; set; }
}