using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidPaynes.Models
{
    public class Min18YearsOldForMembership : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.DOB == null)
                return new ValidationResult("Date of Birth is Required");

            var age = DateTime.Today.Year - customer.DOB.Value.Year;

            if (age >= 18)
                return ValidationResult.Success;
            else
                return new ValidationResult("Customer must be 18 for Rolling Membership");
        }
    }
}