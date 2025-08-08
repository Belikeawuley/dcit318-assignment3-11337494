public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty; // Initialize to avoid null warnings
    public int Score { get; set; }

    public string GetGrade()
    {
        if (Score < 0 || Score > 100) // Added validation
        {
            throw new ArgumentOutOfRangeException(nameof(Score), "Score must be between 0 and 100");
        }

        return Score switch
        {
            >= 80 and <= 100 => "A",
            >= 70 => "B",
            >= 60 => "C",
            >= 50 => "D",
            _ => "F"
        };
    }
}
