using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLRepository.Client.Models;

namespace WebReact.Services.Contracts
{
    public interface IGrudgeService
    {
        Task<List<GrudgeModel>> GetAbuserAsync();
    }
}
