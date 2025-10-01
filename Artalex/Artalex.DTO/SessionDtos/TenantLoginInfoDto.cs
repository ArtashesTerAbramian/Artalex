using Artalex.Dto;

namespace Artalex.DTO.SessionDtos;

public class TenantLoginInfoDto : BaseDto
{
    public string TenancyName { get; set; }

    public string Name { get; set; }
}
