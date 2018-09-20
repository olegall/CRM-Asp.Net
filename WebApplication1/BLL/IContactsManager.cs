using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.BLL
{
    public interface IActsManager
    {
        IList<ActVM> GetVMs();
        void Create();
        void Update(ActVM vm);
        void Delete(int id);
    }
}