using System;
using System.Collections.Generic;

public class HealthSystemApp
{
    private Repository<Patient> _patientRepo = new Repository<Patient>();
    private Repository<Prescription> _prescriptionRepo = new Repository<Prescription>();
    private Dictionary<int, List<Prescription>> _prescriptionMap = new Dictionary<int, List<Prescription>>();

    public void SeedData()
    {
        _patientRepo.Add(new Patient(1, "John Doe", 30, "Male"));
        _patientRepo.Add(new Patient(2, "Jane Smith", 25, "Female"));
        _patientRepo.Add(new Patient(3, "Alice Johnson", 40, "Female"));

        _prescriptionRepo.Add(new Prescription(1, 1, "Medication A", DateTime.Now));
        _prescriptionRepo.Add(new Prescription(2, 1, "Medication B", DateTime.Now));
        _prescriptionRepo.Add(new Prescription(3, 2, "Medication C", DateTime.Now));
        _prescriptionRepo.Add(new Prescription(4, 3, "Medication D", DateTime.Now));
        _prescriptionRepo.Add(new Prescription(5, 3, "Medication E", DateTime.Now));
    }

    public void BuildPrescriptionMap()
    {
        foreach (var prescription in _prescriptionRepo.GetAll())
        {
            if (!_prescriptionMap.ContainsKey(prescription.PatientId))
            {
                _prescriptionMap[prescription.PatientId] = new List<Prescription>();
            }
            _prescriptionMap[prescription.PatientId].Add(prescription);
        }
    }

    public void PrintAllPatients()
    {
        foreach (var patient in _patientRepo.GetAll())
        {
            Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Gender: {patient.Gender}");
        }
    }

    public void PrintPrescriptionsForPatient(int patientId)
    {
        if (_prescriptionMap.ContainsKey(patientId))
        {
            foreach (var prescription in _prescriptionMap[patientId])
            {
                Console.WriteLine($"Prescription ID: {prescription.Id}, Medication: {prescription.MedicationName}, Date Issued: {prescription.DateIssued}");
            }
        }
        else
        {
            Console.WriteLine("No prescriptions found for this patient.");
        }
    }
}
