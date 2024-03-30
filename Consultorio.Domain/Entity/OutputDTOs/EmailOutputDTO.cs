using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Domain.Entity.OutPutDTOs
{
    public class EmailOutputDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
