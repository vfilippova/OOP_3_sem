using Reports.BLL.Dto;
using Reports.BLL.Exceptions;
using Reports.DAL.Contexts;
using Reports.DAL.Messages;
using Reports.DAL.Stuff.Directors;
using Reports.DAL.Stuff.Employees;
using Reports.Services.Entities;
using Reports.Services.Services;

namespace Reports.Services;

public class MultiService : IMessageService, IReportService, IDirectorService, IEmployeeService
{
    private readonly string _admLogin;
    private readonly string _admPassword;

    public MultiService(IDirectorService directorService,
        IReportService reportService,
        IMessageService messageService,
        IEmployeeService employeeService, string admPassword, string admLogin)
    {
        _admLogin = admLogin;
        _admPassword = admPassword;
        DirectorService = directorService ?? throw new ReportsException();
        ReportService = reportService ?? throw new ReportsException();
        MessageService = messageService ?? throw new ReportsException();
        EmployeeService = employeeService ?? throw new ReportsException();
    }

    public MultiService(string admLogin, string admPassword)
    {
        _admLogin = admLogin;
        _admPassword = admPassword;
        EmployeeService = new EmployeeService(ReportsAppContext);
        DirectorService = new DirectorService(ReportsAppContext);
        ReportService = new ReportService(ReportsAppContext);
        MessageService = new MessageService(ReportsAppContext);
    }

    public IMessageService MessageService { get; }

    public IReportService ReportService { get; }

    public IDirectorService DirectorService { get; }

    public IEmployeeService EmployeeService { get; }

    public ReportsAppContext ReportsAppContext { get; } = new ();

    public void AddDefaultValues()
    {
        AddDirector(
            "director",
            "1234",
            "sanya",
            "hzhzhzhzhhzhzhz",
            DirectorRole.High
        );

        AddEmployee(
            "Employee",
            "password",
            "name",
            "sdfasfasdf",
            EmployeeRole.Middle);

        AddMessage("momo", "sobaka@gmail.com", MessageStatus.Sent);
        AddMessage("dodo", "sobaka123@gmail.com", MessageStatus.Sent);
        AddMessage("talant, pochemu ti echo ne fanat?", "seregaPirat@pank.com", MessageStatus.Sent);

        CreateReport();
    }

    public List<DirectorDto> GetDirectors()
    {
        return DirectorService.GetDirectors();
    }

    public bool IsAdmin(string login, string password)
    {
        return _admLogin == login && _admPassword == password;
    }

    public DirectorDto AddDirector(string login, string password, string name, string info, DirectorRole directorRole)
    {
        if (login == null || password == null || name == null || info == null)
        {
            throw new ReportsException();
        }

        return DirectorService.AddDirector(login, password, name, info, directorRole);
    }

    public DirectorDto AuthorizeDirector(string login, string password)
    {
        return DirectorService.AuthorizeDirector(login, password);
    }

    public DirectorDto GetDirector(int id)
    {
        return DirectorService.GetDirector(id);
    }

    public DirectorDto FindDirector(int id)
    {
        return DirectorService.FindDirector(id);
    }

    public DirectorDto GetDirector(string login)
    {
        if (login == null)
        {
            throw new ReportsException();
        }

        return DirectorService.GetDirector(login);
    }

    public DirectorDto FindDirector(string login)
    {
        if (login == null)
        {
            throw new ReportsException();
        }

        return DirectorService.FindDirector(login);
    }

    public List<EmployeeDto> GetEmployees()
    {
        return EmployeeService.GetEmployees();
    }

    public EmployeeDto AddEmployee(string login, string password, string name, string info, EmployeeRole employeeRole)
    {
        if (login == null || password == null || name == null || info == null)
        {
            throw new ReportsException();
        }

        return EmployeeService.AddEmployee(login, password, name, info, employeeRole);
    }

    public EmployeeDto GetEmployee(int id)
    {
        return EmployeeService.GetEmployee(id);
    }

    public EmployeeDto FindEmployee(int id)
    {
        return EmployeeService.FindEmployee(id);
    }

    public EmployeeDto GetEmployee(string login)
    {
        if (login == null)
        {
            throw new ReportsException();
        }

        return EmployeeService.GetEmployee(login);
    }

    public EmployeeDto FindEmployee(string login)
    {
        if (login == null)
        {
            throw new ReportsException();
        }

        return EmployeeService.FindEmployee(login);
    }

    public EmployeeDto AuthorizeEmployee(string login, string password)
    {
        return EmployeeService.AuthorizeEmployee(login, password);
    }

    public List<ReportDto> GetReports()
    {
        return ReportService.GetReports();
    }

    public ReportDto CreateReport()
    {
        return ReportService.CreateReport();
    }

    public List<MessageDto> GetMessages()
    {
        return MessageService.GetMessages();
    }

    public MessageDto AddMessage(string messageInfo, string messageSender, MessageStatus messageStatus)
    {
        if (messageInfo == null || messageSender == null)
        {
            throw new ReportsException();
        }

        return MessageService.AddMessage(messageInfo, messageSender, messageStatus);
    }
}