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
    public class ModelManager:IModelService
    {
        private readonly IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult();
        }

        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);
            return new SuccessResult();
        }

        public IDataResult<List<Model>> GetAll()
        {
            var result= _modelDal.GetAll();
            if (result != null)
                return new SuccessDataResult<List<Model>>(result);
            return new ErrorDataResult<List<Model>>();
        }

        public IDataResult<Model> GetById(Guid modelId)
        {
            var result= _modelDal.Get(m=>m.Id == modelId);
            if (result != null)
                return new SuccessDataResult<Model>(result);
            return new ErrorDataResult<Model>();
        }

        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult();
        }
    }
}
