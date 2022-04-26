using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.Models
{
    [Table("CourseGroups")]
    public class CourseGroup : Base<int>
    {
        public int ClassId { get; set; }
        //Öğretmen id gelecek

        public int CourseId { get; set; }


        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime FinishDate { get; set; }

        public int Capasite { get; set; }

        //public bool IsCompleted {get; set;} ?? bilemedim.


        [Required]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Kurs portal numarası 7 haneli olmalıdır!")]
        //TODO: isunique eklensin

        public string PortalCode { get; set; } //1101064 







    }
}
