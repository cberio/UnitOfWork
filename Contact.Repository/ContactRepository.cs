using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Repository.Infrastructure;
using Contacts.Repository.Infrastructure.Contract;
namespace Contacts.Repository
{
    public class ContactRepository: BaseRepository<Contact>
    {
        
        public ContactRepository(IUnitOfWork unit):base(unit)
        {

        }

    }
}
