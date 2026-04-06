using Szk3.Common.Domain.Entities;

namespace Szk3.Company.Domain.Entities.Company
{
    public class CompanyOwner : EntityBase<int>
    {
        protected CompanyOwner() { }

        public CompanyOwner(string fullName, string? phoneNumber, string? email)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string FullName { get; private set; } = null!;

        public string? PhoneNumber { get; private set; }

        public string? Email { get; private set; }

        public void UpdateContact(string? phoneNumber, string? email)
        {
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
