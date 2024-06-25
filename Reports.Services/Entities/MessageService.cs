using Reports.BLL.Dto;
using Reports.BLL.Exceptions;
using Reports.BLL.Mappers;
using Reports.DAL.Contexts;
using Reports.DAL.Messages;
using Reports.Services.Services;

namespace Reports.Services.Entities;

public class MessageService : IMessageService
{
    private static int _counter;

    public MessageService(ReportsAppContext reportsAppContext)
    {
        ReportsAppContext = reportsAppContext;
    }

    public ReportsAppContext ReportsAppContext { get; }

    public List<MessageDto> GetMessages()
    {
        return ReportsAppContext.Messages.Select(x => MessageMapper.Map(x)).ToList();
    }

    public MessageDto AddMessage(string messageInfo, string messageSender, MessageStatus messageStatus)
    {
        _counter++;

        var message = new Message(
            messageInfo,
            new MessageInfo(DateTime.Now, _counter),
            new MessageSender(messageSender),
            messageStatus,
            "",
            "",
            _counter);

        ReportsAppContext.Messages.Add(message);
        ReportsAppContext.SaveChanges();

        return MessageMapper.Map(message);
    }

    public void SetMessageAnswer(int messageId, string answer, string login)
    {
        Message message = ReportsAppContext.Messages.ToList().Find(x => x.Id == messageId);

        if (message == null)
        {
            throw new ReportsException();
        }

        message.Answer = answer;
        message.MessageStatus = MessageStatus.Answered;
        message.WorkerAnsweredLogin = login;
    }
}