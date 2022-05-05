using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSBusinessLayer.ContractsBLL;
using ASMSDataAccessLayer.ContractsDAL;
using ASMSEntityLayer.ResultModels;
using ASMSEntityLayer.ViewModels;
using AutoMapper;
using ASMSEntityLayer.Models;

namespace ASMSBusinessLayer.ImplementationsBLL
{
    public class UserAddressBusinessEngine : IUserAddressBusinessEngine
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        public UserAddressBusinessEngine(IUnitOfWork unitofWork,
            IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public IResult Add(UsersAddressVM address)
        {
            try
            {
                UsersAddress newAddress = _mapper.Map<UsersAddressVM, UsersAddress>(address);

                return _unitofWork.UsersAddressRepo.Add(newAddress) ?
                    new SuccessResult("Adres Eklendi"):
                    new ErrorResult("Adres Eklenmedi");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<ICollection<UsersAddressVM>> GetAll(string userId)
        {
            try
            {
                if (userId!=null)
                {
                    var userAddressList = _unitofWork.UsersAddressRepo.GetAll(x => x.UserId == userId);
                    var result = _mapper.Map<IQueryable<UsersAddress>, ICollection<UsersAddressVM>>(userAddressList);

                    return new SuccessDataResult<ICollection<UsersAddressVM>>(result, $"{result.Count} address has been found");
                }
                else
                {
                    throw new Exception("userId is null so it couldn't able to find useraddress!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
