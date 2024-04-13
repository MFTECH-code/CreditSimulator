using CreditSimulator.Domain.CreditCore;
using CreditSimulator.Domain.CreditSimulation;
using CreditSimulator.Domain.CreditSimulation.Abstractions;
using CreditSimulator.Application.Exceptions;

namespace CreditSimulator.Application.CreditSimulation.Services;

public class CreditSimulationService : ICreditSimulationService
{
    public CreditSimulationResult RunCreditSumulation(CreditSimulationRequest request)
    {
        if (request.AnualIncome < 50000)
            throw new InsuficientException();

        var principal = request.AnualIncome * 0.3m;
        var InterestRate = 0.11m;
        var numberOfInstallments = 20;

        var (installmentValue, installments) = CalculateInstallments(principal, InterestRate, numberOfInstallments);

        return new CreditSimulationResult
        {
            ProposedValue = principal,
            InstallmentValue = installmentValue,
            InterestRate = InterestRate,
            NumberOfInstallments = numberOfInstallments,
            Installments = installments
        };
    }

    private (decimal, List<Installment>) CalculateInstallments(decimal principal, decimal interestRate, int numberOfInstallments)
    {
        var installments = new List<Installment>();
        var actualPrincipal = principal;
        for (var i = 1; i <= numberOfInstallments; i++)
        {
            var hundredInterestRate = (double) (1 + interestRate);
            var installmentValue = principal * interestRate / (decimal) (1 - Math.Pow(hundredInterestRate, -numberOfInstallments));
            var interestValue = actualPrincipal * interestRate;
            var principalPaid = installmentValue - interestValue;
            var debitBalance = actualPrincipal - principalPaid; 

            installments.Add(new Installment(i, Math.Round(installmentValue, 2), Math.Round(interestValue, 2), Math.Round(debitBalance, 2)));
            actualPrincipal = debitBalance;
        }

        return (installments.First().InstallmentValue, installments);
    }
}
