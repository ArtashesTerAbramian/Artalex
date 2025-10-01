namespace Artalex.DTO.SessionDtos;

public class GetCurrentLoginInfoDto
{
    public ApplicationInfoDto Application { get; set; }

    public UserLoginInfoDto User { get; set; }

    public TenantLoginInfoDto Tenant { get; set; }
}
