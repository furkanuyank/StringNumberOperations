    //String Number Operations
    public static class SNOperations
    {
        //it returns true if string format matches number otherwise it returns false.
        public static bool chechIfNumber(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                int code = str[i];
                if (code < 48 || code > 57)
                {
                    return false;
                }
            }
            return true;
        }

        public static string sum(string string1, string string2)
        {
            //check if strings that taken as a parameters are number.
            if (!(chechIfNumber(string1) && chechIfNumber(string2)))
            {
                throw new FormatException("Both of strings need to be number format.");
            }

            string num1 = string1;
            string num2 = string2;
            string equal = "";

            //swaps strings if first one has higher length
            if (num1.Length > num2.Length)
            {
                string temp = num1;
                num1 = num2;
                num2 = temp;
            }
            //get lenght differences between two strings
            //put 0 at the beginning of the smaller one
            int fark = num2.Length - num1.Length;
            for (int i = 0; i < fark; i++)
            {
                num1 = "0" + num1;
            }

            int index = 0;
            int remaining = 0;
            while (index < num1.Length)
            {
                //convert char to int
                int digit1 = num1[num1.Length - 1 - index] - '0';
                int digit2 = num2[num2.Length - 1 - index] - '0';

                //calculate sum and remaining values
                int sum = (digit1 + digit2 + remaining) % 10;
                remaining = (digit1 + digit2 + remaining) / 10;

                //add new value at the beginning of the equal
                equal = sum.ToString() + equal;

                //increase index for iterating
                index++;
            }
            //if there is still remaining add it to at the beginning of equal
            if (remaining != 0)
            {
                equal = remaining.ToString() + equal;
            }

            return equal;
        }

        public static string multiplication(string string1, string string2)
        {
            //check if strings that taken as a parameters are number.
            if (!(chechIfNumber(string1) && chechIfNumber(string2)))
            {
                throw new FormatException("Both of strings need to be number format.");
            }

            string num1 = string1;
            string num2 = string2;
            string[] multipliedStringsArray = new string[num1.Length];

            int remaining = 0;
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int currDigit = num1[i] - '0';
                string multipliedString = "";
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    //calculate sum and remaining values
                    int mult = ((currDigit * (num2[j] - '0')) + remaining) % 10;
                    remaining = ((currDigit * (num2[j] - '0')) + remaining) / 10;

                    multipliedString = mult.ToString() + multipliedString;

                }
                //if there is still remaining add it to at the beginning of equal
                if (remaining != 0)
                {
                    multipliedString = remaining.ToString() + multipliedString;
                    remaining = 0;
                }
                multipliedStringsArray[num1.Length - 1 - i] = multipliedString;
            }

            //calculate length of last multiplied string number
            int length = multipliedStringsArray[multipliedStringsArray.Length - 1].Length + multipliedStringsArray.Length - 1;

            //add 0 at the end and at the beginning of the multiplied strings in order to equal length.
            for (int i = 0; i < multipliedStringsArray.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    multipliedStringsArray[i] = multipliedStringsArray[i] + '0';
                }
                for (int k = 0; k < length - multipliedStringsArray[i].Length; k++)
                {
                    multipliedStringsArray[i] = '0' + multipliedStringsArray[i];
                }
            }

            //sum all multiplied string numbers to get result of multiplication.
            for (int i = 0; i < multipliedStringsArray.Length - 1; i++)
            {
                multipliedStringsArray[i + 1] = sum(multipliedStringsArray[i], multipliedStringsArray[i + 1]);
            }

            return multipliedStringsArray[multipliedStringsArray.Length - 1];
        }
    }
