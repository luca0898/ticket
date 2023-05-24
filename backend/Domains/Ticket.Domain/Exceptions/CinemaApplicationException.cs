using Ticket.Domain.Enums;

namespace Ticket.Domain.Exceptions;

public class TicketApplicationException : Exception
{
    public TicketApplicationExceptionTypes Type { get; }

    public TicketApplicationException(string message, TicketApplicationExceptionTypes type) : base($"{type}: {message}")
    {
        Type = type;
    }
}
