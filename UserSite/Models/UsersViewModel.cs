using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserSite.Models
{
    public class UsersViewModel
    {
        [Key]
        [Required]
        [MaxLength(9)]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Birthday { get; set; }
        public Gender? Gender { get; set; }
        public string PhoneNumber { get; set; }
    }

}
