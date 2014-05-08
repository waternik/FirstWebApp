using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebApp.Repository.Interfaces
{
    public interface IRepositoryRegistratedMembers
    {
        List<IRegistratedMember> GetRegistratedMembers();
        void AddRegMember(string nameUser);
        void RemoveRegMember(int id);
        void SaveChangeRegMember(IRegistratedMember item);
    }
}
