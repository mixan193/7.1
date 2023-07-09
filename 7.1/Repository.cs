using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1
{
    internal class Repository
    {
        private string pathToDBFile;
        public int EmployeesCount
        {
            get
            {
                return GetLastID();
            }
        }
        public Repository(string pathToDBFile)
        {
            this.pathToDBFile = pathToDBFile;
            if (!File.Exists(pathToDBFile))
            {
                FileStream fs = new FileStream(pathToDBFile, FileMode.Create);
                fs.Close();
            }
        }

        public int AddEmployeeToDB()
        {
            int id = GetLastID() + 1;
            DateTime dateTime = DateTime.Now;
            Console.WriteLine("Введите ФИО ");
            string fullName = Program.EnterString();
            Console.WriteLine("Введите рост ");
            int height = Program.EnterInt();
            Console.WriteLine("Введите дату рождения ");
            DateTime dateOfBirth = Program.EnterDate();
            Console.WriteLine("Введите место рождения ");
            string placeOfBirth = Program.EnterString();
            Employee employee = new Employee(id, dateTime, fullName, height, dateOfBirth, placeOfBirth);
            AddEmployeeToDB(employee.EmployeeToString());
            return id;
        }

        public bool AddEmployeeToDB(string employer)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(pathToDBFile, true);
                streamWriter.WriteLine(employer);
                streamWriter.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDBFile(string pathToDBFile)
        {
            if (File.Exists(pathToDBFile))
            {
                try
                {
                    File.Delete(pathToDBFile);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;

        }

        public Employee GetEmployeeById(int id)
        {
            foreach(Employee employee in GetAllEmployees())
            {
                if(employee.Id == id)
                {
                    return employee;
                }
            }
            return null;
        }
        private int GetLastID()
        {
            return File.ReadLines(pathToDBFile).Count();
        }

        public bool DeleteEmployeeFromDB(int id)
        {
            bool result = false;
            List<Employee> employees = GetAllEmployees().ToList();
            DeleteDBFile(pathToDBFile);
            foreach (Employee employee in employees)
            {
                if(employee.Id == id)
                {
                    employees.Remove(employee);
                    result = true;
                    break;
                }
            }
            for(int i = 0; i < employees.Count; i++)
            {
                employees[i].Id = i + 1;
            }
            foreach (Employee employee in employees)
            {
                AddEmployeeToDB(employee.EmployeeToString());
            }
            if (!File.Exists(pathToDBFile))
            {
                FileStream fs = new FileStream(pathToDBFile, FileMode.Create);
                fs.Close();
            }

            return result;
        }

        public Employee[] GetAllEmployees()
        {
            StreamReader streamReader = new StreamReader(pathToDBFile);
            string[] employeesInString = new string[GetLastID()];
            Employee[] employees = new Employee[GetLastID()];
            int id;
            DateTime dateTime;
            string fullName;
            int height;
            DateTime dateOfBirth;
            string placeOfBirth;
            string[] temp;
            for(int i = 0; i < employeesInString.Length; i++)
            {
                employeesInString[i] = streamReader.ReadLine();
                temp = employeesInString[i].Split('#');
                id = int.Parse(temp[0]);
                dateTime = DateTime.Parse(temp[1]);
                fullName = temp[2];
                height = int.Parse(temp[4]);
                dateOfBirth = DateTime.Parse(temp[5]);
                placeOfBirth = temp[6];
                employees[i] = new Employee(id, dateTime, fullName, height, dateOfBirth, placeOfBirth);
            }
            streamReader.Close();
            return employees;
        }
    }
}
