using DeltaBall.Data.Models;

namespace DeltaBall.Data.Repositories.Interfaces
{
    public interface IUserExpChangeModeRepo
    {
        public UserExpChangeMode GetChangeModeById(int id);

        public IEnumerable<UserExpChangeMode> GetChangeModes();

        public void SaveChangeMode(UserExpChangeMode obj);

        public bool DeleteChangeMode(UserExpChangeMode obj);
    }
}
