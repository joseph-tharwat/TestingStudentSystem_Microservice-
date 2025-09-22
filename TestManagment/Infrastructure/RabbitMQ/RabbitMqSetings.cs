namespace TestManagment.Infrastructure.RabbitMQ
{
    public class RabbitMqSetings
    {
        public string Uri {  get; set; }
        public string QueueName { get; set; }
        public string HeaderKey { get; set; }
        public string HeaderValueOne { get; set; }
        public string HeaderValueMany { get; set; }
        public string ExchangeName { get; set; }
    }
}
