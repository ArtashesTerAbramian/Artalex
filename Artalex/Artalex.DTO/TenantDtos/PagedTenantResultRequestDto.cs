namespace Artalex.DTO.TenantDtos;

public class PagedTenantResultRequestDto
{
    public string Keyword { get; set; }
    public bool? IsActive { get; set; }

    public string Sorting { get; set; }

    public void Normalize()
    {
        if (string.IsNullOrEmpty(Sorting))
        {
            Sorting = "TenancyName,Name";
        }

        Keyword = Keyword?.Trim();
    }
}

