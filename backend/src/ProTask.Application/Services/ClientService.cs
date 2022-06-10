using AutoMapper;
using ProTask.Application.DTOs;
using ProTask.Application.Interfaces;
using ProTask.Application.Services.Base;
using ProTask.Domain.Interfaces;
using ProTask.Domain.Models;

namespace ProTask.Application.Services
{
    public class ClientService : Service<ClientDTO, NewClientDTO, Client, int>, IClientService
    {
        public ClientService(IMapper mapper, IClientRepository repository) : base(mapper, repository)
        {
        }

        public async Task<ClientDTO?> Update(ClientDTO modelDTO)
        {            
            if(modelDTO != null)
            {
                var client = await _repository.GetAsync(modelDTO.Id);
                if(client != null)
                {
                    client.Update(modelDTO.Name ?? string.Empty, modelDTO.Situation);
                    return _mapper.Map<ClientDTO>(await _repository.UpdateAsync(client));
                }
            }
            return null;
        }
    }
}