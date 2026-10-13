using System.Linq;

List<double> grades = new List<double>();

Console.WriteLine("Enter 5 grades:");

for (int i = 1; i <= 5; i++)
{
    double grade;
    Console.Write($"Grade {i}: ");

    while (!double.TryParse(Console.ReadLine(), out grade))
    {
        Console.Write("Invalid number, try again: ");
    }

    grades.Add(grade);
}

double highest = grades.Max();
double lowest = grades.Min();
double average = grades.Average();

Console.WriteLine();
Console.WriteLine($"Highest grade: {highest}");
Console.WriteLine($"Lowest grade: {lowest}");
Console.WriteLine($"Average grade: {average:F2}");
