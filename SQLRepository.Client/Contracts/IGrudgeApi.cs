using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using SQLRepository.Client.Models;

namespace SQLRepository.Client.Contracts
{
    public interface IGrudgeApi
    {
        [Get("/grudges")]
        Task<IReadOnlyList<GrudgeModel>> GetAbuserAsync();
    }
}
