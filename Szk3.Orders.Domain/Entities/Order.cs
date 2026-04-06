using Szk3.Common.Domain.Entities;
using Szk3.Orders.Domain.Enums;

namespace Szk3.Orders.Domain.Entities;

public class Order : AggregateRoot<int>
{
    protected Order() { }

    public Order(
        int companyId,
        int jobPositionId,
        int requestedWorkersCount,
        DateOnly startDate,
        DateOnly? endDate,
        string? notes = null)
    {
        if (requestedWorkersCount <= 0)
            throw new ArgumentOutOfRangeException(nameof(requestedWorkersCount));

        if (endDate.HasValue && endDate.Value < startDate)
            throw new ArgumentException("EndDate cannot be earlier than StartDate.");

        CompanyId = companyId;
        JobPositionId = jobPositionId;
        RequestedWorkersCount = requestedWorkersCount;
        StartDate = startDate;
        EndDate = endDate;
        Notes = notes;

        Status = OrderStatus.Draft;;
    }

    public string Name { get; private set; }
    public int CompanyId { get; private set; }

    public int JobPositionId { get; private set; }

    public int RequestedWorkersCount { get; private set; }

    public DateOnly StartDate { get; private set; }
    public DateOnly? EndDate { get; private set; }

    public OrderStatus Status { get; private set; }

    public string? Notes { get; private set; }

    public void Publish()
    {
        EnsureNotCancelled();
        EnsureNotCompleted();

        if (Status != OrderStatus.Draft)
            throw new InvalidOperationException("Only Draft order can be published.");

        Status = OrderStatus.Published;
    }

    public void StartFulfillment()
    {
        EnsureNotCancelled();
        EnsureNotCompleted();

        if (Status != OrderStatus.Published)
            throw new InvalidOperationException("Only Published order can be moved to InProgress.");

        Status = OrderStatus.InProgress;
    }

    public void Complete()
    {
        EnsureNotCancelled();

        if (Status != OrderStatus.Published && Status != OrderStatus.InProgress)
            throw new InvalidOperationException("Only Published or InProgress order can be completed.");

        Status = OrderStatus.Completed;
    }

    public void Cancel(string? reason = null)
    {
        if (Status == OrderStatus.Completed)
            throw new InvalidOperationException("Completed order cannot be cancelled.");

        if (Status == OrderStatus.Cancelled)
            return; 

        Status = OrderStatus.Cancelled;

        if (!string.IsNullOrWhiteSpace(reason))
            Notes = reason;
    }

    public void Unpublish()
    {
        EnsureNotCancelled();
        EnsureNotCompleted();

        if (Status != OrderStatus.Published)
            throw new InvalidOperationException("Only Published order can be reverted to Draft.");

        Status = OrderStatus.Draft;
    }

   
    public void Reopen(string? note = null)
    {
        if (Status != OrderStatus.Cancelled)
            throw new InvalidOperationException("Only Cancelled order can be reopened.");

        Status = OrderStatus.Draft;

        if (!string.IsNullOrWhiteSpace(note))
            Notes = note;
    }

    private void EnsureNotCancelled()
    {
        if (Status == OrderStatus.Cancelled)
            throw new InvalidOperationException("Cancelled order cannot change state.");
    }

    private void EnsureNotCompleted()
    {
        if (Status == OrderStatus.Completed)
            throw new InvalidOperationException("Completed order cannot change state.");
    }

}
