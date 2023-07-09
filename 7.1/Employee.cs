using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1
{
    internal class Employee
    {
        private int id;
        public int Id 
        {
            get
            { 
                return id;
            }
            set
            {
                id = value;
            }
        }
        private DateTime dateTime = DateTime.Now;
        private string fullName;
        private int age;
        private int height;
        private DateTime dateOfBirth;
        private string placeOfBirth;
        public Employee(int id, DateTime dateTime, string fullName, int height, DateTime dateOfBirth, string placeOfBirth)
        {
            this.id = id;
            this.dateTime = dateTime;
            this.fullName = fullName;
            age = (dateTime - dateOfBirth).Days / 365;
            this.height = height;
            this.dateOfBirth = dateOfBirth;
            this.placeOfBirth = placeOfBirth;
        }

        public string EmployeeToString()
        {
            string result = string.Empty;
            result += id.ToString() + "#";
            result += dateTime.ToString() + "#";
            result += fullName.ToString() + "#";
            result += age.ToString() + "#";
            result += height.ToString() + "#";
            result += dateOfBirth.Date.ToString() + "#";
            result += placeOfBirth.ToString();
            return result;
        }
    }
}
