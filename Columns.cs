using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz11
{
    public class Columns
    {
        public int Worker_id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Type_Worker { get; set; }
        public int Salary_id { get; set; }
        public int Salary { get; set; }
        public int Depatment_id { get; set; }
        public int Depatment_parent_id { get; set; }
        public Columns() { }
        public void Initialization()
        {
           
            Console.WriteLine("Введите имя: ");
            First_Name = Console.ReadLine();

            Console.WriteLine("Введите фамилию: ");
            Last_Name = Console.ReadLine();

            Console.WriteLine("Введите тип работника: \n1 - стажер\n2 - рабочий\n3 - менеджер\n4 - заместитель директора\n5 - директор ");
            Salary_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите номер отдела:");
            Depatment_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите номер родительского отдела:");
            Depatment_parent_id = Convert.ToInt32(Console.ReadLine());
            
        }
    }
    class Department: Columns
    {
         
        public Department() { }
        public Department(int Depatment_id, int Depatment_parent_id)
        {
            this.Depatment_id = Depatment_id;
            this.Depatment_parent_id = Depatment_parent_id;
        }
        public void Print()
        {
            Console.WriteLine($"Depatment_id {Depatment_id} Depatment_parent_id {Depatment_parent_id}");
        }
    }
    class Worker : Columns
    {
        public Worker() { }
        public Worker(int Worker_id,string First_Name, string Last_Name,  int Depatment_id, int Depatment_parent_id, string Type_Worker, int Salary)
        {
            this.Worker_id = Worker_id;
            this.First_Name = First_Name;
            this.Last_Name = Last_Name;
            this.Depatment_id = Depatment_id;
            this.Depatment_parent_id= Depatment_parent_id;
            this.Type_Worker = Type_Worker;
            this.Salary = Salary;
        } 
        public Worker(string First_Name, string Last_Name, int Salary_id, int Depatment_id, int Depatment_parent_id)
        {
            this.First_Name = First_Name;
            this.Last_Name = Last_Name;
            this.Salary_id = Salary_id;
            this.Depatment_id = Depatment_id;
            this.Depatment_parent_id = Depatment_parent_id;
        }
        public void Print()
        {

            Console.WriteLine($"Worker_id   First_Name   Last_Name    Depatment_id " +
                $"   Depatment_parent_id    Salary     Type_Worker");

            Console.WriteLine($"{Worker_id,5} {First_Name,15} {Last_Name,15} " +
                $"{Depatment_id,15} {Depatment_parent_id,15} {Salary,15} {Type_Worker,15}");
        }

    }
}
