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
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            ClassesModel classes = null;

            string query = "SELECT * FROM classes WHERE id = @id";

            using var cmd = new MySqlCommand(query,conn);

            cmd.Parameters.AddWithValue("@id", id);


            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                classes = new ClassesModel
                {
                    classname = (string)reader["id"],
                    section = (string)reader["section"]

                };
            }
            conn.Close();
            return classes;

        }


        public void Create(ClassesModel classes)
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string query = "INSERT INTO classes(classname,section) VALUES(@classname,@section)";

            using var cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@classname", classes.classname);
            cmd.Parameters.AddWithValue("@section",classes.section);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Update(int id)
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string query = "UPDATE classes SET classaname = @classname,section=@section WHERE id = @id";
            using var cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@classname", classname);

        }

        public void Delete(int id)
        {

        }
    }
}
