using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQL_Repository.Models;

namespace SQL_Repository.Services.Contracts
{
    public interface IAbusersApi
    {
        Task<ActionResult<IEnumerable<Abuser>>> GetAbuser();
    }
}
