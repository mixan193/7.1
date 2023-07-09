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
            int id;
            DateTime dateTime;
            string fullName;
            int height;
            DateTime dateOfBirth;
            string placeOfBirth;
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
                        repository.AddEmployeeToDB();
                        break;
                    case '2':
                        Console.CursorLeft = 0;
                        Console.WriteLine("Введите ID");
                        try
                        {
                            if (repository.DeleteEmployeeFromDB(int.Parse(Console.ReadLine())))
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
                            Employee employee;
                            if ((employee = repository.GetEmployeeById(int.Parse(Console.ReadLine()))) != null)
                            {
                                Console.WriteLine(employee.EmployeeToString());
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
                        foreach (Employee employee in repository.GetAllEmployees())
                        {
                            Console.WriteLine(employee.EmployeeToString());
                        }
                        break;
                    default:
                        continue;
                }
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
            }
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
