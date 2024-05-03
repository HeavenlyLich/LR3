using System;
using System.Data.Common;
using System.Text;
using Lab3;
using MySql.Data.MySqlClient;

namespace ConsoleApp46
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Getting Connection ...");
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");
                while (true)
                {
                    Console.WriteLine("Оберіть дію:");
                    Console.WriteLine("a) Подивитися список тварин");
                    Console.WriteLine("b) Подивитися список лікарів");
                    Console.WriteLine("c) Подивитися список хвороб");
                    Console.WriteLine("q) Закрити програму");

                    // Отримання вибору користувача
                    Console.Write("Введіть ваш вибір: ");
                    string choice = Console.ReadLine().ToLower();

                    // Виклик відповідної функції в залежності від вибору користувача
                    switch (choice)
                    {
                        case "a":
                            Animals(conn);
                            break;
                        case "b":
                            Doctors(conn);
                            break;
                        case "c":
                            Disease(conn);
                            break;
                        case "q":
                            // Закриття програми
                            Console.WriteLine("Допобачення!");
                            conn.Close();
                            return;
                        default:
                            Console.WriteLine("Неправильний вибір. Будь ласка, введіть 'a', 'b', 'c' або 'q'.");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            Console.Read();

        }

        private static void Animals(MySqlConnection conn)
        {
            string animal_id, owner_lastname, animal_type, animal_breed, animal_nickname, animal_age, animal_sex;
            string sql = "Select * from animals";

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        animal_id = reader["animal_id"].ToString();
                        owner_lastname = reader["owner_lastname"].ToString();
                        animal_type = reader["animal_type"].ToString();
                        animal_breed = reader["animal_breed"].ToString();
                        animal_nickname = reader["animal_nickname"].ToString();
                        animal_age = reader["animal_age"].ToString();
                        animal_sex = reader["animal_sex"].ToString();
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("Айді: " + animal_id + "\nФамілія власника: " + owner_lastname + 
                            "\nВид: " + animal_type + "\nПорода: " + animal_breed + 
                            "\nПрізвисько тварини: " + animal_nickname + "\nВік тварини: " + animal_age +
                            "\nПол тварини: " + animal_sex);
                        Console.WriteLine("-------------------------------------------------");

                    }
                }
            }
        }

        private static void Doctors(MySqlConnection conn)
        {
            string doctors_id, doctors_lastname, doctors_firstname, doctors_categoty, doctors_gender, doctors_home_phone;
            string sql = "Select * from doctors";

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        doctors_id = reader["doctors_id"].ToString();
                        doctors_lastname = reader["doctors_lastname"].ToString();
                        doctors_firstname = reader["doctors_firstname"].ToString();
                        doctors_categoty = reader["doctors_categoty"].ToString();
                        doctors_gender = reader["doctors_gender"].ToString();
                        doctors_home_phone = reader["doctors_home_phone"].ToString();
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("Айді: " + doctors_id + "\nФамілія: " + doctors_lastname +
                            "\nІм'я: " + doctors_firstname + "\nКатегорія: " + doctors_categoty +
                            "\nПол: " + doctors_gender + "\nДомашній телефон: " + doctors_home_phone);
                        Console.WriteLine("-------------------------------------------------");

                    }
                }
            }
        }

        private static void Disease(MySqlConnection conn)
        {
            string disease_id, disease_name, disease_degree_of_severity, disease_cost_of_treatment;
            string sql = "Select * from disease";

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        disease_id = reader["disease_id"].ToString();
                        disease_name = reader["disease_name"].ToString();
                        disease_degree_of_severity = reader["disease_degree_of_severity"].ToString();
                        disease_cost_of_treatment = reader["disease_cost_of_treatment"].ToString();
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("Айді: " + disease_id + "\nНазва хвороби: " + disease_name +
                            "\nІм'я: " + disease_degree_of_severity + "\nІм'я: " + disease_cost_of_treatment);
                        Console.WriteLine("-------------------------------------------------");

                    }
                }
            }
        }
    }
}

