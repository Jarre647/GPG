using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQL_Repository.Models;
using SQL_Repository.Repositories;
using SQL_Repository.Services.Contracts;

namespace SQL_Repository.Services
{
    public class GrudgeApi : IGrudgesApi
    {
        private readonly IUnitOfWork _unitOfWork;


        public GrudgeApi(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult<Grudge>> GetGrudgeById(int id)
        {
            return await _unitOfWork.GetRepository<Grudge>().FindByIdAsync(id);
        }

        public async Task<List<Grudge>> GetGrudges()
        {
            return await _unitOfWork.GetRepository<Grudge>().All().ToListAsync();
        }
    }
}
