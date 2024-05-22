using helpingout.Dtos.Usuario;
using helpingout.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using helpingout.Dtos;


namespace helpingout.Interfaces
{
	public interface IUsuarioRepository
	{
		Task<IEnumerable<Usuario>> GetAllAsync(QueryObject query);
		Task<Usuario> GetByEmailAsync(string email);
		Task CreateAsync(Usuario usuario);
		Task<Usuario> UpdateAsync(string email, ImagemUsuarioRequestDto imagemDto);
		Task<Usuario> DeleteAsync(string email);
		Task<bool> UsuarioHasAccount(string email, string senha);
		Task<bool> ResetSenha(string email, string senhaCriptografada);
	}
}
