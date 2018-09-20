using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.BLL
{
    public interface IContractsManager
    {
        IList<ContractVM> GetVMs();
        void Create();
        void Update(ContractVM vm);
        void Delete(int id);
    }
}