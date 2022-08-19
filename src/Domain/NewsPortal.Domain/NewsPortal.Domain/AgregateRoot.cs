using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Domain
{
    public class AgregateRoot
    {
        public Guid NewsID { get; protected set; }
    }
}
