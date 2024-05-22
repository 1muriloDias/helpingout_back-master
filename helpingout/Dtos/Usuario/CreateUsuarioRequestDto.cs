namespace helpingout.Dtos.Usuario
{
	public class CreateUsuarioRequestDto
	{
		public string Email { get; set; }
		public string Nome { get; set; }
		public string Senha { get; set; }
		public string Professor { get; set; }
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Curso { get; set; }
        public string Materia { get; set; }
    }
}
