using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQL_Repository.Models;

namespace SQL_Repository.Services.Contracts
{
    public interface IGrudgesApi
    {
        Task<List<Grudge>> GetGrudgesAsync();

        Task<ActionResult<Grudge>> GetGrudgeByIdAsync(int id);

        Task PutGrudgeAsync(Grudge grudge);

        Task PostGrudgeAsync(Grudge grudge);

        Task DeleteGrudgeAsync(int Id);
    }
}
