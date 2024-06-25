using Reports.BLL.Dto;
using Reports.BLL.Exceptions;
using Reports.BLL.Mappers;
using Reports.DAL.Contexts;
using Reports.DAL.Messages;
using Reports.DAL.Reports;
using Reports.DAL.Stuff.Directors;
using Reports.DAL.Stuff.Employees;
using Reports.Services.Services;

namespace Reports.Services.Entities;

public class DirectorService : IDirectorService
{
    private static int _counter = 0;

    public DirectorService(ReportsAppContext reportsAppContext)
    {
        ReportsAppContext = reportsAppContext;
    }

    public ReportsAppContext ReportsAppContext { get; }


    public DirectorDto AddDirector(
        string login,
        string password,
        string name,
        string info,
        DirectorRole directorRole)
    {
        _counter++;
        var director = new Director(new DirectorAccount(login, password), name, info, directorRole, _counter);

        ReportsAppContext.Directors.Add(director);
        ReportsAppContext.SaveChanges();

        return DirectorMapper.Map(director);
    }

    public List<DirectorDto> GetDirectors()
    {
        return ReportsAppContext.Directors.Select(x => DirectorMapper.Map(x)).ToList();
    }

    public DirectorDto GetDirector(int id)
    {
        return GetDirectors().First(x => x.Id == id);
    }

    public DirectorDto FindDirector(int id)
    {
        return GetDirectors().FirstOrDefault(x => x.Id == id) ?? throw new ReportsException();
    }

    public DirectorDto GetDirector(string login)
    {
        return DirectorMapper.Map(ReportsAppContext.Directors.First(x => x.DirectorAccount.Login == login));
    }

    public DirectorDto FindDirector(string login)
    {
        return DirectorMapper.Map(ReportsAppContext.Directors.FirstOrDefault(x => x.DirectorAccount.Login == login) ?? throw new ReportsException());
    }

    public DirectorDto AuthorizeDirector(string login, string password)
    {
        Director director = ReportsAppContext.Directors.ToList().Find(x => x.DirectorAccount.Login == login);

        if (director == null)
        {
            return null;
        }

        return director.DirectorAccount.Password != password ? null : DirectorMapper.Map(director);
    }
}