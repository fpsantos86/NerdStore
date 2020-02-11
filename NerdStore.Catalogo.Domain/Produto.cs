﻿using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Catalogo.Domain
{
	public class Produto : Entity, IAggregateRoot
	{
		public Guid CategoriaId { get; private set; }
		public string Nome { get; private set; }
		public string Descricao { get; private set; }
		public bool Ativo { get; private set; }
		public decimal Valor { get; private set; }
		public DateTime DataCadastro { get; private set; }
		public string Imagem { get; private set; }
		public int QuantidadeEstoque { get; private set; }
		public Dimensoes Dimensoes { get; private set; }
		public Categoria Categoria { get; private set; }
		
		public Produto(string nome, string descricao, bool ativo, decimal valor, Guid categoriaId, DateTime dataCadastro,string imagem, Dimensoes dimensoes)
		{
			CategoriaId = categoriaId;
			Nome = nome;
			Descricao = descricao;
			Ativo = ativo;
			Valor = valor;
			DataCadastro = dataCadastro;
			Imagem = imagem;
			Dimensoes = dimensoes;

			Validar();
		}
		

		// O nome desses métodos, segundo o Eduardo Pires é Adhoc Setters. 
		// Lembrando que eles alteram o valor de propriedes com private set.
		#region Métodos Adhoc
		public void Ativar() => Ativo = true;

		public void Desativar() => Ativo = false;

		public void AlterarCategoria(Categoria categoria)
		{
			Categoria = categoria;
			CategoriaId = categoria.Id;
		}

		public void AlterarDescricao(string descricao)
		{
			Descricao = descricao;
		}

		public void DebitarEstoque(int quantidade)
		{
			if (quantidade < 0) quantidade *= -1;
			if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente");
			QuantidadeEstoque -= quantidade;
		}

		public void ReporEstoque(int quantidade)
		{
			QuantidadeEstoque += quantidade;
		}

		public bool PossuiEstoque(int quantidade)
		{
			return QuantidadeEstoque >= quantidade;
		}
		#endregion

		public void Validar() 
		{
			Validacoes.ValidarSeVazio(Nome, "O Campo Nome do produto não pode estar vazio");
			Validacoes.ValidarSeVazio(Descricao, "O campo Descricao do produto não pode estar vazio");
			Validacoes.ValidarSeDiferente(CategoriaId, Guid.Empty, "O campo CategoriaId do produto não pode estar vazio");
			Validacoes.ValidarSeMenorIgualMinimo(Valor, 0, "O campo Valor do produto não poder ser menor igual a 0");
			Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do produto não pode estar vazio"); 
		}
	}
}
