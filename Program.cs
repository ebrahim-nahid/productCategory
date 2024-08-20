namespace productCategory
{
    public class Program
    {
        static void Main(string[] args)
        {

            using (DatabaseHelper dbHelper = new DatabaseHelper())
            {
                Product product = new Product(dbHelper);
                //Console.WriteLine("Enter the product name and description");
                //product.Name = Console.ReadLine();
                //product.Description = Console.ReadLine();
                //product.CreateProduct(product);
               // product.GetProduct(product);
                product.UpdateProduct(product);
                product.Name = "Test";
                product.Description = "Test";

            }
            //using (DatabaseHelper databaseHelper = new DatabaseHelper())
            //{
            //    Category category = new Category(databaseHelper);

            //    //Product product1 = new Product{ Id=1, Name="Laptop", Description="This is laptop", CategoryId=1};

            //    category.Name = "Books";
            //    category.Description = "This is books";

            //    category.CreateCategory(category);
            //}
                
            //product.CreateProduct(product1, category, connectionString);
            
            //Product product2 = new Product { Id = 1, Name = "mobile", Description = "This is mobile" };
            
            //product.GetProduct(category);

        }
    }
}
