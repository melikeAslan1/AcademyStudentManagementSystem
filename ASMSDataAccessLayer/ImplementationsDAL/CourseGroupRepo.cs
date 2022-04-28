using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSEntityLayer.Models;
using ASMSDataAccessLayer.ContractsDAL;

namespace ASMSDataAccessLayer.ImplementationsDAL
{
   public class CourseGroupRepo:RepositoryBase<CourseGroup,int>, ICourseGroupRepo
    {
        public CourseGroupRepo(MyContext myContext):base(myContext)
        {

        }

    }
}
