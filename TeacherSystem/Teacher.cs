class Teacher
{
    private string name;
    private string subject;
    private int yearsOfExperience;

    public static int TotalTeachers = 0;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Subject
    {
        get { return subject; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                subject = value;
            }
        }
    }

    public int YearsOfExperience
    {
        get { return yearsOfExperience; }
        set
        {
            if (value >= 0)
            {
                yearsOfExperience = value;
            }
        }
    }

    public Teacher(string name, string subject, int yearsOfExperience)
    {
        Name = name;
        Subject = subject;
        YearsOfExperience = yearsOfExperience;
        TotalTeachers++;
    }

    public void ShowProfile()
    {
        Console.WriteLine($"{Name} - {Subject} - {YearsOfExperience} years of experience");
    }
}
