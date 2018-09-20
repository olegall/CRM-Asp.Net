using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.BLL
{
    public interface IAdditionalAgreementsManager
    {
        IList<AdditionalAgreementVM> GetVMs();
        void Create();
        void Update(AdditionalAgreementVM vm);
        void Delete(int id);
    }
}