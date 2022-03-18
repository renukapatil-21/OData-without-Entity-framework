using System.Data;
using System.Data.SqlClient;

namespace ODataWithoutEF.Models
{
    public class ContextDb
    {  
        string conn = "Data Source=(localdb)\\mssqllocaldb; Database=ODataStudent;Trusted_Connection=True;MultipleActiveResultSets=True";
        public List<Student> GetStudent()
        {
            List<Student> list = new List<Student>();
            string query = "Select * from Students";
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(new Student { Id=Convert.ToInt32(dr[0]), FirstName= Convert.ToString(dr[1]), LastName = Convert.ToString(dr[2]) });
                    }
                }
            }
            return list;
        }

        public bool Add(Student obj)
        {
            string query = "insert into Students values('" + obj.FirstName + "','" + obj.LastName + "')";
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool Edit(int id, Student obj)
        {
            string query = "update Students set FirstName= '" + obj.FirstName + "', LastName='" + obj.LastName + "' where Id='" + id + "' ";
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool DeleteStudent(int id)
        {
            string query = "delete Students where Id='" + id + "'";
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                }
            }
        }
    }
}
