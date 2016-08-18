using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Infrastructure.Persistence.Entities
{
    public class User
    {
        public User()
        {
            this.ID = Guid.NewGuid().ToString();
        }

        [Key]
        public String ID { get; private set; }

        [Required]
        [MaxLength(50)]
        public String Email { get; set; }

        [Required]
        [MaxLength(50)]
        public String FirstName { get; set; }

        public String MiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        public String LastName { get; set; }

        public bool IsActive { get; set; }
    }
}
