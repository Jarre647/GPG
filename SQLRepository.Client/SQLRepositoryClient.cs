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
