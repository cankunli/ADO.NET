using ADO.NET.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Data.Repo
{
    public class TownsRepo : IRepo<Towns>
    {
        public int Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from Town where id =@id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.Connection = sqlConnection;
            int r = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return r;
        }

        public IEnumerable<Towns> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select Id,DName,CountryId from Town";

            cmd.Connection = sqlConnection;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Towns> collection = new List<Towns>();
            while (reader.Read())
            {
                Towns d = new Towns();
                d.Id = Convert.ToInt32(reader["Id"]);
                d.Name = Convert.ToString(reader["Name"]);
                d.CountryId = Convert.ToInt32(reader["CountryId"]);
                collection.Add(d);
            }

            sqlConnection.Close();
            return collection;
        }

        public Towns GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Towns obj)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert into Town values (@Name)";
            cmd.Parameters.AddWithValue("@Name", obj.Name);

            cmd.Connection = sqlConnection;
            int r = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return r;
        }

        public int Update(Towns obj)
        {
            SqlConnection sqlConnection = new SqlConnection(DbHelper.GetConnectionString());
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update Town set Name =@Name, CountryId=@CountryId where id=@id";
            cmd.Parameters.AddWithValue("@dname", obj.Name);
            cmd.Parameters.AddWithValue("@loc", obj.Name);
            cmd.Parameters.AddWithValue("@id", obj.CountryId);

            cmd.Connection = sqlConnection;
            int r = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return r;
        }
    }
}
