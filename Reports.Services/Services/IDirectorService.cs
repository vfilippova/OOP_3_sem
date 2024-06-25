using Reports.BLL.Dto;
using Reports.BLL.Mappers;
using Reports.DAL.Contexts;
using Reports.DAL.Stuff.Directors;
using Reports.DAL.Stuff.Employees;

namespace Reports.Services.Services;

public interface IDirectorService
{
    public ReportsAppContext ReportsAppContext { get; }
    List<DirectorDto> GetDirectors();

    DirectorDto AddDirector(string login, string password, string name, string info, DirectorRole directorRole);

    public DirectorDto AuthorizeDirector(string login, string password);

    public DirectorDto GetDirector(int id);

    public DirectorDto FindDirector(int id);

    public DirectorDto GetDirector(string login);

    public DirectorDto FindDirector(string login);
}