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
        public bool IsActive { get; private set; }

        private User(string id, string firstName, string lastName, string email, string password, string userKey, int age) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserKey = userKey;
            Age = age;
        }

        private User(string id, string firstName, string lastName, string email, string password) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserKey = "NOT USER KEY";
            Age = 0;
        }

        public static class Factories
        {
            public static User Create(string firstName, string lastName, string email, string password, string userKey, int age)
            {
                return new User(GenerateId(), firstName, lastName, email, password, userKey, age);
            }

            public static User Create(string firstName, string lastName, string email, string password)
            {
                return new User(GenerateId(), firstName, lastName, email, password);
            }
        }

        public User DisableUser()
        {
            IsActive = false;
            return this;
        }
    }
}
