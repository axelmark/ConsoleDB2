using System;
using System.Data.SqlClient;

namespace ConsoleDB2
{
    class SqLQueries
    {
        private static readonly string ConString =
            "Data Source=APPLE;Initial Catalog=Basic;Integrated Security=True; Pooling=true";

        private void TransmissionOfCommandToDataBase(string requestsString)
        {
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                try
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    SqlCommand command = new SqlCommand(requestsString, connection) {Transaction = transaction};
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        transaction.Commit();
                        ShowMessageInfo("выполнено успешно");
                    }
                    else
                    {
                        transaction.Rollback();
                        ShowMessageInfo("ошибка при выполнении");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            SelectFromTable();
        }

        public void SelectFromTable()
        {
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM [new_table]";
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine($"{dr[0]} {dr[1]} {dr[2]}");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void InsertIntoTable(string name, int age, string gen)
        {
            TransmissionOfCommandToDataBase("INSERT INTO [new_table] ([name], [age], [gen]) VALUES ('" + name + "','" +
                                            age + "','" + gen + "')");
        }

        public void UpdateTable(string name, int id)
        {
            TransmissionOfCommandToDataBase("UPDATE [new_table] SET [name] = '" + name + "' WHERE [id]='" + id + "'");
        }

        public void DeleteFromTable(int id)
        {
            TransmissionOfCommandToDataBase("DELETE FROM [new_table] WHERE [id] = '" + id + "'");
        }

        private void ShowMessageInfo(string message)
        {
            Console.WriteLine(message);
        }
    }
}