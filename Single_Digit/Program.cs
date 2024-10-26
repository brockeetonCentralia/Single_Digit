UserInput();

static void UserInput()
{
    while (true)
    {
        Console.WriteLine("Enter a postive number (or type 'quit' to exit program): ");
        string number = Console.ReadLine();

        if (number.ToLower() == "quit")
        {
            break;
        }

        if (IsValidInput(number))
        {
            Dictionary<string, int> memo = new Dictionary<string, int>();

            int result = GetSingleDigit(number, memo);
            
            Console.WriteLine($"Your number {number}, has the single digit result of {result}.");
        }
        
        else
        {
            Console.WriteLine("Invalid input. Enter a valid positive number.");
        }
    }
}

static bool IsValidInput(string number)
{
    foreach (char c in number)
    {
        if (!char.IsDigit(c))
        {
            return false;
        }
    }

    return true;
}
static int GetSingleDigit(string number, Dictionary<string, int> memo)
{
    if (number.Length == 1)
    {
        return int.Parse(number);
    }

    if (memo.ContainsKey(number))
    {
        return memo[number];
    }

    string newNumber = "";

    for (int i = 0; i < number.Length - 1; i++)
    {
        int digit1 = int.Parse(number[i].ToString());
        int digit2 = int.Parse(number[i + 1].ToString());
        newNumber += Math.Abs(digit1 - digit2).ToString();
    }

    newNumber = newNumber.Trim('0');

    if (newNumber == "")
    {
        memo[number] = 0;
        return 0;
    }

    int result = GetSingleDigit(newNumber, memo);
    memo[number] = result;

    return result;
}

