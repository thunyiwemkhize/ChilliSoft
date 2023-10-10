using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Test
{
    public class UserBuilder
    {
        private readonly User _user;

        public UserBuilder()
        {
            _user = new User();
        }

        public UserBuilder withName(string userName)
        {
            _user.Name = "Test";
            return this;
        }

        public UserBuilder withEmail(string email)
        {
            _user.Email = email;
            return this;
        }

        public UserBuilder withSurname(string surname)
        {
            _user.Surname = surname;
            return this;
        }

        public User Build()
        {
            return _user;
        }
    }
}
