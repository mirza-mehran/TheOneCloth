using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOneCloth.Entities;

namespace TheOneCloth.Services
{
    public interface ICountry
    {
        Task SaveCountry(Countries model);
        List<Countries> ViewAll();
        Task<Countries> GetCountry(int id);
        Task GetCountry(Countries model);
        Task DeleteCountry(int id);

    }
}
