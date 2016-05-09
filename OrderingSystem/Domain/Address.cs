using System;

namespace OrderingSystem.Domain
{
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        protected Address() { } // for NHibernate

        public Address(string line1, string line2, string zipCode, string city, string state)
        {
            if (string.IsNullOrWhiteSpace(line1))
                throw new ArgumentException("Address line 1 must be defined.");
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentException("Zip code must be defined.");
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City must be defined.");
            if (string.IsNullOrWhiteSpace(state))
                throw new ArgumentException("State must be defined.");

            Line1 = line1;
            Line2 = line2;
            ZipCode = zipCode;
            City = city;
            State = state;
        }

        public bool Equals(Address other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Line1, Line1) &&
                Equals(other.Line2, Line2) &&
                Equals(other.ZipCode, ZipCode) &&
                Equals(other.City, City) &&
                Equals(other.State, State);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Address);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = Line1.GetHashCode();
                result = (result * 397) ^ (Line2 != null ? Line2.GetHashCode() : 0);
                result = (result * 397) ^ ZipCode.GetHashCode();
                result = (result * 397) ^ City.GetHashCode();
                result = (result * 397) ^ State.GetHashCode();
                return result;
            }
        }

        public static bool operator ==(Address left, Address right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Address left, Address right)
        {
            return !Equals(left, right);
        }
    }
}