using helpingout.Models;
using helpingout.Dtos;
using helpingout.Dtos.Usuario;

namespace helpingout.Mappers
{
	public static class UsuarioMapper
	{
		public static Usuario ToUsuarioFromCreateDTO(this CreateUsuarioRequestDto dto)
		{
			return new Usuario
			{
				Email = dto.Email,
				Nome = dto.Nome,
				Senha = dto.Senha, // Senha será criptografada no controlador
				Cpf = dto.Cpf,
				Endereco = dto.Endereco,
				Telefone = dto.Telefone,
				DataNascimento = dto.DataNascimento,
				Curso = dto.Curso,
				Professor = dto.Professor,
				Materia = dto.Materia
			};
		}

		public static UsuarioDto ToUsuarioDto(this Usuario usuario)
		{
			return new UsuarioDto
			{
				Id = usuario.Id,
				Email = usuario.Email,
				Nome = usuario.Nome,
				Cpf = usuario.Cpf,
				Endereco = usuario.Endereco,
				Telefone = usuario.Telefone,
				DataNascimento = usuario.DataNascimento,
				Curso = usuario.Curso,
				Professor = usuario.Professor,
				Materia = usuario.Materia
			};
		}
	}
}
