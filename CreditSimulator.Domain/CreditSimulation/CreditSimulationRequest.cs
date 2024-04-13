namespace CreditSimulator.Domain.CreditSimulation;

public class CreditSimulationRequest
{
    public required string FullName { get; set; }
    public required string DocumentNumber { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public decimal AnualIncome { get; set; }
    public decimal RequestedValue { get; set; }
}
