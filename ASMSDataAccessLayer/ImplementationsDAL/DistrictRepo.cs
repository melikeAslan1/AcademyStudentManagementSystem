using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSDataAccessLayer.ContractsDAL;
using ASMSEntityLayer.Models;
namespace ASMSDataAccessLayer.ImplementationsDAL
{
    public class DistrictRepo : RepositoryBase<District, int>, IDistrictRepo
    {
        public DistrictRepo(MyContext myContext) : base(myContext)
        {

        }
    }
}