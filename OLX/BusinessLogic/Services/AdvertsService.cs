using AutoMapper;
using BusinessLogic.Dtos;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Exceptions;
using BusinessLogic.ApiModels;
using DataAccess.Data.Entities;

namespace BusinessLogic.Services
{
    public class AdvertsService : IAdvertsService
    {
        private readonly OLXDbContext ctx;
        private readonly IMapper mapper;

        public AdvertsService(OLXDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public void Create(CreateAdvertModel product)
        {
            ctx.Adverts.Add(mapper.Map<Advert>(product));
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = ctx.Adverts.Find(id);

            if (item == null) throw new HttpException("Advert with Id not found!", HttpStatusCode.NotFound);

            ctx.Adverts.Remove(item);
            ctx.SaveChanges();
        }

        public void Edit(EditAdvertModel product)
        {
            ctx.Adverts.Update(mapper.Map<Advert>(product));
            ctx.SaveChanges();
        }

        public List<AdvertDto> Get()
        {
            var items = ctx.Adverts.Include(x => x.Category).ToList();

            if (items == null) throw new HttpException("Adverts with Id not found!", HttpStatusCode.NotFound);

            return mapper.Map<List<AdvertDto>>(items);
        }

        public AdvertDto? Get(int id)
        {
            var item = ctx.Adverts.Find(id);

            if (item == null) throw new HttpException("Adverts with Id not found!", HttpStatusCode.NotFound);

            return mapper.Map<AdvertDto>(item);
        }
    }
}
