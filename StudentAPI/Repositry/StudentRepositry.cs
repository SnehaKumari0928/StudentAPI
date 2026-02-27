
using StudentAPI.Models;
using MySql.Data.MySqlClient;
using StudentAPI.Data;
using StudentAPI.Models;

namespace StudentAPI.Repositry
{
    public class StudentRepositry : IStudentRepositry
    {

        MySqlConnection conn;
        public StudentRepositry()
        {
            conn = new MySqlConnection(DbConnection.ConnectionString);
        }
        public List<StudentModel> GetAll()
        {
            
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
           
            string query = "SELECT * FROM student";
            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            List<StudentModel> students = new List<StudentModel>();

            while (reader.Read())
            {
                students.Add(new StudentModel
                {
                    id = (int)reader["id"],
                    name = (string)reader["name"],
                    age = (int)reader["age"]
                });
            }
            conn.Close();
            return students;
        }
        public StudentModel GetById(int id)
        {

            StudentModel student = null;
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
           
            string query = "SELECT * FROM student WHERE id = @id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                student = new StudentModel
                {
                    id = (int)reader["id"],
                    name = (string)reader["name"],
                    age = (int)reader["age"]

                };
            }
            conn.Close();
            return student;
           


        }
        public void Create(StudentModel student)
        {

            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            string query = "INSERT INTO student(name,age) VALUES(@name,@age)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", student.name);
            cmd.Parameters.AddWithValue("@age", student.age);
            int newId = Convert.ToInt32(cmd.ExecuteNonQuery());
            conn.Close();



        }
        public void Update(StudentModel student,int id)
        {

            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            string query = "UPDATE student SET name = @name,age = @age WHERE id=@id ";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", student.name);
            cmd.Parameters.AddWithValue("@age", student.age);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Delete(int id)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            string query = "DELETE FROM student WHERE id=@id ";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
