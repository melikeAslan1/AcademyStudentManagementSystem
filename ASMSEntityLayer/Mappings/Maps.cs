using ASMSEntityLayer.Models;
using ASMSEntityLayer.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.Mappings
{
    public class Maps:Profile
    {
        //Buraya CreateMap metodu gelecektir.
        //İçine CreateMap metodu gelecek.

          public Maps()
          {
              /* //UsersAddress'ı UserAddresesVM'ye dönüştür.
               CreateMap<UsersAddress, UsersAddressVM>();  //DAL --> BLL

               //UserAddressVM'yi UserAddress'e dönüştür.
               CreateMap<UsersAddressVM, UsersAddress>();  //PL --> BLL --> DAL     */



               //Yukarıdakinin aynısı tek seferde yapmak.
               //UserAddress ve VM'yi birbirine dönüştür.
               CreateMap<UsersAddress, UsersAddressVM>().ReverseMap();
               CreateMap<Student, StudentVM>().ReverseMap();
               CreateMap<City, CityVM>().ReverseMap();
               CreateMap<District, DistrictVM>().ReverseMap();
               CreateMap<Neighbourhood, NeighbourhoodVM>().ReverseMap();




          } 



    }
}
