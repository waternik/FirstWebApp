using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebApp.Repository.Interfaces
{
    public interface IUserProfile
    {
        int UserId { get; set; }
        string UserName { get; set; }
        string FullUserName { get; set; }
    }
}
