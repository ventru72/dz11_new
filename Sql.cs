using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace dz11
{
    interface INpgsql
    {
        void Connected(IRequest request); 

    }
    interface IRequest
    {
        string Request();
    }
    public class Select_All : Columns, IRequest
    {
        public string Request()
        {
            string request = $"SELECT (workers_id, first_name, last_name, department_id, department_parent_id, salary, type_worker)" +
                $" FROM workers " +
                $"LEFT JOIN department ON workers.department_id = department.department_id " +
                $"LEFT JOIN salary ON workers.salary_id = salary.salary_id";
            return request;
        }
    }
    public class Search : Columns, IRequest
    {
        public string Request()
        {
            string request = $"SELECT ( department_id ) FROM department" +
                $"WHERE department_id = {Depatment_id}";
            return request;
        }
    }
    public class Delete : IRequest
    {

        public string Request()
        {
            string request = $"DELETE FROM workers WHERE worker_id = {Console.ReadLine()} ";
            return request;
        }
    }
    public class Insert : IRequest
    {
        public string Request()
        {

            string request = "INSERT INTO department (department_id, department_parent_id) " +
                "VALUES (@dep_id, @dep_parent_id);" +
                 
                "INSERT INTO workers (first_name, last_name, department_id, salary_id )" +
                "VALUES (@f_name, @l_name, @dep_id, @sal_id);";
            return request;
            
        }
    }

    internal class Sql : INpgsql
    {
        public void Connected(IRequest request)
        {
            
            string connString = "Host=localhost;Username=postgres;Password=VeNtRu72;Database=workers";
            NpgsqlConnection con = new NpgsqlConnection(connString);
            con.Open();
            Worker worker = new Worker();
            worker.Initialization();
            NpgsqlCommand cmd = new NpgsqlCommand(request.Request(), con);
            NpgsqlParameter Sparam = new NpgsqlParameter("@f_name", worker.First_Name);
            
            cmd.Parameters.Add(Sparam);
            Sparam = new NpgsqlParameter("@l_name", worker.Last_Name);
            cmd.Parameters.Add(Sparam);
            Sparam = new NpgsqlParameter("@dep_id", worker.Depatment_id);
            cmd.Parameters.Add(Sparam);
            Sparam = new NpgsqlParameter("@dep_parent_id", worker.Depatment_parent_id);
            cmd.Parameters.Add(Sparam);
            Sparam = new NpgsqlParameter("@sal_id", worker.Salary_id);
            cmd.Parameters.Add(Sparam);
            //Sparam = new NpgsqlParameter("@t_worker", worker.Type_Worker);
            //cmd.Parameters.Add(Sparam);
            cmd.ExecuteNonQuery();
            if (request.GetType() == new Select_All().GetType())
            {
                List<Worker> list = new List<Worker>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        //Console.WriteLine("{0} {1} ", reader.GetInt32(0), reader.GetInt32(1));
                       
                        worker.Worker_id = reader.GetInt32(0);
                        worker.First_Name = reader.GetString(1);
                        worker.Last_Name = reader.GetString(2);
                        worker.Depatment_id = reader.GetInt32(3);
                        worker.Depatment_parent_id = reader.GetInt32(4);
                        worker.Salary = reader.GetInt32(4);
                        worker.Type_Worker = reader.GetString(5);
                        list.Add(worker);
                    }
                }
                foreach (Worker item in list)
                {
                    item.Print();
                }
                Console.ReadKey();
            }
            else if (request.GetType() == new Search().GetType())
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {  
                       if( worker.Depatment_id == reader.GetInt32(0))
                        {

                        } 
                            
                    }
                }
            }

            con.Close();
        }

        //public void Connected(IRequest request)
        //{   string str = string.Empty;

        //    string connString = "Host=localhost;Username=postgres;Password=VeNtRu72;Database=workers";
        //    NpgsqlConnection nc = new NpgsqlConnection(connString);

        //    nc.Open();
        //    NpgsqlCommand npgc = new NpgsqlCommand(request.Request(), nc);

        //    //npgc.ExecuteNonQuery();
        //    if (request.GetType() == new Select_All().GetType())
        //    {
        //        List<Department> list = new List<Department>();
        //    using(var reader = npgc.ExecuteReader())
        //        {
        //            while(reader.Read())
        //            {
        //                //Console.WriteLine("{0} {1} ", reader.GetInt32(0), reader.GetInt32(1));
        //                Department department = new Department();
        //                department.Depatment_id= reader.GetInt32(0);
        //                department.Depatment_parent_id = reader.GetInt32(1);
        //                list.Add(department);
        //            }
        //        }
        //     foreach(Department item in list)
        //        {
        //            item.Print();
        //        }
        //        Console.ReadKey();
        //    }
        //    nc.Close();
        //}
    }
}
