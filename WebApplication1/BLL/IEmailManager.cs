using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.BLL
{
    public interface IEmailManager
    {
        IList<EmailVM> GetVMs();
        void Create();
        void Update(EmailVM vm);
        void Delete(int id);
    }
}