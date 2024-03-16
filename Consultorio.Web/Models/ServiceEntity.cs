using System.ComponentModel.DataAnnotations;

namespace Consultorio.Web.Models
{
    public class ServiceEntity
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Valor")]
        public decimal Value { get; set; }

        [Display(Name = "Duração")]
        public int Duration { get; set; }
    }
}
