using System;
using System.Collections.Generic;
using System.Text;

namespace DbContextPagination.Contracts
{
    public interface IProvider<IInput, IOutput>
    {
        IOutput Get(IInput input);
    }
}
