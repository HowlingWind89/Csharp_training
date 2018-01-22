using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactData
    {
        private string first;
        private string last;

        public ContactData(string first)
        {
            this.first = first;
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
