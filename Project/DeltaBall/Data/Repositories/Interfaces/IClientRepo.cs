using DeltaBall.Data.Models;

namespace DeltaBall.Data.Repositories.Interfaces
{
    public interface IClientRepo
    {
        public Client GetClientById(Guid id);

        public IEnumerable<Client> GetClients();

        public void SaveClient(Client obj);

        public bool DeleteClient(Client obj);
    }
}
