using MySql.Data.MySqlClient;
using StudentAPI.Models;
using StudentAPI.Repositry;
using StudentAPI.Data;

namespace StudentAPI.Repositry
{
    public class ClassesRepositry: IClasses
    {
        MySqlConnection conn;
        public ClassesRepositry()
        {
            conn = new MySqlConnection(DbConnection.ConnectionString);
            
        }

        public List<ClassesModel> GetAllClasses()
        {

            List<ClassesModel> classes = new List<ClassesModel>();

            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string query = "SELECT * FROM classes";

            using var cmd = new MySqlCommand(query, conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                classes.Add(new ClassesModel{
                    classname = (string)reader["classname "],
                    section = (string)reader["section"]
                });
            }

            conn.Close();

            return classes;


        }

        public ClassesModel GetById(int id)
        {



        }
        public void Create(ClassesModel class)
        {

         }

        public void Update(int id)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
