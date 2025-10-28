using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using Org.BouncyCastle.Crypto;
using System.Text;

class Program
{
    static void Main()
    {
        //string connectionString = "Server=comet-direct.usbx.me;Port=17815;Database=schooldb;User=yh_marcus;Password=YpL2Un%95vXn;";
        string file = "C:\\PROGRAMS\\SUVNET25\\dapper-databas-lektion\\pass.txt";
        string password = "";

        try
        {
            using StreamReader sr = new(file);
            string text = sr.ReadToEnd();
            password = text;
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }



        string connectionString = $"Server=comet-direct.usbx.me;Port=17815;Database=kalle_schooldb;User=kalle;Password={password};";
        using (IDbConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            //connection.Execute("INSERT INTO Teacher (Name), (Email) VALUES ('Örjan Lax'), ('realörjanlax@lax.se')");


            IEnumerable<Teacher> teachers = connection.Query<Teacher>("SELECT Name, Email FROM Teacher");

            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Teacher: [Name: {teacher.Name}, Email: {teacher.Email}]");
            }
            
        };
    }
}

class Teacher
{ 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    // Constructor
    public Teacher() {}
}