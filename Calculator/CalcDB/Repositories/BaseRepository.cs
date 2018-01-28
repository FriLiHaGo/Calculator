using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcDB.Models;
using System.Data.SqlClient;
using System.Globalization;

namespace CalcDB.Repositories
{
    /// <summary>
    /// Сущность, хранится в БВ
    /// </summary>
    public interface IEntity
    {
        long Id { get; set; }

        string TableName { get; }
    }

    public class BaseRepository<T> : IRepository<T> where T : IEntity
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitHub\Calculator\Calculator\Calculator\CalcDB\AppData\CalcDB.mdf;Integrated Security=True";

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public T Get(long id)
        {
            var all = GetAll();
            return all.FirstOrDefault(it => it.Id == id);
        }

        public IList<T> GetAll()
        {
            var result = new List<T>();
            /*
            var columnStr = string.Join("], [", typeof(T).GetColumns());

            var queryString = $"SELECT [Id, {columnStr}] FROM {entity.TableName} ";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var or = new OperationResult()
                        {
                            Id = (long)reader[0],
                            OperationId = (long)reader[1],
                            Args = reader[2] as string,
                            Result = reader[3] as double?,
                            ExecutionTime = (long)reader[4],
                            CreationDate = (DateTime)reader[5],
                            Error = reader[6] as string
                        };
                        result.Add(or);
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            */
            return result;
        }
        
        public void Save(T entity)
        {
            var queryString = "";

            if (entity.Id > 0)
            {
                queryString =
                $"UPDATE {entity.TableName} SET {entity.GetSerialData()} WHERE Id = { entity.Id }";
            }
            else
            {
                var columnStr = string.Join("], [", entity.GetColumns());

                queryString =
                $"INSERT INTO {entity.TableName} ([{columnStr}]) VALUES({entity.GetSerialData()})";
            }

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
