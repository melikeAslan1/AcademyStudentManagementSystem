using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSBusinessLayer.ContractsBLL;
using ASMSDataAccessLayer.ContractsDAL;
using ASMSEntityLayer.Models;
using ASMSEntityLayer.ResultModels;
using ASMSEntityLayer.ViewModels;
using AutoMapper;

namespace ASMSBusinessLayer.ImplementationsBLL
{
    public class CityBusinessEngine : ICityBusinessEngine
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        public CityBusinessEngine(IUnitOfWork unitofWork,
            IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public IResult Add(CityVM city)
        {
            try
            {
                City newCity = _mapper.Map<CityVM, City>(city);
                var insertResult = _unitofWork.CityRepo.Add(newCity);

                return insertResult ?
                    new SuccessResult("İl eklendi") :
                    new ErrorResult("İl eklemede bir hata oluştu! Tekrar deneyiniz");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IResult Delete(CityVM city)
        {
            throw new NotImplementedException();
        }

        public IDataResult<ICollection<CityVM>> GetAll()
        {
            try
            {   //select * from Cities inner join Distircts ....
                var cities = _unitofWork.CityRepo.GetAll(x => !x.IsDeleted
                , includeEntities: "Districts");

                ICollection<CityVM> allCities
                    = _mapper.Map<IQueryable<City>, ICollection<CityVM>>(cities);

                return new SuccessDataResult<ICollection<CityVM>>(allCities,
                    $"{allCities.Count} adet il listelendi");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<CityVM> GetById(int cityId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CityVM> GetFirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public IResult Update(CityVM city)
        {
            throw new NotImplementedException();
        }
    }
}