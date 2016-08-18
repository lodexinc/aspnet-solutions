using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Domain.Entities
{
    public class JobSeeker
    {
        public JobSeeker() { }

        public static JobSeeker NOT_EXIST
        {
            get { return new JobSeeker(String.Empty, String.Empty, String.Empty, false); }
        }

        public JobSeeker(String email, String firstName, String lastName, bool active)
        {
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Active = active;
        }

        public String Email { get; private set; }
        public String FirstName { get; private set; }
        public String MiddleName { get; set; }
        public String LastName { get; private set; }

        public bool Active { get; private set; }

        public void DeActive()
        {
            this.Active = false;
        }
        public void ReActive()
        {
            this.Active = true;
        }

        public override bool Equals(object obj)
        {
            if (obj is JobSeeker)
            {
                JobSeeker otherJobSeeker = obj as JobSeeker;
                return this.Email.Equals(otherJobSeeker.Email, StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Email.GetHashCode();
        }
    }
}
