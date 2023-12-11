using System;

using System.Collections.Generic;

class LojaVirtual 
{
  private string[ ] forma_de_pagamento;
  private List<Produto>  catalogo;
  private List<Cliente>   clientes;

  public LojaVirtual()
  {
    this.forma_de_pagamento = new string[] {"CARTAO","DINHEIRO"};
    
    this.catalogo = new List<Produto>();
    this.clientes = new  List<Cliente>();
  }

  public string[] GetFormaDePagamento()
  {
    return forma_de_pagamento;
  }

  public List<Cliente> GetListaDeClientes()
  {
    return clientes;
  }

  public void LimpaListaDeClientes(){
    clientes.Clear();
  }
  
  public bool VerificaDisponibilidade(Produto p)
  {
    for(int i=0; i < catalogo.Count; i++)
    {
      if(p == catalogo[i])
      {
          return true; 
      }
    }
    return false;
  }

  public void AdicionarProduto(Produto p)
  {
    if(catalogo.Count > 0){
      for(int i=0; i < catalogo.Count; i++){
        if(p.GetIdProduto() != catalogo[i].GetIdProduto())
        {
          catalogo.Add(p);
          Console.WriteLine("O PRODUTO {0} FOI ADICIONADO AO CATALOGO", p.GetNomeProduto().ToUpper());
          break;
        }
        else
        {
          Console.WriteLine("O PRODUTO {0} JA SE ENCONTRA NO CATALOGO", p.GetNomeProduto().ToUpper());
          break;
        }
      }
    }
    else{
      catalogo.Add(p);
      Console.WriteLine("O PRODUTO {0} FOI ADICIONADO AO CATALOGO", p.GetNomeProduto().ToUpper());
    }
      
  }

  public void RemoverProduto(Produto p)
  {
    for(int i= 0; i < catalogo.Count; i++)
    {
      if(p == catalogo[i]){
        catalogo.Remove(p);
        Console.WriteLine("O PRODUTO {0} FOI REMOVIDO DO CATALOGO", p.GetNomeProduto().ToUpper());
      }
      else
      {
        Console.WriteLine("O PRODUTO {0} NÃO SE ENCONTRA NO CATALOGO", p.GetNomeProduto().ToUpper());
      }
    }
  }

  public void CadastrarCliente(Cliente c)
  {
    if(clientes.Count > 0)
    {
      for(int i = 0; i < clientes.Count; i ++){
        if(clientes[i] == c){
          Console.WriteLine("O CLIENTE {0} JA EXISTE NA LISTA DE CADASTROS",c.GetNome().ToUpper());
        }
      }
      clientes.Add(c);
      Console.WriteLine("O CLIENTE {0} FOI CADASTRADO",c.GetNome().ToUpper());
    }
    clientes.Add(c);
    Console.WriteLine("O CLIENTE {0} FOI CADASTRADO",c.GetNome().ToUpper());
  }

  public void RemoverCadastro(Cliente c)
  {
    bool ClienteExistente = false;
    foreach(Cliente ClienteNaLista in clientes)
    {
      if(ClienteNaLista.GetId() == c.GetId())
      {
        ClienteExistente = true;
        break;
      }
    }
    if(ClienteExistente == true)
    {
      clientes.Remove(c);
      Console.WriteLine("O CADASTRO DO CLIENTE {0} FOI APAGADO", c.GetNome().ToUpper());
    }
    else
    {
      Console.WriteLine("O CLIENTE {0} NÃO TEM UM CADASTRO", c.GetNome().ToUpper());
    }
  }

  public Cliente ProcuraCliente(int id){
    for(int i = 0; i < clientes.Count; i ++){
      if(clientes[i].GetId() == id){
        return clientes[i];
      }
    }
    return null;
  }
  
  public Produto ProcuraProduto(int id){
    for(int i = 0; i < catalogo.Count; i ++){
      if(catalogo[i].GetIdProduto() == id){
        return catalogo[i];
      }
    }
    return null;
  }
  public void ExibirCatalogo()
  {
      for(int i=0; i < catalogo.Count; i++)
    {
        Console.WriteLine("PRODUTO: {0} ID: {1}", catalogo[i].GetNomeProduto().ToUpper(), catalogo[i].GetIdProduto());
      }
    }

  public void MaisCompras()
  {
    List<Cliente> lista_de_clientes = clientes;
    if(lista_de_clientes.Count > 0)
    {
      Cliente cliente = lista_de_clientes[0];
      
      for(int i = 0; i < lista_de_clientes.Count; i++)
      {
        if(cliente.GetHistorico().Count < lista_de_clientes[i].GetHistorico().Count)
        {
            cliente = lista_de_clientes[i];
        }
      }
      Console.WriteLine("O CLIENTE {0} POSSUI O MAIOR NUMERO DE COMPRAS NA LOJA", cliente.GetNome().ToUpper());
    }
    else
    {
      Console.WriteLine("NÃO HOUVE NENHUMA COMPRA ");  
    }

  }

  public double SomaDeValores()
  {
    double soma = 0.0;

    for(int i = 0; i < clientes.Count; i++)
    {
      for(int x = 0; x < clientes[i].GetHistorico().Count; x++){
        soma = soma + clientes[i].GetHistorico()[x].GetPreco();
      }  
    }

    return soma;
  }

  public void MaisVendido()
  {
    if(catalogo.Count > 0)
    {
      Produto produto_mais_vendido= catalogo[0];
      int quantidade_mais_vendida = 0;
      
      foreach(Produto p in catalogo)
      {
        int qtd = 0;

        for(int i = 0; i < clientes.Count; i ++)
        {
          for(int x = 0; x <clientes[i].GetHistorico().Count; x ++)
          {
            List<Produto> historico = clientes[i].GetHistorico();
            if(historico[x].GetNomeProduto() == produto_mais_vendido.GetNomeProduto())
            {
              qtd = qtd + 1;
            }
          }
        }

        if(qtd > quantidade_mais_vendida)
          {
          quantidade_mais_vendida = qtd;
          if(p != produto_mais_vendido)
            {
            produto_mais_vendido = p; 
          }
        }
      }
      Console.WriteLine("O PRODUTO MAIS VENDIDO FOI: {0} COM {1} UNIDADES VENDIDAS",produto_mais_vendido.GetNomeProduto().ToUpper(),quantidade_mais_vendida);
    }
    else{
      Console.WriteLine("NENHUM PRODUTO FOI VENDIDO");
    }
      
  }
  
  public void GerarRelatorio()
  {
    double total_arecadado = SomaDeValores();
    Console.WriteLine();
    Console.WriteLine("-------------------RELATORIO DE VENDAS----------------------");
    for(int i = 0; i < clientes.Count; i ++)
    {
      clientes[i].VizualizarHistorico();
      Console.WriteLine("------------------------------------------------------------");
    }
    MaisCompras();
    Console.WriteLine("------------------------------------------------------------");
    for(int i =0; i < catalogo.Count; i ++)
    {
      if(catalogo[i].GetEstoque() <= catalogo[i].GetEstoqueMinimo()){
        Console.WriteLine("O PRODUTO {0} ATINGIO SEU ESTOQUE MINIMO",catalogo[i].GetNomeProduto().ToUpper());
      }
    }
    MaisVendido();
    Console.WriteLine("------------------------------------------------------------");
    Console.WriteLine("O TOTAL ARRECADADO FOI: {0} R$",total_arecadado);
    Console.WriteLine();
  }
}