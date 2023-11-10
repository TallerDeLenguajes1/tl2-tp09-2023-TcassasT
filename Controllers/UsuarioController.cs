using EspacioUsuario;
using Interfaces.IUsuarioRepository;
using Microsoft.AspNetCore.Mvc;
using Repositorios.UsuarioRepository;

[ApiController]
[Route("api")]
public class UsuarioController: ControllerBase {
  private IUsuarioRepository usuarioRepository = new UsuarioRepository();
  private readonly ILogger<UsuarioController> _logger;
  public UsuarioController(ILogger<UsuarioController> logger) {
      _logger = logger;
  }

  [HttpGet("usuario")]
  public IEnumerable<Usuario> GetUsuarios() {
    List<Usuario> usuarios = usuarioRepository.GetUsuarios();
    return usuarios;
  }

  [HttpGet("usuario/{id}")]
  public IActionResult GetUsuario(int id) {
    Usuario usuario = usuarioRepository.GetUsuario(id);
    if (usuario != null) {
      return Ok(usuario);
    } else {
      return NotFound("Usuario no encontrado");
    }
  }

  [HttpPost("usuario")]
  public IActionResult PostUsuario(Usuario usuario) {
    usuarioRepository.CrearUsuario(usuario);
    return Ok("Usuario creado");
  }

  [HttpPut("usuario/{id}/nombre")]
  public IActionResult ModificarNombreUsuario(int id, Usuario usuario) {
    Usuario usuarioAModificar = usuarioRepository.GetUsuario(id);

    if (usuarioAModificar == null) {
      return NotFound("Usuario no encontrado");
    }

    usuarioRepository.ModificarUsuario(id, usuario);

    return Ok("Usuario modificado");
  }

  [HttpDelete("usuario/{id}")]
  public IActionResult EliminarUsuario(int id) {
    Usuario usuarioAEliminar = usuarioRepository.GetUsuario(id);

    if (usuarioAEliminar == null) {
      return NotFound("Usuario no encontrado");
    }

    usuarioRepository.EliminarUsuario(id);

    return Ok("Usuario eliminado");
  }
}
