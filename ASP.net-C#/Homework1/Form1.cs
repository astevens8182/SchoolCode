using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
/// <summary>
/// this is the form class. 
/// xml file is read in
/// tax methods are called to calculate taxes and pay
/// validation methods are called
/// output is written to form report
/// bad records are written to new xml file
/// </summary>
namespace Homework1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Final storage of rate/pays from the other classes
        /// </summary>
        /// <var name="finalGrossPay">The final of gross pay</var>
        /// <var name="hoursworked"> number of hours worked in a week</var>
        /// <var name="payRate">the rate at which the employee gets paid</var>
        /// <var name="finalMichiganStateTax">final michigan state tax</var>
        /// <var name="finalFICATax">final for FICA tax</param>
        /// <var name="socialSecurityTax">final for social Security tax</var>
        /// <var name="medicareTax">final medicare tax</param>
        /// <var name="finalNetPay">final net pay </param>
        /// <var name="federalWithholdingTax">federal withholding tax</var>
        /// <var name="amountEarned">Yealry salary for employee</var>
        /// <var name="status">single or married</var>
        /// <var name="withholdings">number of withholdings for the current employee</var>
        /// 
        /// <var name="firstName">employee's first name</var>
        /// <var name="lastName">employee's last name</var>
        /// <var name="hoursWorkedXMl">employee's hours worked placholder for the xml file</var>
        /// <var name="payRateXML">pay rate from the xml file before validation</var>
        /// <var name="amountEarnedXML">amount earned from the xml file before validation</var>
        /// <var name="statusXML">single or married status before validation</param>
        /// <var name="isValidEntry">varible used to determine if whole record has any errors or not</var>
        /// <var name="withholdingsXML ">number of withholdings in xml file before validation</var>
        /// 
        ///<var name="numRecsProcessed">number of records processed</var>
        ///<var name="numRecError">number of inccorect records</var>
        ///<var name="errorMessage">the error message that is displayed on the error xml file</var>

        decimal finalGrossPay = 0;
        decimal hoursWorked = 0;
        decimal payRate = 0;
        decimal finalMichiganStateTax = 0;
        decimal finalFICATax = 0;
        decimal socialSecurtiyTax = 0;
        decimal medicareTax = 0;
        decimal finalNetPay = 0;
        decimal federalWithholdingTax = 0;
        decimal amountEarned = 0;
        string  status = "";
        decimal withholdings = 0;



        string firstName = "";
        string lastName = "";
        string hoursWorkedXML = "";
        string payRateXML = "";
        string amountEarnedXML = "";
        string statusXML = "";
        bool isValidEntry = true;
        string withholdingsXML = "";

        double numRecProcesed = 0;
        double numRecError = 0;
        string errorMessage = "";

        XmlWriter writer = XmlWriter.Create("OutPayrollErrordaterun.xml");

        private void btnCalculate_Click(object sender, EventArgs e)

        {
            rtxtReport.Text += ("Employee Name".PadRight(18) + "Hours Worked".PadRight(17) + "Pay Rate".PadRight(13) + "Gross Pay".PadRight(14) + "State Tax".PadRight(15) + "FICA Tax".PadRight(13) + "withholdings Tax".PadRight(21) + "Net Pay");

            ///reading the xml file in from bin debug
            using (XmlReader reader = XmlReader.Create("InPayroll.xml"))
            {
                while (reader.Read())

                {
                    
               
                    if (reader.IsStartElement())
                    {
                        /// checks to see is the elemenmt is the right one
                        /// runs approaite validation class's
                        /// writes/counts bad records to a new xml file
                        /// set isValidEntry apporaitly
                        /// where needed converts data types to decimal from xml file after validation

                        switch (reader.Name)
                        {
                            ///when case is equal to the first name field
                            case "FirstName":
                                firstName = reader.ReadElementContentAsString();
                                ///checks to see if there is a value in the element
                               if (Validator.IsPresentStrings(firstName))
                                {
                                }
                                else
                                {
                                    isValidEntry = false;
                                    errorMessage = "field cannot be empty";
                                }
                                break;

                             ///when case is equal to the last name field
                            case "LastName":

                                lastName = reader.ReadElementContentAsString();
                                /// checks to see if there is a value in the element
                                 if (Validator.IsPresentStrings(lastName))
                                {
                                }
                                else
                                {
                                    isValidEntry = false;
                                    errorMessage = "field cannot be empty";
                                }
                                break;

                             /// when the case is equal to the hours worked field
                            case "HoursWorked":
                                hoursWorkedXML = reader.ReadElementContentAsString();
                                /// checks to see if there is a value in the element
                                  if (Validator.IsPresentStrings(hoursWorkedXML))
                                {
                                    /// checks to see if the value is a decimal 
                                    if (Validator.IsDecimal(hoursWorkedXML))
                                    {
                                        /// checks to see if it is within range 
                                        /// if yes converts the number to decimal for later calculations
                                        if (Validator.IsWithinRange(hoursWorkedXML, 0M, 60M))
                                        {
                                            hoursWorked = Convert.ToDecimal(hoursWorkedXML);
                                        }
                                        else
                                        {
                                            isValidEntry = false;
                                            errorMessage = "needs to be a number between 0 - 60";
                                        }

                                    }
                                    else
                                    {
                                        isValidEntry = false;
                                        errorMessage = "needs to be a number between 0 - 60";
                                    }

                                }
                                else
                                {
                                   isValidEntry = false;
                                    errorMessage = "needs to be a number between 0 - 60";
                                }
                                break;
                            /// when the case is equal to the pay rate field
                            case "PayRate":
                                payRateXML = reader.ReadElementContentAsString();
                                ///checks to see if there is a value in the element
                                if (Validator.IsPresentStrings(payRateXML))
                                {
                                    ///checks to see if the value is a decimal
                                    if (Validator.IsDecimal(payRateXML))
                                    {
                                        ///checks to see if the value is within range
                                        ///if true, converts to decimal for further calculations
                                        if (Validator.IsWithinRange(payRateXML, 0M, 999999999999M))
                                        {
                                            payRate = Convert.ToDecimal(payRateXML);
                                        }
                                        else
                                        {
                                            isValidEntry = false;
                                            errorMessage = "needs to be a number greater than 0";

                                        }

                                    }
                                    else
                                    {
                                        isValidEntry = false;
                                        errorMessage = "needs to be a number greater than 0";

                                    }

                                }
                                else
                                {
                                    isValidEntry = false;
                                    errorMessage = "needs to be a number greater than 0";

                                }
                                break;
                            ///when case eqauls the amount earned per year
                            case "AmountEarnedPerYear":
                                amountEarnedXML = reader.ReadElementContentAsString();
                                /// checks if there is a value in the element
                                if (Validator.IsPresentStrings(amountEarnedXML))
                                {
                                    ///checks to see if the value is a decimal
                                    if (Validator.IsDecimal(amountEarnedXML))
                                    {
                                        ///checks to see if the value is within range
                                        ///if true, value is converted to deciaml for later calculation
                                        if (Validator.IsWithinRange(amountEarnedXML, 0M, 999999999999M))
                                        {
                                            amountEarned = Convert.ToDecimal(amountEarnedXML);
                                        }
                                        else
                                        {
                                            isValidEntry = false;
                                            errorMessage = "needs to be a number greater than 0";

                                        }

                                    }
                                    else
                                    {
                                        isValidEntry = false;
                                        errorMessage = "needs to be a number greater than 0";

                                    }

                                }
                                else
                                {
                                    isValidEntry = false;
                                    errorMessage = "needs to be a number greater than 0";

                                }
                                break;
                            /// when case is equal to single or married 
                            case "SingleOrMarried":
                                statusXML = reader.ReadElementContentAsString();
                                ///checks to see if there is a value in the element
                                ///Checks to see if the value is either S of M for status 
                                ///if true, converts to string for later calculation
                                  if (Validator.IsPresentStringsSingleOrMarried(statusXML))
                                {
                                    status = Convert.ToString(statusXML);
                                }
                                else
                                {
                                    isValidEntry = false;
                                    errorMessage = "field cannot be empty";


                                }
                                break;
                            /// when case equals number of withholdings element
                            case "NumberOfWithholdings":
                                withholdingsXML = reader.ReadElementContentAsString();
                                /// checks to see if there is a value in the element
                                 if (Validator.IsPresentStrings(withholdingsXML))
                                {
                                    /// checks to see if the value is a decimal 
                                    if (Validator.IsDecimal(withholdingsXML))
                                    {
                                        ///checks to see if the value is within range
                                        if (Validator.IsWithinRange(withholdingsXML, 0M, 20M))
                                        {
                                            withholdings = Convert.ToDecimal(withholdings);
                                        }
                                        else
                                        {
                                            isValidEntry = false;
                                            errorMessage = "Needs to be number within 0 - 20";
                                        }
                                    }
                                    else
                                    {
                                        isValidEntry = false;
                                        errorMessage = "Needs to be number within 0 - 20";
                                    }
                                }
                                else
                                {
                                    isValidEntry = false;
                                    errorMessage = "Needs to be number within 0 - 20";
                                }
                                ///Checks to see if whole entry is valid, if valid calculates tax/pay and writes output to form
                                if (isValidEntry )
                                {
                                    numRecProcesed += 1;
                                    finalGrossPay = TaxCalculations.GrossPayCalculation(finalGrossPay, payRate, hoursWorked);
                                    finalMichiganStateTax = TaxCalculations.MichiganStateTaxCalculation(finalMichiganStateTax, finalGrossPay);
                                    medicareTax = TaxCalculations.MedicareTaxCalc(medicareTax, finalGrossPay);
                                    socialSecurtiyTax = TaxCalculations.SocialSecurityTaxCalc(socialSecurtiyTax, amountEarned, finalGrossPay);
                                    federalWithholdingTax = TaxCalculations.FederalWithholdingTaxCalc(federalWithholdingTax, status, withholdings, finalGrossPay);
                                    finalFICATax = TaxCalculations.FICATaxCalc(finalFICATax, medicareTax, socialSecurtiyTax);
                                    finalNetPay = TaxCalculations.NetPayCalc(finalNetPay, finalGrossPay, finalMichiganStateTax, finalFICATax, federalWithholdingTax);

                                    rtxtReport.Text += Environment.NewLine;
                                    rtxtReport.Text += Environment.NewLine;


                                    rtxtReport.Text += (Convert.ToString(firstName) + " " + lastName).PadRight(25) + String.Format(" {0:0.00}", hoursWorked) +String.Format("${0:0.00}", payRate).PadLeft(21) + String.Format("${0:0.00}", finalGrossPay).PadLeft(15)+String.Format("${0:0.00}", finalMichiganStateTax).PadLeft(15)+String.Format("${0:0.00}", finalFICATax).PadLeft(17) + String.Format("${0:0.00}", federalWithholdingTax).PadLeft(20) + String.Format("${0:0.00}", finalNetPay).PadLeft(19);

                                    ///resets all varibles to nothing, in preperation for next entry
                                    firstName = "";
                                    lastName = "";
                                    hoursWorked = 0;
                                    payRate = 0;
                                    finalGrossPay = 0;
                                    finalMichiganStateTax = 0;
                                    medicareTax = 0;
                                    socialSecurtiyTax = 0;
                                    federalWithholdingTax = 0;
                                    finalFICATax = 0;
                                    finalNetPay = 0;


                                }
                                
                                else 
                                {
                                    
                                    numRecError += 1;
                                    writer.WriteStartElement("Employee");
                                    writer.WriteStartElement("firstname");
                                    writer.WriteString(firstName);
                                    writer.WriteEndElement();
                                    writer.WriteStartElement("lastName");
                                    writer.WriteString(lastName);
                                    writer.WriteEndElement();
                                    writer.WriteStartElement("errorMsg");
                                    writer.WriteString(errorMessage);
                                    writer.WriteEndElement();
                                    isValidEntry = true;

                                    
                                  

                                }
                               
                                break;

                        }
                    }
                }
            }

            rtxtReport.Text += Environment.NewLine;

            rtxtReport.Text += "Number of records processed: " + numRecProcesed;
            rtxtReport.Text += Environment.NewLine;
            rtxtReport.Text += "Number of records in error: " + numRecError;
            


        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            writer.Close();
        }

    }
}

