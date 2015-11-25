using Contacts.Repository.Infrastructure;
using Contacts.Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Repository
{
   public class AddressRepository : BaseRepository<Address>
    {
     
        public AddressRepository(IUnitOfWork unit)
            : base(unit)
        {
          
        }

    }
}
