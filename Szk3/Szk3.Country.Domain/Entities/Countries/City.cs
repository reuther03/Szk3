using Szk3.Common.Domain.Entities;

namespace Szk3.Country.Domain.Entities.Countries
{
    public class City : EntityBase<int>
    {
        public string Name { get; private set; } = null!;
        public bool IsActive { get; private set; }

        protected City() { }

        internal City(string name, bool isActive = true)
        {
            Name = name;
            IsActive = isActive;
        }

        public void Activate() => IsActive = true;

        public void Deactivate() => IsActive = false;
    }
}
