using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
	public class Categoria : Entity
	{
		public string Nome { get; set; }

		public int Codigo { get; set; }

		public Categoria(string nome, int codigo)
		{
			Nome = Nome;
			Codigo = Codigo;

			Validar();
		}

		public override string ToString()
		{
			return $"{Nome} - {Codigo}";
		}

		public void Validar() {
			Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio");
			Validacoes.ValidarSeIgual(Codigo, 0, "O campo Codigo não pode ser 0");
		}
	}
}
