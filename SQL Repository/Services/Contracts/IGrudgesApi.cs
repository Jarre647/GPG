using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQL_Repository.Models;

namespace SQL_Repository.Services.Contracts
{
    public interface IGrudgesApi
    {
        Task<List<Grudge>> GetGrudges();

        Task<ActionResult<Grudge>> GetGrudgeById(int id);
    }
}
