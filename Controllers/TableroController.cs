namespace Controllers;

using EspacioTablero;
using Interfaces.ITableroReposiroty;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class TableroController: ControllerBase {
  private ITableroReposiroty tableroRepository = new TableroRepository();
  private readonly ILogger<TableroController> _logger;
  public TableroController(ILogger<TableroController> logger) {
    _logger = logger;
  }

  [HttpGet("tableros")]
  public IEnumerable<Tablero> GetTableros() {
    return tableroRepository.GetTableros();
  }

  [HttpPost("tableros")]
  public IActionResult CrearTablero(Tablero tablero) {
    tableroRepository.CrearTablero(tablero);
    return Ok("Tablero creado");
  }
}