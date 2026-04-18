using Autopark.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public static class Database
    {
        private static string ConnectionString = "Server=localhost;Port=3306;Database=autopark;Uid=root;Pwd=2113;";

        // Авторизация
        public static User GetUser(string login, string password)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    "SELECT id, login, password, full_name, role FROM users WHERE login=@l AND password=@p",
                    conn);
                cmd.Parameters.AddWithValue("@l", login);
                cmd.Parameters.AddWithValue("@p", password);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            id = reader.GetInt32("id"),
                            login = reader.GetString("login"),
                            password = reader.GetString("password"),
                            full_name = reader.GetString("full_name"),
                            role = reader.GetString("role")
                        };
                    }
                }
            }
            return null;
        }

        // Получить все автомобили
        public static List<Car> GetCars()
        {
            var list = new List<Car>();
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT id, brand, model, year, license_plate, mileage FROM cars", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Car
                        {
                            id = reader.GetInt32("id"),
                            brand = reader.GetString("brand"),
                            model = reader.GetString("model"),
                            year = reader.GetInt32("year"),
                            license_plate = reader.GetString("license_plate"),
                            mileage = reader.GetInt32("mileage")
                        });
                    }
                }
            }
            return list;
        }

        // Создать заявку на ТО
        public static void CreateMaintenanceRequest(int carId, string description)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    "INSERT INTO maintenance_requests (car_id, description) VALUES (@cid, @desc)",
                    conn);
                cmd.Parameters.AddWithValue("@cid", carId);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.ExecuteNonQuery();
            }
        }
    }
}