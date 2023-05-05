using DeltaBall.Data.Models;

namespace DeltaBall.Data.Repositories.Interfaces
{
    public interface IRankRepo
    {
        public Rank GetRankById(int id);

        public IEnumerable<Rank> GetRanks();

        public void SaveRank(Rank obj);

        public bool DeleteRank(Rank obj);
    }
}
