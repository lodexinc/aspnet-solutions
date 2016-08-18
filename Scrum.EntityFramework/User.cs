using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.EntityFramework
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public String Email { get; set; }
        public String PasswordHash { get; set; }
        public String FirsName { get; set; }
        public String LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
