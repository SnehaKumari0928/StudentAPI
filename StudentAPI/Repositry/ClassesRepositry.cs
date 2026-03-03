using MySql.Data.MySqlClient;
using StudentAPI.Models;
using StudentAPI.Repositry;
using StudentAPI.Data;

namespace StudentAPI.Repositry
{
    public class ClassesRepositry: IClassesRepositry
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
                    classname = (string)reader["classname"],
                    section = (string)reader["section"]
                });
            }

            conn.Close();

            return classes;


        }

        public ClassesModel GetById(string classname)
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            ClassesModel classes = null;

            string query = "SELECT * FROM classes WHERE classname = @classname";

            using var cmd = new MySqlCommand(query,conn);

            cmd.Parameters.AddWithValue("@classname", classname);


            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                classes = new ClassesModel
                {
                    classname = (string)reader["classname"],
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

            string query = "INSERT INTO classes(classname,section) VALUES (@classname,@section)";

            using var cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@classname", classes.classname);
            cmd.Parameters.AddWithValue("@section",classes.section);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Update(string classname,ClassesModel classes)
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string query = "UPDATE classes SET section=@section WHERE classname = @classname";
            using var cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@classname",classname);
            cmd.Parameters.AddWithValue("@section", classes.section);

            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void Delete(string classname)
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();
            string query = "DELETE FROM classes WHERE  classname= @classname";
            using var cmd = new MySqlCommand(query,conn);

            cmd.Parameters.AddWithValue("@classname", classname);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}
