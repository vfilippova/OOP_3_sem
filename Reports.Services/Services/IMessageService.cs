using Reports.BLL.Dto;
using Reports.DAL.Contexts;
using Reports.DAL.Messages;

namespace Reports.Services.Services;

public interface IMessageService
{
    public ReportsAppContext ReportsAppContext { get; }

    List<MessageDto> GetMessages();

    public MessageDto AddMessage(string messageInfo, string messageSender, MessageStatus messageStatus);
}