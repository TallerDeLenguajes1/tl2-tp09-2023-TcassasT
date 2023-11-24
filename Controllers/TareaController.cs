namespace Controllers;

using EspacioTarea;
using Interfaces.ITableroReposiroty;
using Interfaces.ITareaRepository;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class TareaController: ControllerBase {
  private ITableroReposiroty tableroRepository = new TableroRepository();
  private ITareaRepository tareaRepository = new TareaRepository();
  private readonly ILogger<TareaController> _logger;
  public TareaController(ILogger<TareaController> logger) {
    _logger = logger;
  }

  [HttpPost("tarea")]
  public IActionResult CrearTarea(Tarea tarea) {
    if (tableroRepository.GetTablero(tarea.IdTablero) == null) {
      return NotFound("No se encontró tablero para tarea");
    }

    tareaRepository.CrearTareaEnTablero(tarea);

    return Ok("Tarea creada");
  }

  [HttpPut("tarea/{id}/nombre/{nombre}")]
  public IActionResult UpdateNombre(int id, String nombre) {
    Tarea tarea = tareaRepository.GetTarea(id);

    if (tarea == null) {
      return NotFound("No se encontró tarea");
    }

    tarea.Nombre = nombre;
    tareaRepository.ModificarTarea(id, tarea);

    return Ok("Nombre de tarea actualizado");
  }

  [HttpPut("tarea/{id}/estado/{estado}")]
  public IActionResult UpdateEestado(int id, int estado) {
    Tarea tarea = tareaRepository.GetTarea(id);

    if (tarea == null) {
      return NotFound("No se encontró tarea");
    }

    tarea.Estado = (EstadoTarea) estado;
    tareaRepository.ModificarTarea(id, tarea);

    return Ok("Estado de tarea actualizado");
  }

  [HttpDelete("tarea/{id}")]
  public IActionResult BorrarTarea(int id) {
    if (tareaRepository.GetTarea(id) == null) {
      return NotFound("No se encontró tarea");
    }

    tareaRepository.EliminarTarea(id);
    
    return Ok("Tarea eliminada");
  }

  [HttpGet("tarea/{estado}")]
  public IEnumerable<Tarea> GetTareasByEstado(int estado) {
    return tareaRepository.GetTareasByEstado(estado);
  }

  [HttpGet("tarea/usuario/{id}")]
  public IEnumerable<Tarea> GetTareasByUsuarioId(int usuarioId) {
    return tareaRepository.GetTareasByUsuarioId(usuarioId);
  }

  [HttpGet("tarea/tablero/{id}")]
  public IEnumerable<Tarea> GetTareasByTableroId(int tableroId) {
    return tareaRepository.GetTareasByTableroId(tableroId);
  }
}