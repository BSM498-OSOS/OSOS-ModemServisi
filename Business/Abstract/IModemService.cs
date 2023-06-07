using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IModemService
    {
        IResult Add(Modem modem);
        IResult Delete(Modem modem);
        IResult Update(Modem modem);
        IDataResult<Modem> GetById(Guid modemId);
        IDataResult<List<Modem>> GetAll();

        IDataResult<ModemWithCompleteInfoDto> GetWithCompleteInfoById(Guid modemId);
        IDataResult<List<ModemWithCompleteInfoDto>> GetAllWithCompleteInfo();
    }
}
