using Reports.DAL.Messages;

namespace Reports.BLL.Dto;

public record MessageDto(string MessageText, MessageInfo MessageInfo, MessageSender MessageSender, MessageStatus MessageStatus, string WorkerReceivedLogin, int Id);