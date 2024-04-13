using Moq.AutoMock;
using CreditSimulator.Application.CreditSimulation.Services;
using CreditSimulator.Application.Exceptions;
using CreditSimulator.Domain.CreditCore;
using CreditSimulator.Domain.CreditSimulation;

namespace CreditSimulator.Test;

public class CreditSimulationTest
{
    private AutoMocker _autoMocker;

    public CreditSimulationTest()
    {
        _autoMocker = new AutoMocker();
    }

    [Fact]
    public void CreditSimulationTest_SuccesCalculation() 
    {
        var input = new CreditSimulationRequest 
        {
            FullName = "Test",
            DocumentNumber = "123",
            AnualIncome = 50000.0m,
            City = "Test City",
            State = "Test State",
            RequestedValue = 50000.0m
        };

        var service = _autoMocker.CreateInstance<CreditSimulationService>();

        var result = service.RunCreditSumulation(input);

        var expectedResult = new CreditSimulationResult
        {
            ProposedValue = 15000.0m,
            InstallmentValue = 1883.63m,
            InterestRate = 0.11m,
            NumberOfInstallments = 20,
            Installments = new List<Installment>
            {
                new Installment(1, 1883.63m, 1650.00m, 14766.37m),
                new Installment(2, 1883.63m, 1624.30m, 14507.03m),
                new Installment(3, 1883.63m, 1595.77m, 14219.17m),
                new Installment(4, 1883.63m, 1564.11m, 13899.64m),
                new Installment(5, 1883.63m, 1528.96m, 13544.97m),
                new Installment(6, 1883.63m, 1489.95m, 13151.28m),
                new Installment(7, 1883.63m, 1446.64m, 12714.29m),
                new Installment(8, 1883.63m, 1398.57m, 12229.23m),
                new Installment(9, 1883.63m, 1345.21m, 11690.81m),
                new Installment(10, 1883.63m, 1285.99m, 11093.16m),
                new Installment(11, 1883.63m, 1220.25m, 10429.77m),
                new Installment(12, 1883.63m, 1147.28m, 9693.41m),
                new Installment(13, 1883.63m, 1066.28m, 8876.06m),
                new Installment(14, 1883.63m, 976.37m, 7968.79m),
                new Installment(15, 1883.63m, 876.57m, 6961.72m),
                new Installment(16, 1883.63m, 765.79m, 5843.87m),
                new Installment(17, 1883.63m, 642.83m, 4603.07m),
                new Installment(18, 1883.63m, 506.34m, 3225.77m),
                new Installment(19, 1883.63m, 354.83m, 1696.97m),
                new Installment(20, 1883.63m, 186.67m, 0)
            }
        };

        Assert.Equal(expectedResult.ProposedValue, result.ProposedValue);
        Assert.Equal(expectedResult.InstallmentValue, result.InstallmentValue);
        Assert.Equal(expectedResult.InterestRate, result.InterestRate);
        Assert.Equal(expectedResult.NumberOfInstallments, result.NumberOfInstallments);
        Assert.True(expectedResult.Installments.SequenceEqual(result.Installments));
    }

    [Fact]
    public void CreditSimulationTest_InsuficientIncome()
    {
         var input = new CreditSimulationRequest 
        {
            FullName = "Test",
            DocumentNumber = "123",
            AnualIncome = 25000.0m,
            City = "Test City",
            State = "Test State",
            RequestedValue = 50000.0m
        };

        var service = _autoMocker.CreateInstance<CreditSimulationService>();

        Assert.Throws<InsuficientException>(() => service.RunCreditSumulation(input));
    }
}
