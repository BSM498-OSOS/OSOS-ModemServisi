using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfModemDal : EfEntityRepositoryBase<Modem, ModemDbContext>, IModemDal
    {
        public List<ModemWithCompleteInfoDto> GetAllWithCompleteInfo()
        {
            using (var context = new ModemDbContext())
            {
                var result = (from m in context.Modems
                              join model in context.Models
                                 on m.ModelId equals model.Id
                             join b in context.Brands
                                 on model.BrandId equals b.Id
                              select new ModemWithCompleteInfoDto
                              {
                                  Id=m.Id,
                                  ModelId=m.ModelId,
                                  ModelName=model.Name,
                                  BrandId=model.BrandId,
                                  BrandName=b.Name,
                                  SerialNo=m.SerialNo
                              }).ToList();
                return result;
            }
        }

        public ModemWithCompleteInfoDto GetAllWithCompleteInfoById(Guid id)
        {
            using (var context = new ModemDbContext())
            {
                var result = from m in context.Modems
                              join model in context.Models
                                 on m.ModelId equals model.Id
                              join b in context.Brands
                                 on model.BrandId equals b.Id
                              where m.Id == id
                              select new ModemWithCompleteInfoDto
                              {
                                  Id = m.Id,
                                  ModelId = m.ModelId,
                                  ModelName = model.Name,
                                  BrandId = model.BrandId,
                                  BrandName = b.Name,
                                  SerialNo = m.SerialNo
                              };
                return result.FirstOrDefault();
            }
        }
    }
}
