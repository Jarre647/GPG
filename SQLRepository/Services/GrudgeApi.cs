using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLRepository.Repositories;
using SQLRepository.Services.Contracts;
using SQLRepository.Client.Models;

namespace SQLRepository.Services
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

        public async Task<ActionResult<GrudgeModel>> GetGrudgeByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<GrudgeModel>().FindByIdAsync(id);
        }

        public async Task<List<GrudgeModel>> GetGrudgesAsync()
        {
            return await _unitOfWork.GetRepository<GrudgeModel>().All().ToListAsync();
        }

        public async Task PutGrudgeAsync(GrudgeModel grudge)
        {
            var getRepository = _unitOfWork.GetRepository<GrudgeModel>();
            var entity = _mapper.Map<GrudgeModel>(grudge);
            getRepository.Update(entity);
            await _unitOfWork.CommitAsync();

        }

        public async Task PostGrudgeAsync(GrudgeModel grudge)
        {
            var getRepository = _unitOfWork.GetRepository<GrudgeModel>();
            grudge.Date = DateTime.Now;
            var entity = _mapper.Map<GrudgeModel>(grudge);
            getRepository.Add(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteGrudgeAsync(int Id)
        {
            _unitOfWork.GetRepository<GrudgeModel>().Remove(Id);
            await _unitOfWork.CommitAsync();
        }
    }
}
