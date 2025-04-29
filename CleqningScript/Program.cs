using CleaningScript;
using CleaningScript.Models;
using CleqningScript;
using Microsoft.Data.SqlClient;

class Program
{
    private static ApplicationContext _db = new ApplicationContext();
    private static EntityFiles EntityFiles = new EntityFiles();
    private static EducationProgramOrders EducationProgramOrders = new EducationProgramOrders();
    private static RequestsToEnterTheOrganizations RequestsToEnterTheOrganizations = new RequestsToEnterTheOrganizations();

    static void Main()
    {
        //EntityFiles.GetAllEntityFiles();
        //EntityFiles.GetOrphaned();

       //EducationProgramOrders.GetAll();
        //EducationProgramOrders.GetAllWithOrg();
        //EducationProgramOrders.GetOrphaned();

        RequestsToEnterTheOrganizations.GetAllWithOrgName();
        RequestsToEnterTheOrganizations.GetOrphaned();
        _db.Dispose(); 
    }

    static void GetOrphanEntityFiles()
    {
        using var connection = new SqlConnection(GetSqlConnectionString());

        string query2 = @"SELECT ef.Id, ef.Name, ef.EntityType, ef.EntityId
    FROM EntityFiles ef
    LEFT JOIN Modules m 
    ON ef.EntityType = 'Module' 
    AND CAST(m.Id AS uniqueidentifier) = ef.EntityId
    LEFT JOIN EducationLessons l 
    ON ef.EntityType = 'Lesson' 
    AND CAST(l.Id AS uniqueidentifier) = ef.EntityId
    WHERE ef.EntityType IN ('Module', 'Lesson')
    AND (
    (ef.EntityType = 'Module' AND m.Id IS NULL)
    OR (ef.EntityType = 'Lesson' AND l.Id IS NULL)
    )
    ";


        SqlCommand command = new(query2, connection);

        connection.Open();

        using SqlDataReader reader = command.ExecuteReader();

        for (int i = 0; i < reader.FieldCount; i++)
        {
            Console.Write($"{reader.GetName(i),-25}");
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 23 * reader.FieldCount));

        Console.ForegroundColor = ConsoleColor.Green;

        // Данные
        int rowNumber = 1;
        while (reader.Read())
        {
            Console.Write($"{rowNumber++,-5}");
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"{reader[i],-23}");
            }
            Console.WriteLine();
        }

        Console.WriteLine(new string('-', 23 * reader.FieldCount));



        string GetSqlConnectionString()
        {
            var sqlConnectionSB = new SqlConnectionStringBuilder
            {
                DataSource = "SlanovaHP",
                InitialCatalog = "COPP",

                IntegratedSecurity = true,
                TrustServerCertificate = true
            };

            return sqlConnectionSB.ToString();
        }
    }
    
}