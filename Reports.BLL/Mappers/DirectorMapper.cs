using Reports.BLL.Dto;
using Reports.DAL.Stuff.Directors;

namespace Reports.BLL.Mappers;

public static class DirectorMapper
{
    public static DirectorDto Map(Director director)
    {
        return new DirectorDto(director.Name, director.Info, director.DirectorRole, director.Id);
    }
}