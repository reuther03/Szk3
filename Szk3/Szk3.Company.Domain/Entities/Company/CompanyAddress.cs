using Szk3.Common.Domain.Entities;

namespace Szk3.Country.Application.Entities.Company
{
   public class CompanyAddress : EntityBase<int>
    {
        protected CompanyAddress() { }

        public CompanyAddress(
            string street,
            string buildingNumber,
            string? apartmentNumber,
            string postalCode,
            string city,
            string country,
            bool isActive = true)
        {
            Street = street;
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
            PostalCode = postalCode;
            City = city;
            Country = country;
            IsActive = isActive;
        }

        public string Street { get; private set; } = null!;
        public string BuildingNumber { get; private set; } = null!;
        public string? ApartmentNumber { get; private set; }

        public string PostalCode { get; private set; } = null!;
        public string City { get; private set; } = null!;
        public string Country { get; private set; } = null!;

        public bool IsActive { get; private set; }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
        }
    }
}
