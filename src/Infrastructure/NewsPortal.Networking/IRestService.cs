using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Networking
{
    public interface IRestService
    {
        Task<T> GetItem<T>(string path);
        Task<ICollection<T>> GetItems<T>(string path);

        void Init(string host);
    }
}
