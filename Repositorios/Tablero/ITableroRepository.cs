using EspacioTablero;

namespace Interfaces.ITableroReposiroty;

public interface ITableroReposiroty {
  List<Tablero> GetTableros();
  Tablero GetTablero(int id);
  List<Tablero> GetTablerosByUserId(int id);
  void CrearTablero(Tablero tablero);
  void ModificarTablero(int id, Tablero tablero);
  void EliminarTablero(int id);
}