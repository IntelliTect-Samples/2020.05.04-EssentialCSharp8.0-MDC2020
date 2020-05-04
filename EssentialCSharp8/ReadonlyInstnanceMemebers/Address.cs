using System;
using System.Collections.Generic;
using System.Text;

namespace EssentialCSharp8.Tests.NullableReferenceTypes
{

    public struct Coordinate
    {
        public Coordinate(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
        public double Longitude { get; }
        public double Latitude { get; }
        public readonly override string ToString() => $"{ Longitude } { Latitude }";

        public void Deconstruct(out double longitude, out double latitude) => 
            (longitude, latitude) = (Longitude, Latitude);

        static public void SomeMethod()
        {

            Coordinate coordinate = new Coordinate(42, 42);
            coordinate.Deconstruct(out double longitude, out double latitude);
            Console.WriteLine($"blah, blah, {longitude}");

            (longitude, latitude) = coordinate;
        }

        static string GetContinent(Coordinate coordinate) => coordinate switch
        {

            var (longitude, latitude) when IsSourthAmerica(longitude, latitude) 
                => "South America",
            var (longitude, latitude) when IsNorthAmerica(coordinate) 
                => "North America",
            var (longitude, latitude) when IsAfrica(coordinate) 
                => "Africa",
            // ...
            _ => "ocean"
        };

        private static bool IsAfrica(Coordinate coordinate)
        {
            throw new NotImplementedException();
        }

        private static bool IsNorthAmerica(Coordinate coordinate)
        {
            throw new NotImplementedException();
        }

        private static bool IsSourthAmerica(double longitude, double coordinate)
        {
            throw new NotImplementedException();
        }
    }
}
