namespace Artalex.DAL.Models;

public class Tenant
{
    public int Id { get; set; }
    public string TenancyName { get; set; } = default!;
    public string Name { get; set; } = default!;
    public bool IsActive { get; set; } = true;
    public string? ConnectionString { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
}