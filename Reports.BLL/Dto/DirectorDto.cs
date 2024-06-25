using Reports.DAL.Stuff.Directors;

namespace Reports.BLL.Dto;

public record DirectorDto(string Name, string Info, DirectorRole DirectorRole, int Id);