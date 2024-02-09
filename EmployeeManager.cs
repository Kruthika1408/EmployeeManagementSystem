using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeeMgm
{
    class EmployeeManager
    {
        private static string filePath = @"D:\Employeefile.txt";
        private List<Employee> employees;

        public EmployeeManager()
        {
            employees = new List<Employee>();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            int id = int.Parse(parts[0]);
                            string name = parts[1];
                            string department = parts[2];
                            employees.Add(new Employee(id, name, department));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading employees: {ex.Message}");
            }
        }

        private void SaveEmployees()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var employee in employees)
                    {
                        writer.WriteLine($"{employee.Id},{employee.Name},{employee.Department}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving employees: {ex.Message}");
            }
        }

        public void AddEmployee()
        {
            Console.WriteLine("Enter employee details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Department: ");
            string department = Console.ReadLine();

            employees.Add(new Employee(id, name, department));
            SaveEmployees();

            Console.WriteLine("Employee added successfully.");
        }

        public void ViewEmployees()
        {
            Console.WriteLine("Employee Details:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Department: {employee.Department}");
            }
        }

        public void UpdateEmployee()
        {
            Console.Write("Enter the ID of the employee you want to update: ");
            int id = int.Parse(Console.ReadLine());

            Employee employeeToUpdate = employees.Find(e => e.Id == id);
            if (employeeToUpdate != null)
            {
                Console.Write("Enter new name: ");
                employeeToUpdate.Name = Console.ReadLine();
                Console.Write("Enter new department: ");
                employeeToUpdate.Department = Console.ReadLine();
                SaveEmployees();
                Console.WriteLine("Employee details updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public void DeleteEmployee()
        {
            Console.Write("Enter the ID of the employee you want to delete: ");
            int id = int.Parse(Console.ReadLine());

            Employee employeeToDelete = employees.Find(e => e.Id == id);
            if (employeeToDelete != null)
            {
                employees.Remove(employeeToDelete);
                SaveEmployees();
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }
}
