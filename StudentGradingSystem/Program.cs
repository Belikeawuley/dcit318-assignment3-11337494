using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        const string inputFilePath = "students.txt";
        const string outputFilePath = "report.txt";

        var processor = new StudentResultProcessor();

        try
        {
            var students = processor.ReadStudentsFromFile(inputFilePath);
            
            if (students.Count == 0)
            {
                Console.WriteLine("Warning: No valid student records were processed.");
            }
            else
            {
                processor.WriteReportToFile(students, outputFilePath);
                Console.WriteLine($"Successfully processed {students.Count} student(s). Report saved to '{outputFilePath}'");
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine($"Error: The input file '{inputFilePath}' was not found.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine($"Error: The directory containing '{inputFilePath}' was not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.Error.WriteLine($"Error: You don't have permission to access '{inputFilePath}'");
        }
        catch (IOException ex)
        {
            Console.Error.WriteLine($"Error reading/writing file: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
