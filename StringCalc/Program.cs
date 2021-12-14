using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

public class StringCalculator
{

    public static void Main(string[] args)
    {
        StringCalculator calculator = new StringCalculator();
        var input = Console.ReadLine();
        Console.WriteLine(calculator.Add(input));
    }
    public  int Add(string Numbers)
    {
        if (Numbers == "" || Numbers == string.Empty)
        {
            return 0;
        }
        

        Numbers = handleString(Numbers);
        checkNegative(Numbers);
        
        if (Numbers == "1")
        {
            return 1;
        }
        Numbers = RemoveLargeNumber(Numbers);
        
        return sum(splitString(Numbers));

    }

    private static string[] splitString(string input)
    {
        string[] numbers = input.Split(",");
        return numbers;
    }


    private static int intParser(string number)
    {
        if(!string.IsNullOrEmpty(number))
            if (char.IsDigit(Convert.ToChar(number)))
                return Int32.Parse(number);
            else
                return 0;
        else
        {
            return 0;
        }
    }

    private static int sum(string[] Numbers)
    {
        int sum = 0;

        foreach (var number in Numbers)
        {
            sum += intParser(number);
        }

        return sum;
    }

    public static int countBrackets(string input)
    {
        int count = 0;
        foreach (var c in input)
        {
            if (c == '[')
                count++;
        }

        return count;
    }

    private static string handleString(string input)
    {
        input = input.Replace("\n", ",");

        var countbrackets = countBrackets(input);

        List<string> delims = new List<string>();

        if (input.StartsWith("//["))
        {
            input = input.Remove(0, 2);
            for (int i = 0; i < countbrackets; i++)
            {
                var opentbrack = input.IndexOf("[");
                var closebrack = input.IndexOf("]");
                //extract delim
                string delim = input.Substring(opentbrack + 1, closebrack - 1);
                //Check fror -
                if (delim.Contains("-"))
                {
                    throw new InvalidEnumArgumentException($"Invalid delim :{delim}");
                }
                delims.Add(delim);
                input = input.Substring(2 + delim.Length);
            }

            input = input.Remove(0,01);
            foreach (var delim in delims)
            {
                input = input.Replace(delim, ",");
            }

            return input;

        }

        if (input.StartsWith("//"))
        {
            //extract delim
            string delim = input.Substring(2, 3);
            //Check fror -
            if (delim.Contains("-"))
            {
                throw new InvalidEnumArgumentException($"Invalid delim :{delim}");
            }

            input = input.Substring(4);
            input = input.Replace(delim, ",");
        }

        return input;
    }

    private static string RemoveLargeNumber(string input)
    {
        StringBuilder stringBuilder = new StringBuilder();
        
        string[] nums = splitString(input);

        foreach (var num in nums)
        {
            if (intParser(num) <= 1000)
            {
                stringBuilder.Append(num + ",");
            }
        }

        return stringBuilder.ToString();

    }

    private static void  checkNegative(string input)
    {
        string[] negativeNumbers = splitString(input);
        string negative = "";
        foreach (var negativeNumber in negativeNumbers)
        {
            if (negativeNumber.Contains("-"))
            {
                negative += negativeNumber + ",";
            }
        }

        if (!string.IsNullOrEmpty(negative))
        {
            throw new ArgumentException("Negative Number not Allowed");
        }
    }
}

