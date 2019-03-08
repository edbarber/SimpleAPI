using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApp.Metadata
{
    public class EmployeeMetadata
    {
        [Display(Name = "First name" )]
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
    }

    [ModelMetadataType(typeof(EmployeeMetadata))]
    public class Employee : Models.Employee, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return ValidationResult.Success;
        }
    }
}
