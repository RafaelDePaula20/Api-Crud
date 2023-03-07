using Microsoft.EntityFrameworkCore;
using SystemTask.Data;
using SystemTask.Models;
using SystemTask.Repositorios.Interfaces;

namespace SystemTask.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContex _dbcontex;
        public UsuarioRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dbcontex = sistemaTarefasDBContex;

        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbcontex.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbcontex.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
           await _dbcontex.Usuarios.AddAsync(usuario);
           await _dbcontex.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            
            if(usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados");
            }

            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;

            _dbcontex.Usuarios.Update(usuarioPorId);
          await _dbcontex.SaveChangesAsync();

            return usuarioPorId;

        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if(usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados");

            }

            _dbcontex.Usuarios.Remove(usuarioPorId);
            await _dbcontex.SaveChangesAsync();

            return true;
        }

        

       
    }
}
