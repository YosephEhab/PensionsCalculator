using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PensionsCalculator.DTOs
{
    [DeceasedValidation]
    public class EmployeePayment
    {
        [Display(Name = "Facility")]
        public string Facility { get; set; }

        [Display(Name = "Last five years' salary")]
        public virtual string LastFiveYearSalaries { get; set; }

        private List<decimal> _lastFiveYearSalaries { get { return new List<decimal>(LastFiveYearSalaries.Split(',').ToList().Select(x => decimal.Parse(x))); } }

        [Display(Name = "Last five years' average salary")]
        public decimal? LastFiveYearAverage { get { return _lastFiveYearSalaries.Average(); } }

        [Display(Name = "Months worked")]
        public int? MonthsWorked { get; set; }

        public bool Deceased { get; set; }

    }

    [AttributeUsage(AttributeTargets.Class)]
    public class DeceasedValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!ValidateDeceasedEmployee(value as EmployeePayment))
            {
                return new ValidationResult("Please enter the number of months worked...");
            }

            return ValidationResult.Success;
        }

        private static bool ValidateDeceasedEmployee(EmployeePayment employeePayment) => !(!employeePayment.Deceased && employeePayment.MonthsWorked == null);
    }

}
