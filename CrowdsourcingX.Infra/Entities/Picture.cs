using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdsourcingX.Infra.Entities
{
    public class Picture : BaseEntity
    {
        public string Name { get; set; }
        public string Data { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        
    }
}
