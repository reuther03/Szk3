using Szk3.Common.Domain.Entities;

namespace Szk3.Country.Domain.Entities.Countries
{
    public class Country : AggregateRoot<int>
    {
        public string Name { get; private set; } = null!;

        public string Code { get; private set; } = null!;

        public bool IsActive { get; private set; }

        private readonly List<City> _cities = new();
        public IReadOnlyCollection<City> Cities => _cities.AsReadOnly();

        protected Country() { }

        public Country(string name, string code, bool isActive = true)
        {
            Name = name;
            Code = code;
            IsActive = isActive;
        }

        public void AddCity(string name, bool isActive = true)
        {
            _cities.Add(new City(name, isActive));
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
    }
}
