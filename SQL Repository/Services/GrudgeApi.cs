using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;


        public GrudgeApi(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ActionResult<Grudge>> GetGrudgeByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<Grudge>().FindByIdAsync(id);
        }

        public async Task<List<Grudge>> GetGrudgesAsync()
        {
            return await _unitOfWork.GetRepository<Grudge>().All().ToListAsync();
        }

        public async Task PutGrudgeAsync(Grudge grudge)
        {
            var getRepository = _unitOfWork.GetRepository<Grudge>();
            var entity = _mapper.Map<Grudge>(grudge);
            getRepository.Update(entity);
            await _unitOfWork.CommitAsync();

        }

        public async Task PostGrudgeAsync(Grudge grudge)
        {
            var getRepository = _unitOfWork.GetRepository<Grudge>();
            var entity = _mapper.Map<Grudge>(grudge);
            getRepository.Add(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteGrudgeAsync(int Id)
        {
            _unitOfWork.GetRepository<Grudge>().Remove(Id);
            await _unitOfWork.CommitAsync();
        }
    }
}
