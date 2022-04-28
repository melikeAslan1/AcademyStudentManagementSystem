using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSDataAccessLayer.ContractsDAL;
using ASMSEntityLayer.Models;


namespace ASMSDataAccessLayer.ImplementationsDAL
{
    public class StudentCourseGroupRepo : RepositoryBase<StudentsCourseGroup, int>, IStudentsCourseGroupRepo
    {
        public StudentCourseGroupRepo(MyContext myContext) : base(myContext)
        {

        }
    }
}
