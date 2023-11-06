using EspacioUsuario;
using Interfaces.IUsuarioRepository;
using Microsoft.AspNetCore.Mvc;
using Repositorios.UsuarioRepository;

[ApiController]
[Route("controller")]
public class UsuarioController: ControllerBase {
  private IUsuarioRepository usuarioRepository = new UsuarioRepository();
  private readonly ILogger<UsuarioController> _logger;
  public UsuarioController(ILogger<UsuarioController> logger) {
      _logger = logger;
  }

  [HttpGet("api/usuario")]
  public IEnumerable<Usuario> GetUsuarios() {
    List<Usuario> usuarios = usuarioRepository.GetUsuarios();
    return usuarios;
  }

  [HttpGet("api/usuario/{id}")]
  public IActionResult GetUsuario(int id) {
    Usuario usuario = usuarioRepository.GetUsuario(id);
    if (usuario != null) {
      return Ok(usuario);
    } else {
      return NotFound("Usuario no encontrado");
    }
  }
}
