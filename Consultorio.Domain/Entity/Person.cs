using Consultorio.Domain.Entity.Enum;

namespace Consultorio.Domain.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber{ get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public ETBloodType BloodType { get; set; }
        public string Address { get; set; }
    }
}
