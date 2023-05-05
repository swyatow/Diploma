using DeltaBall.Data.Models;

namespace DeltaBall.Data.Repositories.Interfaces
{
    public interface IShootRangeRepo
    {
        public ShootRange GetRangeById(Guid id);

        public IEnumerable<ShootRange> GetRanges();

        public void SaveRange(ShootRange obj);

        public bool DeleteRange(ShootRange obj);
    }
}
