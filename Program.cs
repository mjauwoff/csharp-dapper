using System.Data;
using MySql.Data.MySqlClient;
using Dapper;


class Program
{

    static void Main()
    {
        string connectionString = "Server=comet-direct.usbx.me;port=17815;Database=kalle_schooldb;User=kalle;Password=apa123;";
        using IDbConnection db = new MySqlConnection(connectionString);

        Console.WriteLine("Connection initialized successfully!"); 

        var students = db.Query<Student>("SELECT * FROM Student").ToList();
        var courses = db.Query<Course>("SELECT * FROM Course").ToList();
        var enrollments = db.Query<Enrollment>("SELECT * FROM Enrollment").ToList();
        var teachers = db.Query<Teacher>("SELECT t. Id, t.Name, t.Email FROM Teacher t").ToList();

        foreach (var student in students)
        {
            Console.WriteLine($"{student.Id}: {student.Name} - {student.Email} | {student.DateOfBirth}");
        }


        foreach (var enrollment in enrollments)
        {
            Console.WriteLine($"ID: {enrollment.Id}, StudentID: {enrollment.StudentId}, CourseID: {enrollment.CourseId}, EnrollmentDate: {enrollment.EnrollmentDate}, Grade: {enrollment.Grade}");
        }
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string DateOfBirth { get; set; }
}

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public string EnrollmentDate { get; set; }
    public int Grade { get; set; }
}

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Credits { get; set; }
    public int TeacherId { get; set; }
}

