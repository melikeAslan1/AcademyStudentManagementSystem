using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSEntityLayer.ResultModels;
using ASMSEntityLayer.ViewModels;

namespace ASMSBusinessLayer.ContractsBLL
{
    public interface IUserAddressBusinessEngine
    {
        //Ekleme*
        //Düzenleme
        //Silme
        //Listeleme*

        IResult Add(UsersAddressVM address);

        IDataResult<ICollection<UsersAddressVM>> GetAll(string userId);

    }
}
