using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class TimeAngleCalculation {
        
        const double HOURHANDLE_MINUTELENGTH = 5;
        const double MINUTE_DEGREES = 6;
        const int HOUR_DEGREES = 30;
        private delegate double GetClockHourHandGradePositionInsideTheHour(double mins);

        private static double reglaDeTresBaseMinutos(double minuto)
        {
            return minuto / 60;
        }               

        static GetClockHourHandGradePositionInsideTheHour insideTheHourClockHandPosition = minutes => MINUTE_DEGREES * (HOURHANDLE_MINUTELENGTH * reglaDeTresBaseMinutos(minutes));
        
        ///<summary> method for Time-Angle Calculation
        /// <param name = "hour" > hours (hh). Used to indicate hours </ param >
        /// <param name = "minutes" > minutes (mm). Used to indicate minutes </ param >
        /// </summary>
        public static double getInnerAngle(double hour, double minutes)
        {
            double hourHandleDegrees = (((hour) * HOUR_DEGREES) - insideTheHourClockHandPosition(minutes));
            double innerAngle = 0;
            double angleA = 0;
            double angleB = 0;           

            double minuteHandle = minutes * MINUTE_DEGREES;
            if (minuteHandle > hourHandleDegrees)
            {
                angleA = minuteHandle - (hourHandleDegrees);
            }
            else
            {
                angleA = (hourHandleDegrees) - minuteHandle;
            }

            angleB = 360 - angleA;

            if (angleA > 180)
            {
                innerAngle = angleB;
            }
            else
            {
                innerAngle = angleA;
            }


            return innerAngle;
        }        
    }


    public static class RomanNumeral
    {
        public static string toRomanNumeral(this int decimalNumber)
        {
            string romanNumeral = string.Empty;
            if (decimalNumber > 0 && decimalNumber <= 3999)
            {
                string romanChar = string.Empty;                
                string stringNumber =  decimalNumber.ToString();
                int len = stringNumber.Length;

                Console.WriteLine("Decimal System Number: " + stringNumber);
                foreach (char charNum in stringNumber)
                {
                    int num = int.Parse(charNum.ToString());
                    switch (len)
                    {
                        case 4:
                            if (num >= 1 && num <= 3)
                            {
                                romanChar = "M";
                            }
                            break;
                        case 3:
                            if (num == 0)
                            {
                                romanChar = "";
                            }
                            if (num >= 1 && num <= 3)
                            {
                                romanChar = "C";
                            }
                            else if (num == 4)
                            {
                                romanChar = "CD";
                            }
                            else if (num == 5)
                            {
                                romanChar = "D";
                            }
                            else if (num == 6)
                            {
                                romanChar = "DC";
                            }
                            else if (num == 7)
                            {
                                romanChar = "DCC";
                            }
                            else if (num == 8)
                            {
                                romanChar = "DCCC";
                            }
                            else if (num == 9)
                            {
                                romanChar = "CM";
                            }
                            break;
                        case 2:
                            if (num == 0)
                            {
                                romanChar = "";
                            }
                            if (num >= 1 && num <= 3)
                            {
                                romanChar = "X";
                            }
                            else if (num == 4)
                            {
                                romanChar = "XL";
                            }
                            else if (num == 5)
                            {
                                romanChar = "L";
                            }
                            else if (num == 6)
                            {
                                romanChar = "LX";
                            }
                            else if (num == 7)
                            {
                                romanChar = "LXX";
                            }
                            else if (num == 8)
                            {
                                romanChar = "LXXX";
                            }
                            else if (num == 9)
                            {
                                romanChar = "XC";
                            }
                            break;
                        case 1:
                            if (num == 0)
                            {
                                romanChar = "";
                            }
                            if (num >= 1 && num <= 3)
                            {
                                romanChar = "I";
                            }
                            else if (num == 4)
                            {
                                romanChar = "IV";
                            }
                            else if (num == 5)
                            {
                                romanChar = "V";
                            }
                            else if (num == 6)
                            {
                                romanChar = "VI";
                            }
                            else if (num == 7)
                            {
                                romanChar = "VII";
                            }
                            else if (num == 8)
                            {
                                romanChar = "VIII";
                            }
                            else if (num == 9)
                            {
                                romanChar = "IX";
                            }
                            break;
                    }

                    if (num >= 1 && num <= 3)
                    {
                        int n = 0;
                        do
                        {
                            romanNumeral += romanChar;
                            n++;
                        } while (n < num);
                    }
                    else
                    {
                        romanNumeral += romanChar;
                    }
                    len--;
                }

                Console.WriteLine("Roman Numeral: " + romanNumeral);
            }
            return romanNumeral;
        }
    }

    

    class Program
    {
        static void Main(string[] args)
        {
            3009.toRomanNumeral();
            
            stringCompression("aabcccccaa");

            swapTwoIntegers(5,10);

            #region Anagram
            string wordA = "California", wordB = "forniacali";
            Console.WriteLine(string.Format("Are words \"{0}\" & \"{1}\" Anagrams?:  {2}", wordA, wordB, areAnagrams(wordA, wordB)));
            #endregion

            #region Time-Angle Calculation

            
            double hour = 0 ;
            double minutes = 0;

            do
            {
                Console.Write("Write the Hour 12 hours format(hh): ");

                string line  = Console.ReadLine();
                double value = -1;
                if (!string.IsNullOrEmpty(line)) {
                    if (double.TryParse(line, out value))
                    {                                                                                 
                        if (value >= 1 && value <= 12)
                        {
                                hour = value;
                                value = 0;
                            Console.Write("Write the Minutes (mm): ");                        
                            line = Console.ReadLine();
                            if (!string.IsNullOrEmpty(line))
                            {
                                if (double.TryParse(line, out value))
                                {
                                    if (value >= 0 && value <= 59)
                                    {
                                        minutes = value;
                                        Console.WriteLine(string.Format(" Inner Angle is: {0} degrees ", TimeAngleCalculation.getInnerAngle(hour, minutes)));
                                    }
                                    else
                                    {
                                        Console.WriteLine("minutes valid values are between 0 and 59..");
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("hours valid values shoud be in 12hrs format..");
                        }
                    }
                    
                 }

                if (line.ToUpper() == "E")
                {
                   Console.WriteLine("Exited.... press any key");
                  break;
                }
               
                Console.WriteLine("Press  \"(E) = Exit\" Time-Angle Calculation");

            } while (true);


            #endregion



            Console.ReadLine();

        }

        
        public static string stringCompression(string toCompress)
        {
            #region Constans 
            const int SumCharInAPairCounting = 1;
            #endregion

            #region declarations            
            List<string> listCompressed = new List<string>();
            int counter = 0, length = 0;
            Nullable<char> nextChar = null;
            string stringCompressed = string.Empty;
            #endregion

            if (!string.IsNullOrEmpty(toCompress))
            {
                length = toCompress.Length;

                Console.WriteLine("String to Compress: " + toCompress);

                for (int i = 0; i < length; i++)
                {
                    if ((i + 1) < length)
                    {
                        nextChar = toCompress[i + 1];
                    }
                    else
                    {
                        nextChar = null;
                    }


                    if (toCompress[i].Equals(nextChar))
                    {
                        counter++;
                    }
                    else
                    {
                        if (counter > 0)
                        {
                            listCompressed.Add(toCompress[i].ToString());
                            listCompressed.Add((counter + SumCharInAPairCounting).ToString());
                            counter = 0;
                        }
                        else
                        {
                            listCompressed.Add(toCompress[i].ToString());
                        }
                    }
                }
                stringCompressed = string.Join(String.Empty, listCompressed.ToArray());
            }

            Console.WriteLine("String Compressed: " + stringCompressed);
            return stringCompressed;

        }

        static void swapTwoIntegers(int a, int b)
         {
            Console.WriteLine("Original Values  a = " + a + ", b = "  + b);
            a = a * b;
            b = a / b;
            a = a / b;
            Console.WriteLine(" Swap result: a = " + a + ", b = " + b);
        }
        
           

        static bool areAnagrams(string one, string two)
        {
            var s1 = one.Replace(" ", string.Empty).ToUpper();
            var s2 = two.Replace(" ", string.Empty).ToUpper();

            if (s1.Length != s2.Length)
            {
                return false;
            }

            foreach (var c1 in s1)
            {
                int index = 0;
                if ((index = s2.IndexOf(c1)) > -1)
                {
                    s2 = s2.Remove(index, 1);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }                  
        
    }
}
