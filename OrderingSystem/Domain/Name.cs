using System;

namespace OrderingSystem.Domain
{
    public class Name
    {
        protected Name() { } // for NHibernate

        public Name(string firstName, string lastName)
            : this(firstName, null, lastName)
        { }

        public Name(string firstName, string middleName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name must be defined.");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name must be defined.");

            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public virtual string FirstName { get; private set; }
        public virtual string MiddleName { get; private set; }
        public virtual string LastName { get; private set; }

        public bool Equals(Name other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.FirstName, FirstName) &&
                Equals(other.MiddleName, MiddleName) &&
                Equals(other.LastName, LastName);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Name);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = FirstName.GetHashCode();
                result = (result * 397) ^ (MiddleName != null ? MiddleName.GetHashCode() : 0);
                result = (result * 397) ^ LastName.GetHashCode();
                return result;
            }
        }

        public static bool operator ==(Name left, Name right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Name left, Name right)
        {
            return !Equals(left, right);
        }
    }
}