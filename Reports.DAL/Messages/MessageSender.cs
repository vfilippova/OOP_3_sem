namespace Reports.DAL.Messages;

public class MessageSender
{
    public MessageSender(string sender)
    {
        Sender = sender;
    }

    public MessageSender()
    {
    }

    public string Sender { get; set; }
}