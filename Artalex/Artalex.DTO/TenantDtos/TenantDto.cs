using System.ComponentModel.DataAnnotations;
using Artalex.Dto;

namespace Artalex.DTO.TenantDtos;

public class TenantDto : BaseDto
{
    public string TenancyName { get; set; }

    public string Name { get; set; }

    public bool IsActive { get; set; }
}
