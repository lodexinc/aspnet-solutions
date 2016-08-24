using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.EntityFramework
{
    public class IssueStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String ID { get; set; }
        public String Name { get; set; }
    }
}
