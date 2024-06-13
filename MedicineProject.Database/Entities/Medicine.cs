using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineProject.Database
{
    public class Medicine : BaseEntity
    {
       
        public string Name { get; set; }
        public string CompanyName { get; set; }

        public string ActiveSubstance { get; set; }

        public decimal Weight { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        public DateTime ExpirationDate { get; set; }


        ///wiązanie ze sobą tebelek za pomocą relacji: - realcja wiele do jednego 


         [ForeignKey("Prescription")]
         public int PrescriptionId { get; set; }
         public virtual Prescription Prescriptions { get; set; }

        //public int PrescriptionId { get; set; }
        //public Prescription Prescription { get; set; }
    }
}
