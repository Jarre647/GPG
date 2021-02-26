
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLRepository.Client.Contracts;
using SQLRepository.Client.Models;
using WebReact.Services.Contracts;

namespace WebReact.Services
{
    public class GrudgeService : IGrudgeService
    {
        private readonly IGrudgeApi _grudgeApi;

        public GrudgeService(IGrudgeApi grudgeApi)
        {
            _grudgeApi = grudgeApi;
        }

        public async Task<List<GrudgeModel>> GetAbuserAsync()
        {
            var response = await _grudgeApi.GetAbuserAsync();

            return (List<GrudgeModel>) response;
        }
    }
}
