namespace Reports.DAL.Messages;

public class Message
{
    public Message(string messageText, MessageInfo messageInfo, MessageSender messageSender, MessageStatus messageStatus, string answer, string workerAnsweredLogin, int id)
    {
        MessageInfo = messageInfo;
        MessageSender = messageSender;
        MessageStatus = messageStatus;
        WorkerAnsweredLogin = workerAnsweredLogin;
        Id = id;
        MessageText = messageText;
        Answer = answer;
    }

    public Message()
    {
    }

    public int Id { get; set; }
    public string WorkerAnsweredLogin { get; set; } = string.Empty;
    public string MessageText { get; set; }

    public string Answer { get; set; }
    public MessageInfo MessageInfo { get; set; }
    public MessageSender MessageSender { get; set; }
    public MessageStatus MessageStatus { get; set; }
}