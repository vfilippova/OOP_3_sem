namespace Reports.DAL.Messages;

public class MessageInfo
{
    public MessageInfo(DateTime dataTime, int messageCounter)
    {
        DataTime = dataTime;
        MessageCounter = messageCounter;
    }

    public MessageInfo()
    {
    }

    public DateTime DataTime { get; set; }
    public int MessageCounter { get; set; }
}