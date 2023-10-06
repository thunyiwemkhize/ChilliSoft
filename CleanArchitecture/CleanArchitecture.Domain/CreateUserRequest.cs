using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain
{
    public class CreateUserRequest
    {
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public CreateUserRequest()
        {
            Name = string.Empty;
            Surname = string.Empty;
            EmailAddress = string.Empty;
        }
    }
}
