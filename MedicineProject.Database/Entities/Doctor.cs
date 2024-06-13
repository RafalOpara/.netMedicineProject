using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineProject.Database
{
    public class Doctor : BaseEntity
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkYears { get; set; }
        public bool IsAbleToMakePrescription { get; set; }


        ///wiązanie ze sobą tebelek za pomocą relacji: - jeden do wielu


        [NotMapped]
        public virtual IEnumerable<Prescription> Prescriptions { get; set; }

        //public ICollection<Prescription> Prescriptions { get; set; }

    }
}
