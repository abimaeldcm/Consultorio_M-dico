using System.ComponentModel.DataAnnotations;

namespace Consultorio.Web.Models
{
    public class Patient : User
    {
        [Display(Name = "Altura")]
        public double? Height { get; set; }
        [Display(Name = "Peso")]
        public double? Weight { get; set; }
    }
}
