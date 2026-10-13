// Student Task Manager - final result of the .NET + C# Console Tutorial (Parts 1-6)

const int MaxTasks = 10;
const string AppName = "Student Task Manager";

List<TaskItem> tasks = new List<TaskItem>();

// Part 1-2: Welcome and input
ShowTitle();

Console.Write("Enter your name: ");
string name = Console.ReadLine()?.Trim() ?? "";
if (string.IsNullOrWhiteSpace(name))
{
    name = "Student";
}

Console.WriteLine($"Hello {name}! Welcome to {AppName}.");

// Part 4-5: Main application loop
bool running = true;

while (running)
{
    ShowMenu();

    int option = ReadInt("Choose: ");

    switch (option)
    {
        case 1:
            AddTask(tasks);
            break;

        case 2:
            ShowTasks(tasks);
            break;

        case 3:
            RemoveTask(tasks);
            break;

        case 4:
            ShowTaskCount(tasks);
            break;

        case 0:
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

Console.WriteLine($"Goodbye, {name}!");

// ---------- Methods (Part 5) ----------

void ShowTitle()
{
    Console.WriteLine();
    Console.WriteLine(AppName);
    Console.WriteLine("====================");
}

void ShowMenu()
{
    Console.WriteLine();
    Console.WriteLine("1. Add task");
    Console.WriteLine("2. View tasks");
    Console.WriteLine("3. Remove task");
    Console.WriteLine("4. Show task count");
    Console.WriteLine("0. Exit");
}

void ShowMessage(string message)
{
    Console.WriteLine($"[INFO] {message}");
}

// Part 2 + challenge 1: safe integer input that never crashes
int ReadInt(string prompt)
{
    while (true)
    {
        Console.Write(prompt);

        if (int.TryParse(Console.ReadLine(), out int value))
        {
            return value;
        }

        Console.WriteLine("Invalid input. Please enter a number.");
    }
}

// Part 6: enum input
TaskPriority ReadPriority()
{
    Console.WriteLine("Priority: 1. Low   2. Medium   3. High");
    int choice = ReadInt("Choose priority: ");

    return choice switch
    {
        1 => TaskPriority.Low,
        2 => TaskPriority.Medium,
        3 => TaskPriority.High,
        _ => TaskPriority.Medium
    };
}

void AddTask(List<TaskItem> tasks)
{
    // Part 6: constant limit
    if (tasks.Count >= MaxTasks)
    {
        Console.WriteLine("Maximum number of tasks reached.");
        return;
    }

    Console.Write("Enter task: ");
    string? taskName = Console.ReadLine();

    // Challenge 2: reject empty or whitespace-only tasks
    if (string.IsNullOrWhiteSpace(taskName))
    {
        Console.WriteLine("Task cannot be empty.");
        return;
    }

    TaskPriority priority = ReadPriority();
    tasks.Add(new TaskItem(taskName.Trim(), priority));

    ShowMessage("Task added.");

    // Part 6: enum with switch
    switch (priority)
    {
        case TaskPriority.Low:
            Console.WriteLine("This task can wait.");
            break;

        case TaskPriority.Medium:
            Console.WriteLine("Try to finish this task today.");
            break;

        case TaskPriority.High:
            Console.WriteLine("Prioritize this task.");
            break;
    }
}

void ShowTasks(List<TaskItem> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("No tasks available.");
        return;
    }

    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"{i + 1}. [{tasks[i].Priority}] {tasks[i].Name}");
    }
}

void RemoveTask(List<TaskItem> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("No tasks to remove.");
        return;
    }

    ShowTasks(tasks);

    int number = ReadInt("Task to remove: ");

    if (number < 1 || number > tasks.Count)
    {
        Console.WriteLine("Invalid task number.");
        return;
    }

    // The user counts from 1, the list counts from 0
    tasks.RemoveAt(number - 1);

    ShowMessage("Task removed.");
}

void ShowTaskCount(List<TaskItem> tasks)
{
    int count = tasks.Count;

    Console.WriteLine($"You currently have {count} tasks.");
    Console.WriteLine($"Maximum allowed: {MaxTasks}");
    Console.WriteLine($"Remaining capacity: {MaxTasks - count}");

    // Part 3: if / else if / else
    if (count == 0)
    {
        Console.WriteLine("Time to get started!");
    }
    else if (count < 3)
    {
        Console.WriteLine("Good start. Keep going!");
    }
    else
    {
        Console.WriteLine("Great progress!");
    }
}

// ---------- Types (Part 6) ----------

enum TaskPriority
{
    Low,
    Medium,
    High
}

record TaskItem(string Name, TaskPriority Priority);
