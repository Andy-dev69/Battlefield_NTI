using System;
using System.Collections.Generic;

namespace Battlefield_NTI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Frågeställning till användaren
            Console.Write("Ange hur många elever går klassen: ");
            int numberOfStudents = int.Parse(Console.ReadLine());

            List<Student> klass = new List<Student>();

            // En forloop som går genom alla elever och frågar dig frågor om dem.
            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.WriteLine($"Information om elev NR. {i + 1}:");
                Console.Write("Namn: ");
                string name = Console.ReadLine();
                Console.Write("Program (Teknik, ES eller IT): ");
                string program = Console.ReadLine();
                Console.Write("Hur duktig är eleven? (0-100): ");
                int skill = int.Parse(Console.ReadLine());
                switch (program)
                {
                    case "Teknik":
                        if (name != null && skill >= 0 && skill <= 100) {
                            klass.Add(new TeStudent(name, program, skill));   
                        } else {
                            Console.Clear();
                            Console.WriteLine("Fel inmatning!");
                            i--;
                        }
                        break;
                    case "ES":
                        if (name != null && skill >= 0 && skill <= 100) {
                            klass.Add(new EsStudent(name, program, skill));   
                        } else {
                            Console.Clear();
                            Console.WriteLine("Fel inmatning!");
                            i--;
                        }
                        break;
                    case "IT":
                        if (name != null && skill >= 0 && skill <= 100) {
                            klass.Add(new ItStudent(name, program, skill));   
                        } else {
                            Console.Clear();
                            Console.WriteLine("Fel inmatning!");
                            i--;
                        }
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Fel inmatning av program!");
                        i--;
                        break;
                }
            }

            // En foreach loop som går genom alla elever i klassen och skriver ut deras namn samt betyg.
            foreach (var Student in klass)
            {
                Console.WriteLine($"\nNamn: {Student.Name}");
                if (Student.GetDescription() == "Teknik") {
                    var student = Student as TeStudent;
                    if (student != null) {
                        Console.WriteLine($"Teknikbetyg: {student.GetCodeGrade()}"); 
                        Console.WriteLine($"Photobetyg: {student.GetPhotoGrade()}"); 
                        Console.WriteLine($"Nätvärksbetyg: {student.GetNetworkGrade()}"); 
                    }
                } else if (Student.GetDescription() == "ES") {
                    var student = Student as EsStudent;
                    if (student != null) {
                        Console.WriteLine($"Teknikbetyg: {student.GetCodeGrade()}"); 
                        Console.WriteLine($"Photobetyg: {student.GetPhotoGrade()}"); 
                        Console.WriteLine($"Nätvärksbetyg: {student.GetNetworkGrade()}"); 
                    }
                } else if (Student.GetDescription() == "IT") {
                    var student = Student as ItStudent;
                    if (student != null) {
                        Console.WriteLine($"Teknikbetyg: {student.GetCodeGrade()}"); 
                        Console.WriteLine($"Photobetyg: {student.GetPhotoGrade()}"); 
                        Console.WriteLine($"Nätvärksbetyg: {student.GetNetworkGrade()}"); 
                    }
                }
            }
        }
    }
}

/// <summary>
/// Bas klassen "Student" vilket innehåller namn och description för varje elev.
/// </summary>
class Student 
{
    public string Name { get; set;}
    public string Description { get; set;}

    public Student(string name, string description) {
        Name = name;
        Description = description;
    }

    public string GetDescription() {
        return Description;
    }

    public char GetGrade(int skill) 
    {
        switch (skill)
        {
            case > 90:
                return 'A';
            case > 70: 
                return 'C';
            case > 50: 
                return 'E';
            default:
                return 'F';
        }
    }
}
/// <summary>
/// Subclass till basklassen student villket genererar duktighets graden för en elev i varje ämne.
/// </summary>
class TeStudent : Student 
{
    public int CodeSkill { get; set; }
    public int PhotoSkill { get; set; }
    public int NetworkSkill { get; set; }
    public TeStudent(string name, string description, int skill) : base(name, description) {
        CodeSkill = skill;

        Random generator = new Random();
        PhotoSkill = generator.Next(30, 71);
        NetworkSkill = generator.Next(71, 101);
    }
    public char GetCodeGrade() {
        return GetGrade(CodeSkill);
    }

    public char GetPhotoGrade() {
        return GetGrade(PhotoSkill);
    }

    public char GetNetworkGrade() {
        return GetGrade(NetworkSkill);
    }
}
/// <summary>
/// Subclass till basklassen student villket genererar duktighets graden för en elev i varje ämne.
/// </summary>
class EsStudent : Student 
{
    public int CodeSkill { get; set; }
    public int PhotoSkill { get; set; }
    public int NetworkSkill { get; set; }
    public EsStudent(string name, string description, int skill) : base(name, description) {
        PhotoSkill = skill;

        Random generator = new Random();
        CodeSkill = generator.Next(40, 81);
        NetworkSkill = generator.Next(1, 101);
    }

    public char GetCodeGrade() {
        return GetGrade(CodeSkill);
    }

    public char GetPhotoGrade() {
        return GetGrade(PhotoSkill);
    }

    public char GetNetworkGrade() {
        return GetGrade(NetworkSkill);
    }
}
/// <summary>
/// Subclass till basklassen student villket genererar duktighets graden för en elev i varje ämne.
/// </summary>
class ItStudent : Student 
{
    public int CodeSkill { get; set; }
    public int PhotoSkill { get; set; }
    public int NetworkSkill { get; set; }
    public ItStudent(string name, string description, int skill) : base(name, description) {
        NetworkSkill = skill;
        Random generator = new Random();
        CodeSkill = generator.Next(70, 101);
        PhotoSkill = generator.Next(40, 81);
    }

    public char GetCodeGrade() {
        return GetGrade(CodeSkill);
    }

    public char GetPhotoGrade() {
        return GetGrade(PhotoSkill);
    }

    public char GetNetworkGrade() {
        return GetGrade(NetworkSkill);
    }
}