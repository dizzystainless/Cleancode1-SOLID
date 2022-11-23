namespace Shared
{
    public class Customer
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string Password { get; set; }
        
        public Customer(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}