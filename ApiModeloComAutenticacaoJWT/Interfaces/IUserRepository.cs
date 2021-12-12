using ApiModeloComAutenticacaoJWT.Models;

namespace ApiModeloComAutenticacaoJWT.Interfaces
{
    public interface IUserRepository
    {
        public UserModel Get(string username, string password);
    }
}
