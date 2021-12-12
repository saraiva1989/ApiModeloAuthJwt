using ApiModeloComAutenticacaoJWT.Interfaces;
using ApiModeloComAutenticacaoJWT.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiModeloComAutenticacaoJWT.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserModel Get(string username, string password)
        {
            var users = new List<UserModel>();
            users.Add(new UserModel { Id = 1, Username = "manager", Password = "manager", Role = "manager" });
            users.Add(new UserModel { Id = 2, Username = "employee", Password = "employee", Role = "employee" });
            users.Add(new UserModel { Id = 1, Username = "outro", Password = "outro", Role = "outro" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
