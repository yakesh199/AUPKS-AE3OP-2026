Random random = new Random();

Console.WriteLine("Dice Game");
Console.WriteLine("---------");

int myRoll;
int computerRoll;

do
{
    myRoll = random.Next(1, 7);
    computerRoll = random.Next(1, 7);

    Console.WriteLine($"Your roll: {myRoll}");
    Console.WriteLine($"Computer roll: {computerRoll}");

    if (myRoll > computerRoll)
    {
        Console.WriteLine("You win!");
    }
    else if (myRoll < computerRoll)
    {
        Console.WriteLine("Computer wins!");
    }
    else
    {
        Console.WriteLine("Tie! Rolling again...");
        Console.WriteLine();
    }
}
while (myRoll == computerRoll);
