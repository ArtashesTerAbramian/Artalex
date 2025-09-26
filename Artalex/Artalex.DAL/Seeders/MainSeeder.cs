using Microsoft.EntityFrameworkCore;

namespace Artalex.DAL.Seeders;

internal static class MainSeeder
{
    //public static DateTime DefaulDbInittDate => new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    //DON'T use fields, properties or variables, we need to use raw values beside every time on creating migration it will
    //update statement for values.

    public static void SeedData(this ModelBuilder modelBuilder)
    {
        //ErrorSeeder.SeedData(modelBuilder);
    }
}