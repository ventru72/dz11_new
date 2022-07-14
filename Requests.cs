using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace dz11
{
    public class Requests: Columns
    {
        public string Insert_Department()
        {
            return $"INSERT INTO department (department_id, department_parent_id ) VALUES ({Depatment_id}, {Depatment_parent_id})";
        }
        public string Insert_workers()
        {
            return $@"INSERT INTO workers  (f_name, last_name, salary_id, department_id) VALUES ({First_Name}, {Last_Name}, {Salary_id}, {Depatment_id} )";
        }
        public string Delete_workers()
        {
            return $"DELETE FROM workers WHERE workers_id = {Console.ReadLine()})";
        }
        //public string insert_workers = $"INSERT INTO workers (department_id ) VALUES ({Console.ReadLine()}, {Console.ReadLine()})";
        //public string insert_department = $"INSERT INTO department (department_id, depatment_parent_id ) VALUES ({Console.ReadLine()}, {Console.ReadLine()})";
        //public string insert_workers = "INSERT INTO department (department_id ) VALUES (26, 0)";

    }
    class Sql_Command : Requests
    {

        public void Connected(string str)
        {

            string connString = "Host=localhost;Username=postgres;Password=VeNtRu72;Database=workers";
            NpgsqlConnection con = new NpgsqlConnection(connString);
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(str, con);
            cmd.ExecuteNonQuery();
            if (str.GetType() == new Select_All().GetType())
            {
                List<Department> list = new List<Department>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        //Console.WriteLine("{0} {1} ", reader.GetInt32(0), reader.GetInt32(1));
                        Department department = new Department();
                        department.Depatment_id = reader.GetInt32(0);
                        department.Depatment_parent_id = reader.GetInt32(1);
                        list.Add(department);
                    }
                }
                foreach (Department item in list)
                {
                    item.Print();
                }
                Console.ReadKey();
            }

            con.Close();
        }
    }
}
