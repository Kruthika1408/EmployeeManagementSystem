using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgm
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeManager employeeManager = new EmployeeManager();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Employee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employees");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        employeeManager.AddEmployee();
                        break;
                    case "2":
                        employeeManager.ViewEmployees();
                        break;
                    case "3":
                        employeeManager.UpdateEmployee();
                        break;
                    case "4":
                        employeeManager.DeleteEmployee();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
    

