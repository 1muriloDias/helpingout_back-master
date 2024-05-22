using helpingout.Data;
using helpingout.Dtos.Usuario;
using helpingout.Interfaces;
using helpingout.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using helpingout.Dtos;

namespace helpingout.Repositories
{
	public class UsuarioRepository : IUsuarioRepository
	{
		private readonly ApiContext _context;

		public UsuarioRepository(ApiContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Usuario>> GetAllAsync(QueryObject query)
		{
			return await _context.Usuarios.ToListAsync();
		}

		public async Task<Usuario> GetByEmailAsync(string email)
		{
			return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
		}

		public async Task CreateAsync(Usuario usuario)
		{
			_context.Usuarios.Add(usuario);
			await _context.SaveChangesAsync();
		}

		public async Task<Usuario> UpdateAsync(string email, ImagemUsuarioRequestDto imagemDto)
		{
			var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
			if (usuario == null) return null;

			// Atualiza os campos necessários, por exemplo:
			// usuario.ImagemUrl = imagemDto.ImagemUrl;

			await _context.SaveChangesAsync();
			return usuario;
		}

		public async Task<Usuario> DeleteAsync(string email)
		{
			var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
			if (usuario == null) return null;

			_context.Usuarios.Remove(usuario);
			await _context.SaveChangesAsync();
			return usuario;
		}

		public async Task<bool> UsuarioHasAccount(string email, string senha)
		{
			var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
			if (usuario == null) return false;

			return BCrypt.Net.BCrypt.Verify(senha, usuario.Senha);
		}

		public async Task<bool> ResetSenha(string email, string senhaCriptografada)
		{
			var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
			if (usuario == null) return false;

			usuario.Senha = senhaCriptografada;
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
