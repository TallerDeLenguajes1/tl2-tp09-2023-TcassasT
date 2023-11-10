using EspacioUsuario;

namespace Interfaces.IUsuarioRepository;

public interface IUsuarioRepository {
  void CrearUsuario(Usuario usuario);
  void ModificarUsuario(int id, Usuario usuario);
  List<Usuario> GetUsuarios();
  Usuario GetUsuario(int id);
  void EliminarUsuario(int id);
}