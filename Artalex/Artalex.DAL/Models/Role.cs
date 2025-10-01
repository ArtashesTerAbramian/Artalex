using Microsoft.AspNetCore.Identity;

namespace Artalex.DAL.Models;

public class Role : IdentityRole<int>
{
    public string? Description { get; set; }

}