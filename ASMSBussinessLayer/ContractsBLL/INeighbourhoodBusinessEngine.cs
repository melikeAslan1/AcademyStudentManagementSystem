using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSEntityLayer.ResultModels;
using ASMSEntityLayer.ViewModels;

namespace ASMSBusinessLayer.ContractsBLL
{
   public interface INeighbourhoodBusinessEngine
    {
        //Buraya birçok metot yazılabilir.
        //Biz şuanda zamanımız kısıtlı olduğu için sadece işimizin olduğu en kritik metodu yazalım.

        IDataResult<ICollection<NeighbourhoodVM>> GetNeighbourhoodsOfDistrict(int districtId);




       // IDataResult<ICollection<>> GetDistrictsOfCity(byte cityId);



    }
}
