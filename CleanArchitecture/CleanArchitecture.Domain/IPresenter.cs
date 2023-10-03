﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain
{
    public interface IPresenter
    {
        void Success(CreateUserResponse response);
        void Error(string error);
    }
}
