using LR2TIS.Models;
using System.Collections.Generic;
namespace Users.Models
{
    public interface IRepository
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        void Create(User user);
    }
}