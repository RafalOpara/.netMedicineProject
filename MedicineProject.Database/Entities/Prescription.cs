using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineProject.Database
{
    public class Prescription : BaseEntity
    {
        
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }


        ///wiązanie ze sobą tebelek za pomocą relacji: -  realcja wiele do jednego 


          [ForeignKey("Doctor")]
          public int DoctorId { get; set; }
          public virtual Doctor Doctor { get; set; }


        ///wiązanie ze sobą tebelek za pomocą relacji: - jeden do wielu

          [NotMapped]
         public virtual IEnumerable<Medicine> Medicines { get; set; }
        
    }
}
