using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSDataAccessLayer.ContractsDAL
{
    public interface IUnitOfWork //içine bütün repoları alacak.
    {
        ICityRepo CityRepo { get;  }

        IClassRepo ClassRepo { get;  }

        ICourseGroupRepo CourseGroupRepo { get;  }

        ICourseRepo CourseRepo { get;  }

        IDistrictRepo DistrictRepo { get;  }

        INeighbourhoodRepo NeighbourhoodRepo { get;  }

        IStudentAttendanceRepo StudentAttendanceRepo { get;  }

        IStudentRepo StudentRepo { get;  }

        IStudentsCourseGroupRepo StudentsCourseGroupRepo { get;  }

        ITeacherRepo TeacherRepo { get;  }

        IUsersAddressRepo UsersAddressRepo { get;  }








    }
}
