using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Threading.Tasks;


namespace UserSite.Models
{
        public class Users
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Required]
            [MaxLength(9)]
            public string Id { get; set; }

            [Required]
            [MaxLength(50)]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [DataType(DataType.EmailAddress)]
            public string EmailAddress { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime Birthday { get; set; }

            public Gender? Gender { get; set; }

            public string PhoneNumber { get; set; }
        }
        public enum Gender
        {        
            Male,      
            Female,
            Else
        }
    }
