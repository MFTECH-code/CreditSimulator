namespace CreditSimulator.Domain.CreditSimulation;

using CreditSimulator.Domain.CreditCore;

public class CreditSimulationResult
{
    public decimal ProposedValue { get; set; }
    public int NumberOfInstallments { get; set; }
    public decimal InstallmentValue { get; set; }
    public decimal InterestRate { get; set; }
    public required List<Installment> Installments { get; set; }
}
