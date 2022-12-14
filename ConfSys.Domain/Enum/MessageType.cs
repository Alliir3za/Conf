namespace ConfSys.Domain;

public enum MessageType : byte
{
    ReadyForSent = 1,
    InProgress = 2,
    Sent = 3
}
