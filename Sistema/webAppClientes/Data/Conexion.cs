using System.Data.SqlClient;

namespace webAppClientes.Data
{
    public class Conexion
    {
        private string _cadenaSQL = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _cadenaSQL = builder.GetSection("ConnectionStrings:cadenaSQL").Value;
        }

        public string getCadenaSQL() { return _cadenaSQL; }
    }
}
