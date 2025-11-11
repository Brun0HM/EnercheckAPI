using EnercheckAPI.Models;
using EnercheckAPI.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnercheckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        // GET: api/<UsuariosController>

        public UsuariosController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] Registro model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            var usuario = new Usuario
            {
                NomeCompleto = model.Nome,
                Email = model.Email

            };
            var result = await _userManager.CreateAsync(usuario, model.Senha);

            if (result.Succeeded)
            {
                return Ok(new { Message = "Usuário registrado com sucesso. " });
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var result = await _signInManager.PasswordSignInAsync(
                model.Email,
                model.Senha,
                isPersistent: false,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Está sem JWT, logo só vou mandar uma msg pra falar que deu certo o login
                return Ok(new { Message = "Login bem-sucedido!" });
            }

            if (result.IsLockedOut)
            {
                return Unauthorized(new { Message = "Conta bloqueada." });
            }
            if (result.IsNotAllowed)
            {

                return Unauthorized(new { Message = "Login não permitido. Confirme seu e-mail." });
            }


            return Unauthorized(new { Message = "Credenciais inválidas." });
        }



    }
}

