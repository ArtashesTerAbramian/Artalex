namespace Artalex.DTO.UserDtos;

public class ResetPasswordDto
{
    public int UserId { get; set; }
    public string Token { get; set; } = default!;
    public string NewPassword { get; set; } = default!;
}