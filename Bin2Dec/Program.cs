using Bin2Dec.Shared;

bool userWantsToExit = false;

while (!userWantsToExit)
{
    string binaryNumber = "";
    Console.WriteLine("Please enter a binary number");
    bool inputIsValid = false;
    while (!inputIsValid)
    {
        var input = Console.ReadLine();
        if (!String.IsNullOrEmpty(input) && (input.ToLower() == "exit" || input.ToLower() == "quit" || input.ToLower() == "stop"))
        {
            userWantsToExit= true;
            break;
        }
        inputIsValid = Bin2DecConverter.InputIsValidBinaryNumber(input);
        if (!inputIsValid)
        {
            Console.WriteLine("Please enter a valid binary number. (Example: 101010)");
        }
        else
        {
            binaryNumber = input;
        }
    }
    if (!userWantsToExit)
    {
        Console.WriteLine($"{binaryNumber} in decimal would be: {Bin2DecConverter.ConvertBinaryToDecimal(binaryNumber)}");
    }

}
