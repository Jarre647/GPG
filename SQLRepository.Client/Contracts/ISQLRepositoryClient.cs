namespace SQLRepository.Client.Contracts
{
    public interface ISQLRepositoryClient
    {
        IGrudgeApi Grudges { get; }
    }
}
