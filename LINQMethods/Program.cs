using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }
    public double Tuition { get; set; }
}

public class StudentClubs
{
    public int StudentID { get; set; }
    public string ClubName { get; set; }
}

public class StudentGPA
{
    public int StudentID { get; set; }
    public double GPA { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        IList<Student> studentList = new List<Student>()
        {
                new Student() { StudentID = 1, StudentName = "Frank Furter", Age = 55, Major="Hospitality", Tuition=3500.00} ,
                new Student() { StudentID = 1, StudentName = "Gina Host", Age = 21, Major="Hospitality", Tuition=4500.00 } ,
                new Student() { StudentID = 2, StudentName = "Cookie Crumb",  Age = 21, Major="CIT", Tuition=2500.00 } ,
                new Student() { StudentID = 3, StudentName = "Ima Script",  Age = 48, Major="CIT", Tuition=5500.00 } ,
                new Student() { StudentID = 3, StudentName = "Cora Coder",  Age = 35, Major="CIT", Tuition=1500.00 } ,
                new Student() { StudentID = 4, StudentName = "Ura Goodchild" , Age = 40, Major="Marketing", Tuition=500.00} ,
                new Student() { StudentID = 5, StudentName = "Take Mewith" , Age = 29, Major="Aerospace Engineering", Tuition=5500.00 }
        };

        IList<StudentGPA> studentGPAList = new List<StudentGPA>()
        {
                new StudentGPA() { StudentID = 1,  GPA=4.0} ,
                new StudentGPA() { StudentID = 2,  GPA=3.5} ,
                new StudentGPA() { StudentID = 3,  GPA=2.0 } ,
                new StudentGPA() { StudentID = 4,  GPA=1.5 } ,
                new StudentGPA() { StudentID = 5,  GPA=4.0 } ,
                new StudentGPA() { StudentID = 6,  GPA=2.5} ,
                new StudentGPA() { StudentID = 7,  GPA=1.0 }
        };

        IList<StudentClubs> studentClubList = new List<StudentClubs>()
        {
            new StudentClubs() {StudentID=1, ClubName="Photography" },
            new StudentClubs() {StudentID=1, ClubName="Game" },
            new StudentClubs() {StudentID=2, ClubName="Game" },
            new StudentClubs() {StudentID=5, ClubName="Photography" },
            new StudentClubs() {StudentID=6, ClubName="Game" },
            new StudentClubs() {StudentID=7, ClubName="Photography" },
            new StudentClubs() {StudentID=3, ClubName="PTK" },
        };

        // f) Join the student list and student GPA list on student ID and display the student's name, major and gpa
        var studentsWithGPA = studentList.Join(studentGPAList, student => student.StudentID, gpa => gpa.StudentID, (student, gpa) => new { Name = student.StudentName, Major = student.Major, GPA = gpa.GPA });

        foreach (var student in studentsWithGPA)
        {
            Console.WriteLine($"Name: {student.Name}, Major: {student.Major}, GPA: {student.GPA}");
        }

        // g) Join the student list and student club list. Display the names of only those students who are in the Game club.
        var studentsInGameClub = studentList.Join(studentClubList, student => student.StudentID, club => club.StudentID, (student, club) => new { Name = student.StudentName, Club = club.ClubName }).Where(s => s.Club == "Game");

        Console.WriteLine("Students in the Game club:");
        foreach (var student in studentsInGameClub)
        {
            Console.WriteLine(student.Name);
        }
    }
}
