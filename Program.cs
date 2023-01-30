//sums two integer taken as a string that can be infinite digit.

string str1 = "99999";
string str2 = "9999900";
string equal = "";

//swaps strings if first one has higher length
if (str1.Length > str2.Length)
{
    string temp = str1;
    str1 = str2;
    str2 = temp;
}
//get lenght differences between two strings
//put 0 at the beginning of the smaller one
int fark = str2.Length - str1.Length;
for (int i = 0; i < fark; i++)
{
    str1 = "0" + str1;
}

int index = 0;
int remaining = 0;
while (index < str1.Length)
{
    //convert char to int
    int num1 = str1[str1.Length - 1 - index] - '0';
    int num2 = str2[str2.Length - 1 - index] - '0';

    //calculate sum and remaining values
    int sum = (num1 + num2 + remaining) % 10;
    remaining = (num1 + num2 + remaining) / 10;

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

//write it to console
Console.WriteLine(equal);
