using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productCategory
{
    public sealed class Product
    {
        private readonly DatabaseHelper _dbHelperPro;
        public Product(DatabaseHelper dbHelperPro)
        {
            _dbHelperPro =dbHelperPro;
        }
        public int Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
       // public Category Category { get; set; }
      //  public int CategoryId { get; init; }
      //this is product list
        private List<ProductDto> _products = new List<ProductDto>();

       internal void CreateProduct(Product product)
       {
            try
            {
                if (_dbHelperPro.Connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("The connection is open.");
                    string query = "INSERT INTO Products (Name, Description) VALUES (@Name, @Description)";
                    using (SqlCommand command = new SqlCommand(query, _dbHelperPro.Connection))
                    {
                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@Description", product.Description);
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            Console.WriteLine("Products inserted successfully");
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
            //     _products.Add(product);
            //     int id = product.Id;
            //     Console.Write("Enter the Product Name");
            //     string name = Console.ReadLine();
            //     Console.Write("Enter the Product Description");
            //     string? description = Console.ReadLine();
            //     foreach (var item in category.GetCategory())
            //     {
            //         Console.WriteLine("Category Id: " + item.Id + "Name :" + item.Name);
            //     }
            //     Console.Write("Enter the Category Id");
            //     int categoryId =   Convert.ToInt32(Console.ReadLine());
            //     Product product1 = new Product { Id=id++, Name = name, Description = description, CategoryId = categoryId};
            //     _products.Add(product1);
            //}
            //public void GetProduct(Category category)
            //{
            //     Console.WriteLine("Product List...................");
            //     foreach (var product in _products)
            //     {
            //         Console.WriteLine($"Id:{ product.Id}");
            //         Console.WriteLine(product.Name);
            //         Console.WriteLine(product.Description);
            //         Console.WriteLine(category.GetCategoryName(product.CategoryId));
            //     }
            }
             public void UpdateProduct(Product product)
             {
           // using (SqlConnection connection = new SqlConnection(_dbHelperPro.Connection);
            
                _dbHelperPro.Connection.Open();
                string query = "UPDATE Products SET Name = @Name, Description = @Description WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, _dbHelperPro.Connection))
                {
                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@Name",product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description);

                    command.ExecuteNonQuery();
                }
            
             }
             


                    // var productToUpdate = GetProductId(product.Id);
                    // if (productToUpdate != null)
                    //{
                    // productToUpdate.Name = product.Name;
                    // productToUpdate.Description = product.Description;
                    // }
          

        public void GetProduct(Product product)
        {
            // Define connection string (replace placeholders with actual values)
           // string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";

            // Define the SELECT command
            string selectQuery = "SELECT * FROM Products";

            // Create a connection and command object
           // using (SqlConnection connection = new SqlConnection(_dbHelperPro.connectionString))
            using (SqlCommand command = new SqlCommand(selectQuery, _dbHelperPro.Connection))
            {
                try
                {
                    // Open the connection
                    if (_dbHelperPro.Connection.State == ConnectionState.Open)
                    {
                        // connection.Open();

                        // Execute the command and retrieve a data reader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Read and process the data
                            while (reader.Read())
                            {
                                _products.Add(new ProductDto //data transfer object
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Description = reader.GetString(2)
                                }); 
                            }
                        }
                        foreach (var item in _products)
                        {
                            Console.WriteLine($"Id: {item.Id} Name: {item.Name}, Description : {item.Description}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The connection is not open.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }

        //public void DeleteProduct(int productId)
        //{
        //    var productToUpdate = GetProductId(productId);
        //    if (productToUpdate != null) 
        //    { 
        //        _products.Remove(productToUpdate);
        //    }
        //}
    
}
