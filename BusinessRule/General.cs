using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRule
{
    public sealed class General
    {
        public class EnumCombo
        {
            private string nameMember;
            private int idMember;

            public EnumCombo(string Name, int Code)
            {
                nameMember = Name;
                idMember = Code;
            }

            public string Member
            {
                get { return nameMember; }
            }

            public int Id
            {
                get { return idMember; }
            }
        }

        ///<sumary>
        ///Check if this date is value
        ///</sumary>
        ///<param name="Date"></param>
        ///<returns></returns>
        public static bool IsDate(string Date)
        {
            DateTime testDate;
            CultureInfo ci = new CultureInfo("pt-BR");

            try
            {
                testDate = DateTime.Parse(Date, ci);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if the a value is valid.
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static bool IsNumeric(string Number)
        {
            double testNumber;
            CultureInfo ci = new CultureInfo("pt-BR");

            try
            {
                if (Number.Equals(String.Empty) || Number.Equals(null))
                {
                    return false;
                }
                else
                {
                    testNumber = System.Double.Parse(Number, ci);
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Return of numbers with zero the left.
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="DigitsNumbers"></param>
        /// <returns></returns>
        public static string StrZero(int Number, int DigitsNumbers)
        {
            string outNumbers = null;
            int count = (DigitsNumbers - Number.ToString().Trim().Length);

            for (int i = 0; i < count; i++)
            {
                outNumbers += "0";
            }

            return (outNumbers + Number.ToString().Trim());
        }

        public static bool VerifyCnpj(string cnpjDocument)
        {
            //The number that compose CNPJ document is compose fro three the algarism,
            //being the first the registration number itself, the second (after the bar)
            //the filials number and third represent the last two values that are verifiers.
            //
            //Oficially the calculation the CPNJ numbers predicts also to the check the
            //eighth digits, but some companies have numbers that when validated
            //second this critery are considered invalids.
            //
            //That is why the secure is you do the validation the verifiers digits, 
            //because so any number will be invalid and your routine will be protect same, 
            //
            int total = 0;
            int weight = 5;
            string digit = null;
            bool returnValue = false;

            //Remove the caracters that will not be necessary for the calculation.
            cnpjDocument = cnpjDocument.Replace(".", String.Empty);
            cnpjDocument = cnpjDocument.Replace("-", String.Empty);
            cnpjDocument = cnpjDocument.Replace("/", String.Empty);

            if (cnpjDocument.Length >= 14)
            {
                digit = cnpjDocument.Substring(0, 12);

                for (int i = 0; i < 12; i++)
                {
                    total += Convert.ToInt32(cnpjDocument.Substring(i, 1)) * weight;

                    if(weight.Equals(2))
                    {
                        weight = 9;
                    }
                    else
                    {
                        weight--;
                    }
                }

                if(total % 11 <= 2)
                {
                    digit += "0";
                }
                else
                {
                    digit = Convert.ToString(11 - (total % 11));
                }

                weight = 6;
                total = 0;

                for (int i = 0; i < 13; i++)
                {
                    total += Convert.ToInt32(digit.Substring(i, 1)) * weight;

                    if (weight.Equals(2))
                    {
                        weight = 9;
                    }
                    else
                    {
                        weight--;
                    }
                }

                if(total % 11 <= 2)
                {
                    digit += "0";
                }
                else
                {
                    digit += Convert.ToString(11 - (total % 11));
                }

                if(digit == cnpjDocument)
                {
                    returnValue = true;
                }
            }

            return returnValue;
        }

        public static bool VerifyCpf(string cpfDocument)
        {
            //The CPF Documents is compose for eleven algarism, where the last two are called the
            //digits to checked, in other words, the last two digits are create leave
            //the first nine digits. The calculations is made in the two step to use the module to divise 11.

            int total = 0;
            int weigth = 10;
            string digit = null;
            bool returnCpf = false;

            if(cpfDocument.Length >= 11)
            {
                digit = cpfDocument.Substring(0, 9);

                //Calculation the first digit to atributte the weight how followed bellow
                //
                //+-----------------------------------------------------+
                //|Numbers of CPF Documents  | 2| 2| 2| 3| 3| 3| 6| 6| 6|
                //+--------------------------+--+--+--+--+--+--+--+--+--+
                //|Weights defined           |10| 9| 8| 7| 6| 5| 4| 3| 2|
                //+-----------------------------------------------------+ 

                for(int i = 0; i < 9; i++)
                {
                    total += Convert.ToInt32(cpfDocument.Substring(i, 1)) * weigth;
                    weigth--;
                }

                //Case the result the division for 11 be less or equal the 2,
                //the first digit will be 0, else if the digit will be the result the 
                //subtraction 11 - (total % 11)
                if(total % 11 <= 2)
                {
                    digit += "0";
                }
                else
                {
                    digit += Convert.ToString(11 - (total % 11));
                }

                weigth = 11;
                total = 0;

                //Case the second digits, to add the first digit
                //calculation how if observe bellow
                //+-----------------------------------------------------+
                //|Numbers of CPF Documents  | 2| 2| 2| 3| 3| 3| 6| 6| 6|
                //+--------------------------+--+--+--+--+--+--+--+--+--+
                //|Weights defined           |10| 9| 8| 7| 6| 5| 4| 3| 2|
                //+-----------------------------------------------------+ 

                for (int i = 0; i < 10; i++)
                {
                    total += Convert.ToInt32(digit.Substring(i, 1)) * weigth;
                    weigth--;
                }

                //Case the result the division for 11 to be less or equals the 2,
                //the second digit will be 0, else if the digit will be the result
                //the subtraction 11 - (total % 11)
                if(total % 11 <= 2)
                {
                    digit += "0";
                }
                else
                {
                    digit += Convert.ToString(11 - (total % 11));
                }

                if(digit == cpfDocument)
                {
                    returnCpf = true;
                }

            }
            return returnCpf;
        }

        ///<summary>
        /// Return a string with spaces the right case the entrace will less
        /// than parameters length, else if truncate with string
        ///</summary>
        ///<param name="entry"></param>
        ///<param name="lenght"></param>
        ///<returns></returns>
        public static string Truncate(string entry, int length)
        {
            string exit = null;

            if(entry.Equals(String.Empty) || entry.Equals(null))
            {
                for (int i = 0; i < length; i++)
                {
                    exit += " ";
                }
            }
            else
            {
                if (entry.Length > length)
                {
                    exit = entry.Substring(0, length);
                }
                else
                {
                    exit = entry.Trim();

                    for(int i = 0; i < (length - entry.Trim().Length); i++)
                    {
                        exit += " ";
                    }
                }
            }

            return exit;
        }

        public static string RemoveAccents(string inputValue)
        {
            string letter = null;
            string outValue = null;

            string[] accent = {"ç", "Ç", "á", "Á", "à", "à", "Â", "â", "é", "É", "ê", "Ê",
                                    "í", "Í", "ó", "Ó","ô", "Ô", "õ", "Õ", "ú", "Ú","ñ" ,"Ñ", ",", "(", ")", "/"};

            string[] sem_acento = {"c", "C", "a", "A", "a", "A", "a", "A", "a", "A", "e", "E", "e", "E",
                                    "i", "I", "o", "O", "o", "O", "o", "O", "u", "U", "n", "N", String.Empty, String.Empty, String.Empty, "_"};

            for (int i = 0; i < inputValue.Length; i++)
            {
                for (int x = 0; x < accent.Length; x++)
                {
                    if(inputValue.Substring(i, 1).Equals(accent[x]))
                    {
                        letter = sem_acento[x];
                        break;
                    }
                    else
                    {
                        letter = inputValue.Substring(i, 1);
                    }
                }

                outValue += letter;
            }

            return outValue.ToUpper().Replace(" ", "_");
        }

        public static string Left(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }

        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = param.Substring((param.Length - length), length);
            //return the result of the operation
            return result;
        }
    }
}
