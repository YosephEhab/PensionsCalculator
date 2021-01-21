using PensionsCalculator.DTOs;

namespace PensionsCalculator.Models
{
    public class EmployeePaymentViewModel : EmployeePayment
    {
        public override string LastFiveYearSalaries { get => string.Join(", ", First, Second, Third, Fourth, Fifth); set => base.LastFiveYearSalaries = value; }
        public decimal First { get; set; }
        public decimal Second { get; set; }
        public decimal Third { get; set; }
        public decimal Fourth { get; set; }
        public decimal Fifth { get; set; }
    }
}
