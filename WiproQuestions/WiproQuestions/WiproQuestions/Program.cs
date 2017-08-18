using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiproQuestions
{
    class Program
    {
        public static bool IsNagativeNumber { get; set; }

        static void Main(string[] args)
        {
            #region EncodedArray
            Console.WriteLine("Encoded Array");
            Console.WriteLine("--------------");
            var encodedArray = new[] { -2, -7, 12, -15 };
            int arrayLength = encodedArray.Length;
            FindOriginalFirstAndSum(encodedArray, arrayLength);
            Console.WriteLine("--------------");
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region PIN
            Console.WriteLine("PIN Generation");
            Console.WriteLine("--------------");
            int alpha = 0, beta = 0, gamma = 1024;
            int pin = CreatePIN(alpha, beta, gamma);
            Console.WriteLine(pin);
            Console.WriteLine("--------------");
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region SumOfSumsOfDigits
            Console.WriteLine("SumOfSumsOfDigits");
            Console.WriteLine("--------------");
            int input = 582109;
            int result = SumOfSumsOfDigits(input);
            Console.WriteLine("Sum Of Sums Of Digits : {0}", result);
            Console.WriteLine("--------------");
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region Palindrome
            Console.WriteLine("Palindrome");
            Console.WriteLine("----------");
            string word = "mAlaYalAm";
            int palindromeValue = IsPalindrome(word);
            Console.WriteLine("Palindrome Value: {0}", palindromeValue);
            Console.WriteLine("----------");
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region DigitSum
            Console.WriteLine("Digit Sum");
            Console.WriteLine("----------");
            int number = -321;
            int digitSum = DigitSum(number);
            Console.WriteLine(digitSum);
            Console.WriteLine("-----------");
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            Console.ReadLine();
        }

        private static int DigitSum(int number)
        {
            if(!IsNagativeNumber)
            {
                IsNagativeNumber = number < 0;
            }

            int index = number < 0 ? 1 : 0;
            var numberCharArray = number.ToString().ToCharArray();
            int sum = 0;
            for (int i = index; i < numberCharArray.Length; i++)
            {
                sum = sum + Convert.ToInt32(numberCharArray[i].ToString());
            }

            if(IsNagativeNumber)
            {
                return sum <= 9 ? (-1*sum) : DigitSum(sum);
            }

            return sum <= 9 ? sum : DigitSum(sum);
        }

        private static int IsPalindrome(string word)
        {
            var wordCharArray = word.ToUpper().ToCharArray();
            var reverseWordCharArray = wordCharArray.Reverse();

            if(wordCharArray.SequenceEqual(reverseWordCharArray))
            {
                return 1;
            }
            return 2;
        }

        private static int SumOfSumsOfDigits(int input)
        {
            var inputCharArray = input.ToString().ToCharArray();
            int length = inputCharArray.Length;
            int sum = 0;
            for (int i = 0; i < (inputCharArray.Length); i++)
            {
                int value = Convert.ToInt32(inputCharArray[i].ToString());
                sum = sum + (length * value);
                length--;
            }
            return sum;
        }

        private static int CreatePIN(int alpha, int beta, int gamma)
        {
            string alphaString = GetAlpha(alpha);
            string betaString = GetBeta(beta);
            string gammaString = GetGamma(gamma);

            string pin = string.Concat(gammaString, betaString, alphaString);

            return Convert.ToInt32(pin);
        }

        private static string GetGamma(int gamma)
        {
            var gammaCharArray = gamma.ToString().ToCharArray();
            int length = gammaCharArray.Length;
            int hundredsIndex = length - 3;
            int unitsIndex = length - 1;
            char value;
            if(gamma <= 99)
            {
                value = gammaCharArray[unitsIndex];
                return value == '0' ? "9" : value.ToString(); 
            }
            else
            {
                value = gammaCharArray[hundredsIndex];
                return value == '0' ? "9" : value.ToString();
            }
        }

        private static string GetBeta(int beta)
        {
            var betaCharArray = beta.ToString().ToCharArray();
            int tensIndex = betaCharArray.Length - 2;
            if(betaCharArray.Length == 1)
            {
                return betaCharArray[0].ToString();
            }

            return betaCharArray[tensIndex].ToString();
        }

        private static string GetAlpha(int alpha)
        {
            string alphaString = alpha.ToString().ToCharArray().Last().ToString();

            return alphaString;

        }

        private static Result FindOriginalFirstAndSum(int[] input1,int input2)
        {
            int[] encodedArray = new int[input2];
            input1.CopyTo(encodedArray, 0);
            
            int index = (input2 - 2);

            for (int i = index; i >= 0; i--)
            {
                input1[i] = input1[i] - input1[i + 1];
            }

            for (int i = 0; i < input2; i++)
            {
                Console.WriteLine("Original : {0}, Encoded : {1}", input1[i], encodedArray[i]);
            }

            Result result = new Result();
            result.output1 = input1[0];
            result.output2 = SumOriginalArray(input1);

            Console.WriteLine("Frist Number: {0}", result.output1);
            Console.WriteLine("Sum : {0}", result.output2);

            return result;
        }

        private static int SumOriginalArray(int[] input1)
        {
            int sum = 0;
            for (int i = 0; i < input1.Length; i++)
            {
                sum = sum + input1[i];
            }

            return sum;
        }
    }

    public struct Result
    {
        public int output1;
        public int output2;
    };
}
