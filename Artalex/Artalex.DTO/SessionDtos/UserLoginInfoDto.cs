using Artalex.Dto;

namespace Artalex.DTO.SessionDtos;

public class UserLoginInfoDto : BaseDto
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }
}
