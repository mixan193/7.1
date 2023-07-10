using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");
            Repository repository = new Repository("DB.txt");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Для добавления нового сотрудника нажмите 1\r\n" +
                    "Для удаления сотрудника нажмите 2\r\n" +
                    "Для вывода информации о сотруднике по ID нажмите 3\r\n" +
                    "Для вывода списка всех сотрудников нажмите 4\r\n");
                switch(Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.CursorLeft = 0;
                        repository.AddWorkerToDB();
                        break;
                    case '2':
                        Console.CursorLeft = 0;
                        Console.WriteLine("Введите ID");
                        try
                        {
                            if (repository.DeleteWorkerFromDB(int.Parse(Console.ReadLine())))
                            {
                                Console.WriteLine("Пользователь удалён");
                            }
                            else
                            {
                                Console.WriteLine("Пользователь не найден");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка ввода");
                        }
                        break;
                    case '3':
                        Console.CursorLeft = 0;
                        Console.WriteLine("Введите ID");
                        try
                        {
                            Worker? worker;
                            if ((worker = repository.GetWorkerById(int.Parse(Console.ReadLine()))) != null)
                            {
                                PrintWorker(worker);
                            }
                            else
                            {
                                Console.WriteLine("Пользователь не найден");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка ввода");
                        }
                        break;
                    case '4':
                        Console.CursorLeft = 0;
                        foreach (Worker worker in repository.GetAllWorkers())
                        {
                            PrintWorker(worker);
                        }
                        break;
                    default:
                        continue;
                }
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
            }
        }
        public static void PrintWorker(Worker? worker)
        {
            string[] temp = worker?.WorkerToString().Split('#');
            Console.WriteLine("ID: {0} Дата регистрации: {1} ФИО: {2} Возраст: {3} Рост: {4} Дата рождения: {5} Город:{6}",
                temp[0],
                temp[1],
                temp[2],
                temp[3],
                temp[4],
                temp[5],
                temp[6]);
        }
        public static string EnterString()
        {
            string result;
            while ((result = Console.ReadLine()) == string.Empty)
            {
                Console.WriteLine("Вы ничего не ввели");
            }
            return result;
        }

        public static int EnterInt()
        {
            int result = 0;
            while (result < 1)
            {
                try
                {
                    result = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число");
                }
            }
            return result;
        }

        public static DateTime EnterDate()
        {
            DateTime result = new DateTime();
            string dateOfBirdthInString;
            bool isAccepted = false;
            while (!isAccepted)
            {
                try
                {
                    dateOfBirdthInString = Console.ReadLine();
                    string[] strings = dateOfBirdthInString.Split('.');
                    result = new DateTime(int.Parse(strings[2]), int.Parse(strings[1]), int.Parse(strings[0]));
                    isAccepted = true;
                }
                catch
                {
                    Console.WriteLine("Введите дату в формате день.месяц.год");
                }
            }
            return result;
        }

    }

}
