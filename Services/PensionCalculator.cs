using System;
using System.Linq;

namespace PensionsCalculator.Services
{
    public class PensionCalculator
    {
        private readonly PensionCSVHelper _pensionCSVHelper;
        
        public PensionCalculator(PensionCSVHelper pensionCSVHelper)
        {
            _pensionCSVHelper = pensionCSVHelper;
        }

        public decimal? CalculatePension(bool deceased, decimal lastFiveYearAverageSalary, int workedMonths = 0)
        {
            if (deceased)
            {
                return CalculateDeceasedPension(lastFiveYearAverageSalary);
            }
            else
            {
                return CalculateRetiredPension(lastFiveYearAverageSalary, workedMonths);
            }
        }

        #region Helper methods

        private decimal? CalculateRetiredPension(decimal lastFiveYearAverageSalary, int workedMonths)
        {
            decimal multiplicationFactor = GetRetiredPensionMultiplicationFactor();
            return lastFiveYearAverageSalary * workedMonths * multiplicationFactor;
        }
        
        private decimal? CalculateDeceasedPension(decimal lastFiveYearAverageSalary)
        {
            decimal multiplicationFactor = GetDeceasedPensionMultiplicationFactor();
            return lastFiveYearAverageSalary * multiplicationFactor;
        }

        private decimal GetRetiredPensionMultiplicationFactor()
        {
            var retiredPensions = _pensionCSVHelper.ReadRetiredPensions();
            return retiredPensions.Average(p => p.Pension / (p.Months * p.Average));
        }

        private decimal GetDeceasedPensionMultiplicationFactor()
        {
            var deceasedPensions = _pensionCSVHelper.ReadDeceasedPensions();
            return deceasedPensions.Average(p => p.Pension / p.Average);
        }

        #endregion
    }
}