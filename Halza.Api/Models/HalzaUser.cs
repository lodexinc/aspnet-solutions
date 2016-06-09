using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Halza.Api.Models
{
    public class HalzaUser
    {
        [Key]
        public String ID { get; set; }
        public String AccountID { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        [ForeignKey("AccountID")]
        public ApplicationUser Identity { get; set; }

    }
}