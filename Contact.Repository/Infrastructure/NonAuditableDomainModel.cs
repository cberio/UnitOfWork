using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using July.Common.Infrastructure.Contract;

namespace July.Common.Infrastructure
{
    public class NonAuditableDomainModel<T> : IBaseDomainModel where T : class
    {
        public Guid Id { get; set; }

    }
}
