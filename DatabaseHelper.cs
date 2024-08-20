using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productCategory;

public class DatabaseHelper : IDisposable
{
    private readonly SqlConnection _connection;
    private string connectionString =
                         "Data Source=Ebrahim_Dex;Initial Catalog=ProCat;"
                         + "Integrated Security=true";
    public DatabaseHelper()
    {
        _connection = new SqlConnection(connectionString);
        _connection.Open();
    }
    public SqlConnection Connection
    {
        get { return _connection; }
    }
    public void Dispose()
    {
        if (_connection != null && _connection.State == ConnectionState.Open)
        {
            _connection.Close();
        }
    }
}
