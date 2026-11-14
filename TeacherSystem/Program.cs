Teacher teacher1 = new Teacher("Ana Lopez", "Mathematics", 12);
Teacher teacher2 = new Teacher("Luis Mora", "Physics", 7);

Console.WriteLine("The first two teachers are:");
teacher1.ShowProfile();
teacher2.ShowProfile();

List<Teacher> teachers = new List<Teacher>();

teachers.Add(teacher1);
teachers.Add(teacher2);

bool running = true;

while (running)
{
    Console.WriteLine("\n=== TEACHER SYSTEM ===");
    Console.WriteLine("1. Add a teacher");
    Console.WriteLine("2. Show teachers");
    Console.WriteLine("3. Count teachers");
    Console.WriteLine("4. Average years of experience");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");
    string option = Console.ReadLine();

    if (option == "1")
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Subject: ");
        string subject = Console.ReadLine();

        Console.Write("Years of experience: ");
        string experienceText = Console.ReadLine();

        int experience = 0;
        int.TryParse(experienceText, out experience);

        Teacher teacher = new Teacher(name, subject, experience);
        teachers.Add(teacher);

        Console.WriteLine("The teacher was added.");
        teacher.ShowProfile();
    }
    else if (option == "2")
    {
        if (teachers.Count == 0)
        {
            Console.WriteLine("There are no teachers yet.");
        }
        else
        {
            foreach (Teacher teacher in teachers)
            {
                teacher.ShowProfile();
            }
        }
    }
    else if (option == "3")
    {
        Console.WriteLine($"There are {teachers.Count} teachers.");
        Console.WriteLine($"Teachers created in total: {Teacher.TotalTeachers}");
    }
    else if (option == "4")
    {
        if (teachers.Count == 0)
        {
            Console.WriteLine("There are no teachers yet.");
        }
        else
        {
            double total = 0;

            foreach (Teacher teacher in teachers)
            {
                total += teacher.YearsOfExperience;
            }

            double average = total / teachers.Count;
            Console.WriteLine($"Average years of experience: {average}");
        }
    }
    else if (option == "5")
    {
        running = false;
        Console.WriteLine("Goodbye!");
    }
    else
    {
        Console.WriteLine("Invalid option. Try again.");
    }
}
