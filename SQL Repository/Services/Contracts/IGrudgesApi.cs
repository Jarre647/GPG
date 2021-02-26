using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQLRepository.Client.Models;

namespace SQL_Repository.Services.Contracts
{
    public interface IGrudgesApi
    {
        Task<List<GrudgeModel>> GetGrudgesAsync();

        Task<ActionResult<GrudgeModel>> GetGrudgeByIdAsync(int id);

        Task PutGrudgeAsync(GrudgeModel grudge);

        Task PostGrudgeAsync(GrudgeModel grudge);

        Task DeleteGrudgeAsync(int id);
    }
}
