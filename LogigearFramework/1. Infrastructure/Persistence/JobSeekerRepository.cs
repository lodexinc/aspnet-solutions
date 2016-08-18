using LogiGear.Domain.Entities;
using LogiGear.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogiGear.Domain.Repositories.Shared;
using System.Linq.Expressions;
using LogiGear.Infrastructure.Persistence.Entities;

namespace LogiGear.Infrastructure.Persistence
{
    public class JobSeekerRepository : IJobSeekerRepository
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<User> _userRepository;
        public JobSeekerRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._userRepository = this._unitOfWork.RepositoryOf<User>();
        }

        public JobSeeker Save(JobSeeker jobSeeker)
        {
            User user = new User();
            user.Email = jobSeeker.Email;
            user.FirstName = jobSeeker.FirstName;
            user.MiddleName = jobSeeker.MiddleName;
            user.LastName = jobSeeker.LastName;
            this._userRepository.Save(user);
            this._unitOfWork.Commit();               
            return jobSeeker;
        }

        public JobSeeker FindUniqueJobSeeker(string email)
        {
            return this._userRepository.FindBy(u => u.Email.Equals(email))
                .Select(u => new JobSeeker(u.Email, u.FirstName, u.LastName, u.IsActive) 
                {
                    MiddleName = u.MiddleName 
                }).SingleOrDefault();
        }

        public JobSeeker Update(JobSeeker entity)
        {
            throw new NotImplementedException();
        }

        public JobSeeker Delete(JobSeeker entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobSeeker> FindBy(Expression<Func<JobSeeker, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IQueryable<JobSeeker> GetAll()
        {
            throw new NotImplementedException();
        }


    }
}
