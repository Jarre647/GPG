using System;
using System.Collections.Generic;
using System.Text;
using SQLRepository.Client.Contracts;

namespace SQLRepository.Client
{
    public class SQLRepositoryClient : ISQLRepositoryClient
    {
        public IGrudgeApi Grudges { get; }

        public SQLRepositoryClient(IGrudgeApi grudges)
        {
            Grudges = grudges;
        }
    }
}
