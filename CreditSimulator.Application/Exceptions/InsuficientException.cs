namespace CreditSimulator.Application.Exceptions;

public class InsuficientException : Exception
{
    public InsuficientException(string message) : base(message) {}
    public InsuficientException() : base("Insuficient Income.") {}
}
