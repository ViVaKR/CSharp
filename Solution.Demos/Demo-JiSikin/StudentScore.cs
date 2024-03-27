using Helper;
public class Student
{
    public string Name { get; set; } = string.Empty;
    public int[] Score { get; set; }

    public Student(string name, int[] score)
    {
        Name = name;
        Score = score;
    }
}
