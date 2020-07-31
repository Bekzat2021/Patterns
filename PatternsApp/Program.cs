using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatternsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TouristFromUS Tom = new TouristFromUS { Name = "Tom" };
            TouristFromUK Sam = new TouristFromUK { Name = "Sam" };

            ListOfLocations locationInEurope = new ListOfLocations();
            locationInEurope.Locations.Add(new City { Name = "Paris" });
            locationInEurope.Locations.Add(new City { Name = "Berlin" });
            locationInEurope.Locations.Add(new Country { Name = "Village1" });
            locationInEurope.Locations.Add(new City { Name = "Munich" });

            locationInEurope.VisitAllLocations(Tom);
        }
    }

    interface IVisitor
    {
        void VisitCity(City city);
        void VisitCountry(Country country);
    }

    class TouristFromUS : IVisitor
    {
        public string Name { get; set; }
        public void VisitCity(City city)
        {
            Console.WriteLine($"Tourist from US visit city {city.Name}");
        }

        public void VisitCountry(Country country)
        {
            Console.WriteLine($"Tourist from US visit country {country.Name}");
        }
    }

    class TouristFromUK : IVisitor
    {
        public string Name { get; set; }
        public void VisitCity(City city)
        {
            Console.WriteLine($"Tourist from England visit city {city.Name}");
        }

        public void VisitCountry(Country country)
        {
            Console.WriteLine($"Tourist from England visit country {country.Name}");
        }
    }

    interface ILocation
    {
        public string Name { get; set; }
        void Accept(IVisitor visitor);
    }

    class ListOfLocations
    {
        public List<ILocation> Locations { get; set; }
        public ListOfLocations()
        {
            Locations = new List<ILocation>();
        }
        public void VisitAllLocations(IVisitor visitor)
        {
            foreach (var item in Locations)
            {
                item.Accept(visitor);
            }
        }
    }

    class City : ILocation
    {
        public string Name { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitCity(this);
        }
    }

    class Country : ILocation
    {
        public string Name { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitCountry(this);
        }
    }
}
