using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebox.MvcIntegratedAngularJs.Feature.JobSeekerAccount
{
    public class JobSeeker
    {
        public JobSeeker(String email, 
            String firstName, String lastName, JobSeekerType type)
        {
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Type = type;
        }

        public String Email { get; private set; }
        public String FirstName { get; private set; }
        public String LastName { get; private set; }

        public JobSeekerType Type { get; set; }

        #region Behaviors
        public bool IsActive { get; private set; }
        public void SetActive()
        {
            if (!IsActive)
            {
                this.IsActive = true;
            }            
        }

        #endregion

    }

    public class COOP : JobSeeker
    {
        public COOP(string email, String firstName, string lastName) 
            : base(email, firstName, lastName, JobSeekerType.COOP)
        {
        }
    }

    public class Fresh : JobSeeker
    {
        public Fresh(string email, string firstName, string lastName)
            : base(email, firstName, lastName, JobSeekerType.Fresh)
        {
        }
    }

    public class MidCareer : JobSeeker
    {
        public MidCareer(string email, string firstName, string lastName) 
            : base(email, firstName, lastName, JobSeekerType.MidCareer)
        {
        }
    }

    public class Executive : JobSeeker
    {
        public Executive(string email, string firstName, string lastName) 
            : base(email, firstName, lastName, JobSeekerType.Executive)
        {
        }
    }

    public enum JobSeekerType
    {
        COOP,
        Fresh,
        MidCareer,
        Executive
    }
}