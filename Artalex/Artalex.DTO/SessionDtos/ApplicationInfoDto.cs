namespace Artalex.DTO.SessionDtos;

public class ApplicationInfoDto
{
    public string Version { get; set; }

    public DateTime ReleaseDate { get; set; }

    public Dictionary<string, bool> Features { get; set; }
}
