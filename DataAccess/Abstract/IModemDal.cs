using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IModemDal: IEntityRepository<Modem>
    {
        public List<ModemWithCompleteInfoDto> GetAllWithCompleteInfo();

        public ModemWithCompleteInfoDto GetAllWithCompleteInfoById(Guid id);
    }
}
