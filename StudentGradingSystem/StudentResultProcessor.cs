using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class StudentResultProcessor
{
    public List<Student> ReadStudentsFromFile(string inputFilePath)
    {
        if (string.IsNullOrWhiteSpace(inputFilePath))
        {
            throw new ArgumentNullException(nameof(inputFilePath));
        }

        var students = new List<Student>();

        using var reader = new StreamReader(inputFilePath);
        
        string? line;
        int lineNumber = 0;

        while ((line = reader.ReadLine()) is not null)
        {
            lineNumber++;
            try
            {
                var fields = line.Split(',')
                    .Select(f => f.Trim())
                    .ToArray();

                if (fields.Length != 3)
                {
                    throw new MissingFieldException(
                        $"Line {lineNumber}: Expected 3 fields, found {fields.Length}");
                }

                if (!int.TryParse(fields[2], out int score))
                {
                    throw new InvalidScoreFormatException(
                        $"Line {lineNumber}: Could not parse score '{fields[2]}'");
                }

                students.Add(new Student
                {
                    Id = int.Parse(fields[0]),
                    FullName = fields[1],
                    Score = score
                });
            }
            catch (Exception ex) when (ex is MissingFieldException or InvalidScoreFormatException)
            {
                Console.WriteLine($"Skipping invalid record: {ex.Message}");
            }
        }

        return students;
    }

    public void WriteReportToFile(List<Student> students, string outputFilePath)
    {
        if (students == null)
        {
            throw new ArgumentNullException(nameof(students));
        }
        
        if (string.IsNullOrWhiteSpace(outputFilePath))
        {
            throw new ArgumentNullException(nameof(outputFilePath));
        }

        using var writer = new StreamWriter(outputFilePath);
        
        foreach (var student in students)
        {
            writer.WriteLine(
                $"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}");
        }
    }
}
