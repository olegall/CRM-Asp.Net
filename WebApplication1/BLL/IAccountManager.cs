using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.BLL
{
    public interface IAccountManager
    {
        IList<AccountVM> GetVMs();
        void Create();
        void Update(AccountVM vm);
        void Delete(int id);
    }
}