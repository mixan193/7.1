using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1
{
    struct Worker
    {
        public int id;
        private DateTime dateTime;
        private string fullName;
        private int age;
        private int height;
        private DateTime dateOfBirth;
        private string placeOfBirth;
        public Worker(int id, string fullName, int height, DateTime dateOfBirth, string placeOfBirth)
        {
            this.id = id;
            this.dateTime = DateTime.Now;
            this.fullName = fullName;
            age = (dateTime - dateOfBirth).Days / 365;
            this.height = height;
            this.dateOfBirth = dateOfBirth;
            this.placeOfBirth = placeOfBirth;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public string WorkerToString()
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
