using CalcDB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDB.Repositories
{
    public class OperResultRepository: IRepository
    {
        // todo - вынести в настройки
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitHub\Calculator\Calculator\Calculator\CalcDB\AppData\CalcDB.mdf;Integrated Security=True";

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IList<OperationResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<OperationResult> GetByOperation(long Id)
        {
            throw new NotImplementedException();
        }

        public void Save(OperationResult result)
        {
            string queryString =
                "INSERT INTO [dbo].[OperationResult] " +
                "(OperationId, [Args], [Result], [Error], [ExecutionTime], [CreationDate]) " +
                $"VALUES({result.OperationId}, N'{result.Args}', {result.Result?.ToString(CultureInfo.InvariantCulture)}, N'{result.Error}', {result.ExecutionTime}, GETDATE()); ";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                var count = command.ExecuteNonQuery();
            }
        }
    }
}
