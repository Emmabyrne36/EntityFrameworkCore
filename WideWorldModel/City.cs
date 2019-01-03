using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class City
    {
        public City()
        {
            Order = new HashSet<Order>();
            Sale = new HashSet<Sale>();
        }

        public int CityKey { get; set; }
        public int WwiCityId { get; set; }
        public string City1 { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
        public string SalesTerritory { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public long LatestRecordedPopulation { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int LineageKey { get; set; }

        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
