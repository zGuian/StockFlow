using System.Data.Common;
using System.Net.NetworkInformation;

namespace FlowStockManager.Domain.Entities
{
    public sealed class User : EntityBase
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string UserKey { get; private set; }
        public int Age { get; private set; }

        public static class Factories
        {
            public static User Create(string firstName, string lastName, string email, string password, string userKey, int age)
            {
                return new User(GenerateId(), firstName, lastName, email, password, userKey, age);
            }
        }

        private User(string id, string firstName, string lastName, string email, string password, string userKey, int age) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserKey = userKey;
            Age = age;
        }
    }
}
