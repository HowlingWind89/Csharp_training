using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string first;
        private string last;

        public ContactData(string last, string first)
        {
            this.last = last;
            this.first = first;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return LastName == other.LastName && FirstName == other.FirstName;
        }

        public override int GetHashCode()
        {
          return LastName.GetHashCode() + FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return "LastName=" + LastName + " FirstName=" + FirstName;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return LastName.CompareTo(other.LastName) + FirstName.CompareTo(other.FirstName);
        }

        public string FirstName
        {
            get
            {
                return first;
            }

            set
            {
                first = value;
            }
        }

        public string LastName
        {
            get
            {
                return last;
            }

            set
            {
                last = value;
            }
        }
    }
}
