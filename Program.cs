using System;
using System.Reflection.PortableExecutable;

namespace Battlefield_NTI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TeStudent teStudent = new TeStudent("Marrio", 100);
            Console.WriteLine($"Namn: {teStudent.Name}, Coding Grade: {teStudent.GetCodeGrade()}");

            EsStudent esStudent = new EsStudent("Bob the builder", 80);
            Console.WriteLine($"Namn: {esStudent.Name}, Photo Grade: {esStudent.GetPhotoGrade()}");

            ItStudent itStudent = new ItStudent("Andrei", 85);
            Console.WriteLine($"Namn: {itStudent.Name}, Network Grade: {itStudent.GetNetworkGrade()}");
        }
    }
}

class Student 
{
    public string Name { get; set;}

    public Student(string name) {
        Name = name;
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

class TeStudent : Student 
{
    public int CodeSkill { get; set; }
    public TeStudent(string name, int skill) : base(name) {
        CodeSkill = skill;
    }

    public char GetCodeGrade() {
        return GetGrade(CodeSkill);
    }
}

class EsStudent : Student 
{
    public int PhotoSkill { get; set; }
    public EsStudent(string name, int skill) : base(name) {
        PhotoSkill = skill;
    }

    public char GetPhotoGrade() {
        return GetGrade(PhotoSkill);
    }
}

class ItStudent : Student 
{
    public int NetworkSkill { get; set; }
    public ItStudent(string name, int skill) : base(name) {
        NetworkSkill = skill;
    }

    public char GetNetworkGrade() {
        return GetGrade(NetworkSkill);
    }
}