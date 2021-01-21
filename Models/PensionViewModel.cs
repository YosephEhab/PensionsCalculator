using PensionsCalculator.DTOs;

namespace PensionsCalculator.Models
{
    public class PensionViewModel : EmployeePayment
    {
        public PensionViewModel()
        {
        }

        public PensionViewModel(EmployeePayment employeePayment)
        {
            Facility = employeePayment?.Facility;
            MonthsWorked = employeePayment?.MonthsWorked;
            Deceased = employeePayment != null && employeePayment.Deceased;
            LastFiveYearSalaries = employeePayment?.LastFiveYearSalaries;
        }

        public decimal Pension { get; set; }
    }
}
