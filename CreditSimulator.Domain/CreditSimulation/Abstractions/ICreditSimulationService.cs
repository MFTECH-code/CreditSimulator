namespace CreditSimulator.Domain.CreditSimulation.Abstractions;

public interface ICreditSimulationService
{
    CreditSimulationResult RunCreditSumulation(CreditSimulationRequest request);
}
