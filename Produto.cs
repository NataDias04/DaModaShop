using System;

class Produto {
  private string  nome;
  private int       id;
  private Double preco;
  private int  estoque;
  private int  estoque_minimo;

  public Produto(string nome, int id, float preco, int estoque, int estoque_minimo){
    this.nome = nome;
    this.id = id;
    this.preco = preco;
    this.estoque = estoque;
    this.estoque_minimo = estoque_minimo;
  }

  public string GetNomeProduto()
  {
    return nome;
  }

  public void SetNomeProduto(string NovoNome)
  {
    nome = NovoNome;
  }

  public int GetIdProduto()
  {
    return id;
  }

  public void SetId(int NovoId)
  {
    id = NovoId;
  }

  public Double GetPreco()
  {
    return preco;
  }

  public void SetPreco(Double NovoPreco)
  {
    preco = NovoPreco;
  }

  public int GetEstoque()
  {
    return estoque;
  }

  public void SetEstoque(int NovoEstoque)
  {
    estoque = NovoEstoque;
  }

  public int GetEstoqueMinimo()
  {
    return estoque_minimo;
  }

  public void SetEstoqueMinimo(int NovoEstoqueMinimo)
  {
    estoque_minimo = NovoEstoqueMinimo;
  }

  public void AdicionarAoCarrinho(Cliente cliente, LojaVirtual loja)
  {
    if(loja.VerificaDisponibilidade(this) == true)
    {
      if(estoque > 0){
        cliente.GetCarrinho().Add(this);
        this.SetEstoque(this.GetEstoque() - 1);
        Console.WriteLine("O PRODUTO FOI ADICIONADO DO CARRINHO COM SUCESSO");
      }
      else
      {
        Console.WriteLine("ESTE PRODUTO INDISPONÍVEL NO MOMENTO");
      }
    }
    else
    {
      Console.WriteLine("ESTE PRODUTO INDISPONÍVEL NO MOMENTO");
    }
  }

  public void RemoverDoCarrinho(Cliente cliente)
  {
    for(int i = cliente.GetCarrinho().Count - 1; i >= 0;i--)
    {
      if(cliente.GetCarrinho()[i] == this)
      {
        cliente.GetCarrinho().RemoveAt(i);
        this.SetEstoque(this.GetEstoque() + 1);
        Console.WriteLine("O PRODUTO FOI REMOVIDO DO CARRINHO COM SUCESSO");
      }
      else
      {
        Console.WriteLine("ESTE PRODUTO NÂO SE ENCONTRA NO CARRINHO");
      }
    }
  }

  public void ExibirDetalhes()
  {
    Console.WriteLine("NOME DO PODUTO: {0} \n  ID DO PRODUTO: {1} \n PREÇO DO PRODUTO: {2} \n ESTOQUE DO PRODUTO: {3}",nome.ToUpper(), id, preco, estoque);
  }

  public void VerificaEstoque()
  {
    if(estoque <= estoque_minimo)
    {
      Console.WriteLine("ESTOQUE MINIMO ALCANÇADO");
      Console.WriteLine("O ESTOQUE ATUAL DO PRODUTO E DE: {0} ", estoque);
    }
    else
     {
      Console.WriteLine("O ESTOQUE ATUAL DO PRODUTO E DE: {0} ", estoque);
    }
  }
}