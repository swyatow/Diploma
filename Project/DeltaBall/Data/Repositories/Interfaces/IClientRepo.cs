using DeltaBall.Data.Models;

namespace DeltaBall.Data.Repositories.Interfaces
{
    public interface IClientRepo
    {
        /// <summary>
        /// Получить клиента по его ID
        /// </summary>
        /// <param name="id">Guid клиента</param>
        /// <returns></returns>
        public Client GetClientById(Guid id);

        /// <summary>
        /// Получить список всех клиентов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Client> GetClients();

        /// <summary>
        /// Создать нового или изменить существующего клиента
        /// </summary>
        /// <param name="obj">Объект клиента</param>
        public void SaveClient(Client obj);

        /// <summary>
        /// Каскадное удаление клиента из базы 
        /// </summary>
        /// <param name="obj">Объект клиента</param>
        /// <returns></returns>
        public bool DeleteClient(Client obj);
    }
}
