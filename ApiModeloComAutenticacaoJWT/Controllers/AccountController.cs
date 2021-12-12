using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using ApiModeloComAutenticacaoJWT.Models;
using ApiModeloComAutenticacaoJWT.Repositories;
using ApiModeloComAutenticacaoJWT.Services;
using ApiModeloComAutenticacaoJWT.Interfaces;

namespace ApiModeloComAutenticacaoJWT.Controllers
{
    [Route("v1/account")]
    public class AccountController : Controller
    {
        private readonly IUserRepository userRepository;
        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserModel model)
        {
            var user = userRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            //user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public ActionResult Anonymous()
        {
            return new OkObjectResult(new { retorno = "Anônimo" });
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public ActionResult Authenticated()
        {
            return new OkObjectResult(new { retorno = $"Autenticado - {User.Identity.Name}" });
        }

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public ActionResult Employee()
        {
            return new OkObjectResult(new { retorno = "Funcionário" });
        }

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public ActionResult Manager()
        {
            return new OkObjectResult(new { retorno = "Gerente" });
        }

    }
}
