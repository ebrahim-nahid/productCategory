using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace productCategory;

public sealed class Category 
{
    private readonly DatabaseHelper _dbHelper;
    //private SqlConnection _connection;
    //public Category(string connectionString)
    //{
    //    _connection = new SqlConnection(connectionString);
    //    _connection.Open();
    //}
    public Category(DatabaseHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
   //private List<Category> _categories = new List<Category>();
    public void CreateCategory(Category category)
    {
        try
        {
            if (_dbHelper.Connection.State == ConnectionState.Open)
            {
                Console.WriteLine("The connection is open.");
                string query = "INSERT INTO Categories (Name, Description) VALUES (@Name, @Description)";
                using (SqlCommand command = new SqlCommand(query, _dbHelper.Connection))
                {
                    command.Parameters.AddWithValue("@Name", category.Name);
                    command.Parameters.AddWithValue("@Description", category.Description);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        Console.WriteLine("Category inserted successfully");
                    }
                    else
                    {
                        Console.WriteLine("Category inserted Failed");
                    }
                }
            }
            else
            {
                Console.WriteLine("The connection is not open.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
       
        //_categories.Add(category);
    }
    //public string GetCategoryName(int categoryId)
    //{
    //   //var category = _categories.Where(c => c.Id == categoryId).Select(x => x.Name).SingleOrDefault(); //_categories[categoryId].Name; 
    //   // return category;
    //}
    //public List<Category> GetCategory()
    //{
    //    //return _categories;
    //}
}
