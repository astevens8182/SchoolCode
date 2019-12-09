using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// This is the class where all the tax  and gross/net pay claculations are in  seperate methods 
/// </summary>
namespace Homework1
{
    class TaxCalculations
    {
   

        /// <summary>
        /// calculation of michigain state tax from gross pay
        /// </summary>
        /// <param name="michiganTaxC">where michigan tax is placed after calculation</param>
        /// <param name="grosspay">gross pay used in calculation</param>
        /// <constant name="MIrate">Michigan's state tax as a decimal from a percent</constant>
        /// <returns>Michigan State Tax</returns>
        public static decimal MichiganStateTaxCalculation(decimal michiganTaxC, decimal grosspayC)
        {
            decimal MIrate = 0.0425M;

            michiganTaxC = grosspayC * MIrate;

            return michiganTaxC;
        }
        /// <summary>
        /// Calculation of gross pay and the overtime if there is any
        /// </summary>
        /// <param name="grossPayc">Gross Pay</param>
        /// <param name="payRateC">The Pay Rate</param>
        /// <param name="hoursWorkedC">Total number of hours worked</param>
        /// <constant name="overtimeRate">the pay rate that is used for the overtime hours</constant>
        /// <returns>GrossPay</returns>
        public static decimal GrossPayCalculation(decimal grossPayc, decimal payRateC, decimal hoursWorkedC)
        {
            double overtimeRate = 1.5;
            if (hoursWorkedC <= 40)
            {
                grossPayc = payRateC * hoursWorkedC;
            }
            else 
            {
                grossPayc = 40 * payRateC;
                grossPayc += (hoursWorkedC - 40) * (payRateC *(Convert.ToDecimal(overtimeRate)));
            }
            return grossPayc;
        }
        /// <summary>
        /// calculation for the social security tax 
        /// </summary>
        /// <param name="socialSecurityC"> where the social security tax is place</param>
        /// <param name="yearlySalaryC">Employee's yearly salary</param>
        /// <param name="grossPayC">Gross pay for the employee</param>
        /// <constant name="ssiPercent"> the social security tax as decimal from a percent</constant>
        /// <constant name="yearlySa;aryCutOff">the maximum amount that of yearly salary taken from ssi</constant>
        /// <constant name= "cutOffWklyGrossPay">net pay a week of salary cut off</constant>
        /// <returns>Social Securtiy Tax </returns>
        public static decimal SocialSecurityTaxCalc( decimal socialSecurityC,decimal yearlySalaryC, decimal grossPayC)
        {
            decimal ssiPercent = 0.062M;
            decimal yearlySalaryCutOff = 1118501M;
            decimal cutOffWklyGrossPay = 118500/52M;

            if (yearlySalaryC < yearlySalaryCutOff)
            {
                socialSecurityC = grossPayC * ssiPercent;
            }
            else
            {
                socialSecurityC = (cutOffWklyGrossPay) * ssiPercent;
            }
            return socialSecurityC;
        }
        /// <summary>
        /// this is where fica tax is calculated from medicare and social security
        /// </summary>
        /// <param name="FICATaxC">where the final fica tax is placed</param>
        /// <param name="medicareTaxC">medicare tax</param>
        /// <param name="socailSecurityC">social security tax</param>
        /// <returns>FICA tax</returns>
        public static decimal FICATaxCalc(decimal FICATaxC, decimal medicareTaxC, decimal socailSecurityC)
        {
            FICATaxC = socailSecurityC + medicareTaxC;
            return FICATaxC;
        }

        /// <summary>
        /// this is where medicare tax is calculated
        /// </summary>
        /// <param name="medicareTaxC">final for medicare tax</param>
        /// <param name="grossPayC">employee's gross pay</param>
        /// <returns>medicare tax</returns>
        public static decimal MedicareTaxCalc(decimal medicareTaxC, decimal grossPayC)
        {
            decimal michiganMedicareRate = 0.0145M;

            medicareTaxC = grossPayC * michiganMedicareRate;

            return medicareTaxC;
        }

        /// <summary>
        /// this is where the employees net pay is calculated
        /// </summary>
        /// <param name="netPayC">net pay </param>
        /// <param name="grossPayC">gross pay</param>
        /// <param name="MITaxC">michigan state tax</param>
        /// <param name="FICATaxC">fica tax</param>
        /// <param name="FedWithholdingTax">federal withholding tax</param>
        /// <returns>net pay</returns>
        public static decimal NetPayCalc(decimal netPayC, decimal grossPayC, decimal MITaxC, decimal FICATaxC,decimal FedWithholdingTax)
        {
            netPayC = grossPayC - MITaxC - FICATaxC - FedWithholdingTax;

            return netPayC;
        }
        /// <summary>
        /// this is where federal withholding tax is calculated
        /// </summary>
        /// <param name="fedTaxC">federal tax </param>
        /// <param name="statusC">single or married status</param>
        /// <param name="withholdingAllowancesC">withholding allowances</param>
        /// <param name="grossPayC">gross pay</param>
        /// <returns>federal withholding tax</returns>
        public static decimal FederalWithholdingTaxCalc(decimal fedTaxC, string statusC, decimal withholdingAllowancesC, decimal grossPayC)
        {
           decimal awi = 0M;
            awi = grossPayC - (withholdingAllowancesC * 67.31M)  ;

            if (statusC == "S")
            {
                if (awi < 44)
                {
                    fedTaxC = 0;
                }
                if (awi > 43 & awi < 223)
                {
                    fedTaxC = (awi - 43M) * 1.1M;
                }
                if (awi > 222 & awi < 768)
                {
                    fedTaxC = (awi - 222M) * 1.15M + 17.90M;
                }
                if (awi > 767 & awi < 1797)
                {
                    fedTaxC = (awi - 767M ) * 1.25M + 99.65M;
                }
                if (awi > 1796 & awi < 3701)
                {
                    fedTaxC = (awi - 1796M ) * 1.28M + 356.90M;
                }
                if (awi > 3700 & awi < 7993)
                {
                    fedTaxC = (awi - 3700M ) * 1.33M + 890.02M;
                }
                if (awi > 7992 & awi < 8026)
                {
                    fedTaxC = (awi - 7992M ) * 1.35M + 2306.38M;
                }
                if (awi > 8025)
                {
                    fedTaxC = (awi - 8025M) * 1.396M + 2317.93M;
                }
            }
            else
            {
                if (awi < 164)
                {
                    fedTaxC = 0;
                }
                if (awi > 164 & awi < 522)
                {
                    fedTaxC = (awi - 164M) * 1.1M;
                }
                if (awi > 521 & awi < 1614)
                {
                    fedTaxC = (awi - 521M ) * 1.15M + 35.70M;
                }
                if (awi > 1613 & awi < 3087)
                {
                    fedTaxC = (awi - 1613M ) * 1.25M + 199.50M;
                }
                if (awi > 3086 & awi < 4616)
                {
                    fedTaxC = (awi - 3086M ) * 1.28M + 567.75M;
                }
                if (awi > 4615 & awi < 8114)
                {
                    fedTaxC = (awi - 4615M ) * 1.33M + 995.87M;
                }
                if (awi > 8113 & awi < 9145)
                {
                    fedTaxC = (awi - 8113 ) * 1.35M + 2150.21M;
                }
                if (awi > 9144)
                {
                    fedTaxC = (awi - 9144M ) * 1.396M + 2511.06M;
                }
            }
                    return fedTaxC;
        }


            
        }
    }

