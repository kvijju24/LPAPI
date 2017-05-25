using LaunchPad.Data.Infrastructure;
using LaunchPad.Data.Repositories;
using LaunchPad.Entities;
using LaunchPad.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IEntityBaseRepository<User> _userRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;


        public SecurityService(IEntityBaseRepository<User> userRepository, IEncryptionService encryptionService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
        }
        private bool isPasswordValid(User user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);
        }
        private bool isUserValid(User user, string password)
        {
            if (isPasswordValid(user, password))
            {
                return !user.IsLocked;
            }
            return false;
        }
        //public SecurityContext ValidateUser(string username, string password)
        //{
        //    var membershipCtx = new SecurityContext();
        //    var user = _userRepository.GetAll().FirstOrDefault(x => x.Username == username);
        //    if (user != null && isUserValid(user, password))
        //    {
        //        //var userRoles = GetUserRoles(user.Username);
        //        var userRoles = new List<string> { "admin" };
        //        membershipCtx.User = user;
        //        var identity = new GenericIdentity(user.Username);
        //        membershipCtx.Principal = new GenericPrincipal(
        //            identity,
        //            userRoles.ToArray());
        //    }
        //    return membershipCtx;
        //}
        public SecurityContext ValidateUser(string username, string password)
        {
            var membershipCtx = new SecurityContext();

            var user = new User { Username = "gsparkman" };
            if (user != null)
            {
                //var userRoles = GetUserRoles(user.Username);
                var userRoles = new List<string> { "admin" };
                membershipCtx.User = user;
                var identity = new GenericIdentity(user.Username);
                membershipCtx.Principal = new GenericPrincipal(
                    identity,
                    userRoles.ToArray());
            }
            return membershipCtx;
        }
    }
}
