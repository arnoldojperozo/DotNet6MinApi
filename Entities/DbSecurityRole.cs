using System;
using System.Collections.Generic;

namespace DotNet6MinApi.Entities
{
    public partial class DbSecurityRole
    {
        public DbSecurityRole()
        {
            DbUser = new HashSet<DbUser>();
        }

        public int IdSecurityRole { get; set; }
        public string SecurityRoleName { get; set; } = null!;
        public int? CreUser { get; set; }
        public DateTime CreDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public string? Client { get; set; }
        public string? ClientIp { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<DbUser> DbUser { get; set; }
    }
}
