using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain
{
    public interface ICreateUserUseCase
    {
        void Execute(CreateUserRequest request, IPresenter presenter);
    }
}
