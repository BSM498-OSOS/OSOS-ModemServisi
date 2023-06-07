using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result=_brandDal.GetAll();
            if(result!=null)
                return new SuccessDataResult<List<Brand>>(result);
            return new ErrorDataResult<List<Brand>>();
        }

        public IDataResult<Brand> GetById(Guid brandId)
        {
            var result= _brandDal.Get(b=>b.Id == brandId);
            if (result != null)
                return new SuccessDataResult<Brand>(result);
            return new ErrorDataResult<Brand>();
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult();
        }
    }
}
