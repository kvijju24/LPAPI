using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Services.Abstract
{
    public interface ISecurityService
    {
        SecurityContext ValidateUser(string username, string password);
        //User CreateUser(string username, string email, string password, int[] roles);
        //User GetUser(int userId);
        //List<Role> GetUserRoles(string username);
    }
}
