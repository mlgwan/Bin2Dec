using System.Numerics;

namespace Bin2Dec.Shared
{
    public static class Bin2DecConverter
    {
        public static bool InputIsValidBinaryNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            foreach (var symbol in input)
            {
                if (symbol != '0' && symbol != '1')
                {
                    return false;
                }
            }
            return true;
        }

        public static BigInteger ConvertBinaryToDecimal(string binaryNumber)
        {
            if (InputIsValidBinaryNumber(binaryNumber))
            {
                BigInteger result = 0;
                for (int i = 0; i < binaryNumber.Length; i++)
                {
                    if (binaryNumber[i] == '1')
                    {
                        result++;
                    }
                    if (i < binaryNumber.Length - 1)
                    {
                        result *= 2;
                    }
                }

                return result;
            }
            else
            {
                throw new InvalidDataException();
            }
           
        }
    }
}
