using System.ComponentModel.DataAnnotations;

namespace ShipCompliantMVC.Models
{
    public class Step
    {
        public int StepId { get; set; }

        public string Description { get; set; }

        [Range(1,100)]
        [Display(Name = "Step Number")]
        public int Num { get; set; }
    }
}