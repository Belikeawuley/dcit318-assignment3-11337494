class Program
{
    static void Main(string[] args)
    {
        HealthSystemApp app = new HealthSystemApp();
        app.SeedData();
        app.BuildPrescriptionMap();
        
        Console.WriteLine("All Patients:");
        app.PrintAllPatients();

        Console.WriteLine("\nEnter Patient ID to view prescriptions:");
        int patientId = int.Parse(Console.ReadLine() ?? "0");
        app.PrintPrescriptionsForPatient(patientId);
    }
}
