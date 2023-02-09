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

    //it takes two string numbers, compares them and return which is lesser one.
    //if string numbers are equal, returns it.
    public static string min(string string1, string string2)
    {
        //check if strings that taken as a parameters are number.
        if (!(chechIfNumber(string1) && chechIfNumber(string2)))
        {
            throw new FormatException("Both of strings need to be number format.");
        }

        string num1 = string1;
        string num2 = string2;
        // firstly, it makes equal length of both numbers.
        if (string1.Length > string2.Length)
        {
            for (int i = 0; i < string1.Length - string2.Length; i++)
            {
                num2 = "0" + num2;
            }
        }
        else
        {
            for (int i = 0; i < string2.Length - string1.Length; i++)
            {
                num1 = "0" + num1;
            }
        }
        //then, it compares numbers digit by digit to find out whic is lesser.
        for (int i = 0; i < string1.Length; i++)
        {
            if (num1[i] < num2[i])
            {
                return string1;
            }
            else if (num1[i] > num2[i])
            {
                return string2;
            }
        }
        return string1;
    }

    //it takes two string numbers, compares them and return which is greater one.
    //if string numbers are equal, returns it.
    public static string max(string string1, string string2)
    {
        //check if strings that taken as a parameters are number.
        if (!(chechIfNumber(string1) && chechIfNumber(string2)))
        {
            throw new FormatException("Both of strings need to be number format.");
        }

        string num1 = string1;
        string num2 = string2;
        // firstly, it makes equal length of both numbers.
        if (string1.Length > string2.Length)
        {
            for (int i = 0; i < string1.Length - string2.Length; i++)
            {
                num2 = "0" + num2;
            }
        }
        else
        {
            for (int i = 0; i < string2.Length - string1.Length; i++)
            {
                num1 = "0" + num1;
            }
        }
        //then, it compares numbers digit by digit to find out whic is lesser.
        for (int i = 0; i < string1.Length; i++)
        {
            if (num1[i] > num2[i])
            {
                return string1;
            }
            else if (num1[i] < num2[i])
            {
                return string2;
            }
        }
        return string1;
    }

    //it takes two string numbers, compares them and return
    //1 if first parameter greater than other
    //-1 if first parameter lesser than
    //0 if both string numbers are equal
    public static int compare(string string1, string string2)
    {
        //check if strings that taken as a parameters are number.
        if (!(chechIfNumber(string1) && chechIfNumber(string2)))
        {
            throw new FormatException("Both of strings need to be number format.");
        }

        string num1 = string1;
        string num2 = string2;
        // firstly, it makes equal length of both numbers.
        if (string1.Length > string2.Length)
        {
            for (int i = 0; i < string1.Length - string2.Length; i++)
            {
                num2 = "0" + num2;
            }
        }
        else
        {
            for (int i = 0; i < string2.Length - string1.Length; i++)
            {
                num1 = "0" + num1;
            }
        }
        //then, it compares numbers digit by digit to find out which is lesser, greater or equal.
        for (int i = 0; i < string1.Length; i++)
        {
            if (num1[i] > num2[i])
            {
                return 1;
            }
            else if (num1[i] < num2[i])
            {
                return -1;
            }
        }
        return 0;
    }


    //it trims zeros at the beginning of number.
    //if the number ful of zero then it return only 0.
    public static string fixZeros(string number)
    {
        string num = number.TrimStart('0');
        if (num == "")
        {
            return "0";
        }
        return num;
    }

    //sums two string numbers.
    public static string summation(string string1, string string2)
    {
        //check if strings that taken as a parameters are number.
        if (!(chechIfNumber(string1) && chechIfNumber(string2)))
        {
            throw new FormatException("Both of strings need to be number format.");
        }

        string num1 = string1;
        string num2 = string2;
        string equal = "";

        //swaps strings if first one has greater length
        if (num1.Length > num2.Length)
        {
            string temp = num1;
            num1 = num2;
            num2 = temp;
        }
        //get lenght differences between two strings
        //put 0 at the beginning of the lesser one
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

        return fixZeros(equal);
    }

    //multiply two string numbers.
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
            multipliedStringsArray[i + 1] = summation(multipliedStringsArray[i], multipliedStringsArray[i + 1]);
        }

        return fixZeros(multipliedStringsArray[multipliedStringsArray.Length - 1]);
    }

    //extract two string numbers.
    public static string extraction(string string1, string string2)
    {
        //check if strings that taken as a parameters are number.
        if (!(chechIfNumber(string1) && chechIfNumber(string2)))
        {
            throw new FormatException("Both of strings need to be number format.");
        }

        //checks if result will be negative or positive.
        bool isNegative = min(string1, string2) == string1 ? true : false;
        string num1 = string1;
        string num2 = string2;
        string result = "";

        // it makes equal length of both numbers.
        if (string1.Length > string2.Length)
        {
            for (int i = 0; i < string1.Length - string2.Length; i++)
            {
                num2 = "0" + num2;
            }
        }
        else
        {
            for (int i = 0; i < string2.Length - string1.Length; i++)
            {
                num1 = "0" + num1;
            }
        }
        //swaps if first string number that taken is lesser than other.
        if (min(num1, num2) == num1)
        {
            string temp = num2;
            num2 = num1;
            num1 = temp;
        }

        //calculate digit by digit from left to right and transfer ten to right digit if it needed.
        bool isNeedTen = false;
        for (int i = 0; i < num1.Length - 1; i++)
        {
            int digit1 = num1[i] - '0';
            int digit2 = num2[i] - '0';
            int digit1Next = num1[i + 1] - '0';
            int digit2Next = num2[i + 1] - '0';

            if (digit1Next < digit2Next)
            {
                if (isNeedTen)
                {
                    result = result + ((digit1 + 9) - digit2);
                }
                else
                {
                    result = result + ((digit1 - 1) - digit2);
                }
                isNeedTen = true;
            }
            else
            {
                if (isNeedTen)
                {
                    result = result + ((digit1 + 10) - digit2);
                }
                else
                {
                    result = result + (digit1 - digit2);
                }
                isNeedTen = false;
            }
        }
        //calculates for last digit separately.
        int lastDigit1 = num1[num1.Length - 1];
        int lastDigit2 = num2[num2.Length - 1];
        if (isNeedTen)
        {
            result = result + ((lastDigit1 + 10) - lastDigit2);
        }
        else
        {
            result = result + (lastDigit1 - lastDigit2);
        }

        if (isNegative)
        {
            return "-" + fixZeros(result);
        }
        return fixZeros(result);
    }
}
