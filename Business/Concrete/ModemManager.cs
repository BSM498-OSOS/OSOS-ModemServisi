using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ModemManager : IModemService
    {
        private readonly IModemDal _modemDal;

        public ModemManager(IModemDal modemDal)
        {
            _modemDal = modemDal;
        }

        public IResult Add(Modem modem)
        {
            _modemDal.Add(modem);
            return new SuccessResult();
        }

        public IResult Delete(Modem modem)
        {
            _modemDal.Delete(modem);
            return new SuccessResult(); 
        }

        public IDataResult<List<Modem>> GetAll()
        {
            var result = _modemDal.GetAll();
            if(result!=null)
                return new SuccessDataResult<List<Modem>>(result);
            return new ErrorDataResult<List<Modem>>();
        }

        public IDataResult<List<ModemWithCompleteInfoDto>> GetAllWithCompleteInfo()
        {
            var result = _modemDal.GetAllWithCompleteInfo();
            if (result != null)
                return new SuccessDataResult<List<ModemWithCompleteInfoDto>>(result);
            return new ErrorDataResult<List<ModemWithCompleteInfoDto>>();
        }

        public IDataResult<Modem> GetById(Guid modemId)
        {
            var result=_modemDal.Get(m => m.Id == modemId);
            if(result!=null)
                return new SuccessDataResult<Modem>(result);
            return new ErrorDataResult<Modem>();
        }

        public IDataResult<ModemWithCompleteInfoDto> GetWithCompleteInfoById(Guid modemId)
        {
            var result = _modemDal.GetAllWithCompleteInfoById(modemId);
            if (result != null)
                return new SuccessDataResult<ModemWithCompleteInfoDto>(result);
            return new ErrorDataResult<ModemWithCompleteInfoDto>();
        }

        public IResult Update(Modem modem)
        {
            _modemDal.Update(modem);
            return new SuccessResult();
        }

    }
}
