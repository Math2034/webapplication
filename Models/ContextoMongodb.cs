using MongoDB.Driver;

namespace WebApplication2.Models
{
    public class ContextoMongodb
    {
        public static string? ConnectionString { get; set; }

        public static string? Database { get; set; }

        public static bool IsSSL { get; set; }
        private IMongoDatabase _database { get; }

        public ContextoMongodb()
        {
            try
            {
                MongoClientSettings setting = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));

                if(IsSSL)
                {
                    setting.SslSettings = new SslSettings
                    {
                        EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                    };
                }
                var mongoCliente = new MongoClient(setting);
                _database = mongoCliente.GetDatabase(Database);
            }
            catch (Exception)
            {

                throw new Exception("Não deu pra conectar :(");
            }
        }

        public IMongoCollection<Usuario> Usuario
        {
            get
            {
                return _database.GetCollection<Usuario>("Usuario");
            }
        }

    }
}
