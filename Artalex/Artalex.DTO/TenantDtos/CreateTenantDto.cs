namespace Artalex.DTO.TenantDtos;

public class CreateTenantDto
{
    public string TenancyName { get; set; }

    public string Name { get; set; }

    public string AdminEmailAddress { get; set; }

    public string ConnectionString { get; set; }

    public bool IsActive { get; set; }
}
