using Reports.BLL.Dto;
using Reports.DAL.Messages;

namespace Reports.BLL.Mappers;

public static class MessageMapper
{
    public static MessageDto Map(Message message)
    {
        return new MessageDto
        (message.MessageText,
            message.MessageInfo,
            message.MessageSender,
            message.MessageStatus,
            message.WorkerAnsweredLogin,
            message.Id);
    }
}