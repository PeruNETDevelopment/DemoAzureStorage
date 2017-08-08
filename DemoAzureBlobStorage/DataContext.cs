using System.Data.Entity;

namespace DemoAzureBlobStorage
{
    public class DataContext : DbContext
    {
        public DataContext() : 
            base("name=Conexion")
        {
        }

        public DbSet<DataBlob> DataBlobs { get; set; }

    }
}