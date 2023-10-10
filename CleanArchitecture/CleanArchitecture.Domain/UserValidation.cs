using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain
{
    public interface IUserValidation
    {
        void ValidateUser(User user);
    }
    public class UserValidation: IUserValidation
    {
        public void ValidateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Surname) || string.IsNullOrEmpty(user.Email))
            {
                throw new ArgumentNullException();
            }

            if (!user.Email.Contains('@') || !user.Email.Contains('.'))
            {
                throw new ArgumentNullException("Invalid email address");
            }
        }
    }
}
