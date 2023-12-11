using System;

using System.Collections.Generic;

class Cliente : Pessoa 
{
  private int id;

  private LojaVirtual loja;
  
  private List<Produto> carrinho;
  private List<Produto> historico;
  
  public Cliente(string nome, int idade, string cpf, int id) : base(nome, idade, cpf)
  {
    this.id = id;
    
    this.carrinho = new  List<Produto>();
    this.historico = new List<Produto>();

  }

  public int GetId()
  {
    return id;
  }

  public void SetId(int NovoId)
  {
    id = NovoId;
  }

  public List<Produto> GetCarrinho()
  {
    return carrinho;
  }

  public List<Produto> GetHistorico()
  {
    return historico;
  }

  public void FazerCompra(string forma_pagamento)
  {
    if(carrinho != null && carrinho.Count > 0)
    {
    double valor_a_pagar = 0.0;
    for(int i = 0; i < carrinho.Count; i++)
    {
      valor_a_pagar = valor_a_pagar + carrinho[i].GetPreco(); 
      historico.Add(carrinho[i]);
    }

    switch(forma_pagamento){
    case "C": 
      valor_a_pagar = valor_a_pagar + (valor_a_pagar * 0.05);
      break;
    case "D":
      valor_a_pagar= valor_a_pagar - (valor_a_pagar * 0.05);
      break;
    default: 
      Console.WriteLine("ERRO");
      break; 
      
    } 
      
    this.VisualizarCarrinho();
    Console.WriteLine("VALOR TOTAL DA COMPRA: {0}", valor_a_pagar);
    carrinho.Clear();
    valor_a_pagar = 0.0;
    }
  }
  
  public void CancelarCompra()
  {
    for(int i = 0; i < carrinho.Count; i ++){
      carrinho[i].SetEstoque(carrinho[i].GetEstoque() + 1);
    }
    carrinho.Clear();
    Console.WriteLine("SUA COMPRA FOI CANCELADA E O CARRINHO ESVAZIADO");
  }

  public void VisualizarCarrinho()
  {
    Console.WriteLine("CARRINHO DE COMPRAS");
    for(int i=0; i < this.carrinho.Count; i++)
    {
      Console.WriteLine("CLIENTE: {0}",this.GetNome().ToUpper());
      Console.WriteLine("PRODUTO: {0} PREÇO: {1}",this.carrinho[i].GetNomeProduto().ToUpper(), this.carrinho[i].GetPreco());
    }
  }

  public void VizualizarHistorico()
  {
    Console.WriteLine("HISTORICO DE COMPRAS");
    for(int i = 0; i < historico.Count; i++)
    {
      Console.WriteLine("CLIENTE: {0}",this.GetNome().ToUpper());
      Console.WriteLine("PRODUTO: {0} PREÇO: {1}",this.historico[i].GetNomeProduto().ToUpper(),this.historico[i].GetPreco());
    }
  }

  
}       