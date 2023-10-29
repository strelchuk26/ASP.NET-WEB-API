using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAdvertsService
    {
        List<AdvertDto> Get();
        AdvertDto? Get(int id);
        void Create(CreateAdvertModel product);
        void Edit(EditAdvertModel product);
        void Delete(int id);
    }
}
