
namespace CreditSimulator.Domain.CreditCore;

public class Installment
{
    public int InstallmentNumber { get; set; }
    public decimal InstallmentValue { get; set; }
    public decimal InterestValue { get; set; }
    public decimal AmortizationValue => InstallmentValue - InterestValue;
    public decimal DebitBalance { get; set; }

    public Installment(int InstallmentNumber, decimal InstallmentValue, decimal InterestValue, decimal DebitBalance)
    {
        this.InstallmentNumber = InstallmentNumber;
        this.InstallmentValue = InstallmentValue;
        this.InterestValue = InterestValue;
        this.DebitBalance = DebitBalance;
    }

    public override bool Equals(object? obj)
    {
        return obj is Installment installment &&
               InstallmentNumber == installment.InstallmentNumber &&
               InstallmentValue == installment.InstallmentValue &&
               InterestValue == installment.InterestValue &&
               AmortizationValue == installment.AmortizationValue &&
               DebitBalance == installment.DebitBalance;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(InstallmentNumber, InstallmentValue, InterestValue, AmortizationValue, DebitBalance);
    }
}
