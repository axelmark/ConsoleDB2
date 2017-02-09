using System;

namespace ConsoleDB2
{
    static class Program
    {
        static void Main()
        {
            SqLQueries sqLQueries = new SqLQueries();
            string str = null;

            Console.WriteLine("Welcome!");
            while (str != "")
            {
                String _name = null, _age = null, _gen = null, _id = null;
                str = Console.ReadLine();

                switch (str)
                {
                    case "select":
                        sqLQueries.SelectFromTable();
                        break;

                    case "insert":
                        FillInTheRequiredFieldsInsert(_name, _age, _gen);
                        sqLQueries.InsertIntoTable(_name, Convert.ToInt32(_age), _gen);
                        break;

                    case "update":
                        FillInTheRequiredFieldsUpdate(_name, _id);
                        sqLQueries.UpdateTable(_name, Convert.ToInt32(_id));
                        break;

                    case "delete":
                        FillInTheRequiredFieldsDelete(_id);
                        sqLQueries.DeleteFromTable(Convert.ToInt32(_id));
                        break;

                    default:
                        Console.WriteLine("Команда не найдена!");
                        break;
                }
            }
        }

        private static void FillInTheRequiredFieldsInsert(String _name, String _age, String _gen)
        {
            Console.Write("Введите имя: ");
            _name = Console.ReadLine();
            Console.Write("Введите возраст:  ");
            _age = Console.ReadLine();
            Console.Write("Введите пол муж/жен: ");
            _gen = Console.ReadLine();
        }

        private static void FillInTheRequiredFieldsUpdate(String _name, String _id)
        {
            Console.Write("Введите номер строки в которой, желаете изменить имя: ");
            _id = Console.ReadLine();
            Console.Write("Введите новое имя: ");
            _name = Console.ReadLine();
        }

        private static void FillInTheRequiredFieldsDelete(String _id)
        {
            Console.Write("Введите номер строки для удаления: ");
            _id = Console.ReadLine();
        }
    }
}