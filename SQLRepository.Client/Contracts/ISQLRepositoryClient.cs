using System;
using System.Collections.Generic;
using System.Text;

namespace SQLRepository.Client.Contracts
{
    public interface ISQLRepositoryClient
    {
        IGrudgeApi Grudges { get; }
    }
}
