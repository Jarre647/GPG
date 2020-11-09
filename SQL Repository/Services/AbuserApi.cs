using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQL_Repository.Data;
using SQL_Repository.Models;
using SQL_Repository.Services.Contracts;

namespace SQL_Repository.Services
{
    public class AbuserApi : IAbusersApi
    {
        private readonly SQL_RepositoryContext _context;

        public AbuserApi(SQL_RepositoryContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Abuser>>> GetAbuser()
        {
            return await _context.Abuser.ToListAsync();
        }

    }
}
