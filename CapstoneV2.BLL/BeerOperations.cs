using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneV2.Data;
using CapstoneV2.Models.Data;
using CapstoneV2.Models.Interfaces;

namespace CapstoneV2.BLL
{
    public class BeerOperations
    {
        private IRepository _repo = RepositoryFactory.CreateRepository();

        public List<Beer> GetBeerOnTap()
        {
            return _repo.GetAllBeers().Where(b => b.IsAvailable).ToList();
        }

        
    }
}
