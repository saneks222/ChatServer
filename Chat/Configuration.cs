namespace ChatServer
{
    public class Configuration
    {
        public static IConfiguration Config {get; private set;}

        public Configuration(IConfiguration configuration) 
        {
            Config = configuration;
        }
    }
}
