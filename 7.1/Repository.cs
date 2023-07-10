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
        public int WorkersCount
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

        public int AddWorkerToDB()
        {
            int id = GetLastID() + 1;
            Console.WriteLine("Введите ФИО ");
            string fullName = Program.EnterString();
            Console.WriteLine("Введите рост ");
            int height = Program.EnterInt();
            Console.WriteLine("Введите дату рождения ");
            DateTime dateOfBirth = Program.EnterDate();
            Console.WriteLine("Введите место рождения ");
            string placeOfBirth = Program.EnterString();
            Worker worker = new Worker(id, fullName, height, dateOfBirth, placeOfBirth);
            AddWorkerToDB(worker.WorkerToString());
            return id;
        }

        public bool AddWorkerToDB(string worker)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(pathToDBFile, true);
                streamWriter.WriteLine(worker);
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

        public Worker? GetWorkerById(int id)
        {
            foreach(Worker worker in GetAllWorkers())
            {
                if(worker.id == id)
                {
                    return worker;
                }
            }
            return null;
        }
        private int GetLastID()
        {
            return File.ReadLines(pathToDBFile).Count();
        }

        public bool DeleteWorkerFromDB(int id)
        {
            bool result = false;
            List<Worker> workers = GetAllWorkers().ToList();
            DeleteDBFile(pathToDBFile);
            foreach (Worker worker in workers)
            {
                if(worker.id == id)
                {
                    workers.Remove(worker);
                    result = true;
                    break;
                }
            }
            for(int i = 0; i < workers.Count; i++)
            {
                workers[i].SetId(i + 1);
            }
            foreach (Worker worker in workers)
            {
                AddWorkerToDB(worker.WorkerToString());
            }
            if (!File.Exists(pathToDBFile))
            {
                FileStream fs = new FileStream(pathToDBFile, FileMode.Create);
                fs.Close();
            }

            return result;
        }

        public Worker[] GetAllWorkers()
        {
            StreamReader streamReader = new StreamReader(pathToDBFile);
            string[] workersInString = new string[GetLastID()];
            Worker[] workers = new Worker[GetLastID()];
            int id;
            DateTime dateTime;
            string fullName;
            int height;
            DateTime dateOfBirth;
            string placeOfBirth;
            string[] temp;
            for(int i = 0; i < workersInString.Length; i++)
            {
                workersInString[i] = streamReader.ReadLine();
                temp = workersInString[i].Split('#');
                id = int.Parse(temp[0]);
                dateTime = DateTime.Parse(temp[1]);
                fullName = temp[2];
                height = int.Parse(temp[4]);
                dateOfBirth = DateTime.Parse(temp[5]);
                placeOfBirth = temp[6];
                workers[i] = new Worker(id, fullName, height, dateOfBirth, placeOfBirth);
            }
            streamReader.Close();
            return workers;
        }
    }
}
