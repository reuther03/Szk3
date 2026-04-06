using Szk3.Common.Domain.Entities;
using Szk3.Company.Domain.Enums;

namespace Szk3.Company.Domain.Entities.JobPosition;

public class PositionRate : EntityBase<int>
{

    public decimal Amount { get; private set; }
    public string Currency { get; private set; } = null!;

    public RateType RateType { get; private set; }

    protected PositionRate() { }

    public PositionRate(decimal amount, string currency, RateType rateType)
    {
        Amount = amount;
        Currency = currency;
        RateType = rateType;
    }
}
