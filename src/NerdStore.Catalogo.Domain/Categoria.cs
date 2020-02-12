using NerdStore.Core.DomainObjects;
using System.Collections.Generic;

namespace NerdStore.Catalogo.Domain
{
	public class Categoria : Entity
	{
		public string Nome { get; set; }

		public int Codigo { get; set; }

		public ICollection<Produto>  Produtos{ get;private set; }

		protected Categoria() { }

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
