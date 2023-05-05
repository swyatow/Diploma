using DeltaBall.Data.Models;

namespace DeltaBall.Data.Repositories.Interfaces
{
    public interface IPriceRepo
    {
        public Price GetPriceById(int id);

        public IEnumerable<Price> GetPrices();

        public void SavePrice(Price obj);

        public bool DeletePrice(Price obj);
    }
}
