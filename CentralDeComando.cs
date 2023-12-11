using System;

using System.Collections.Generic;

using System.IO;
using System.Text;


class CentralDeComando 
{
  LojaVirtual minha_loja;

  public bool GravarDadosClientes(string NomeDoArquivo)
  {
    using(StreamWriter writer = new StreamWriter (NomeDoArquivo))
    {
      foreach(Cliente c in minha_loja.GetListaDeClientes())
      {
        string linha = string.Format("{0};{1};{2};{3}",c.GetNome(),c.GetIdade(),c.GetCpf(), c.GetId());
        writer.WriteLine(linha);
      }
    }
    return true;
  }

  public bool CarregarDadosClientes(string NomeDoArquivo)
  { 
    string[] linhas = File.ReadAllLines(NomeDoArquivo);
    foreach(string linha in linhas)
    {
      string[] dados = linha.Split(";");
      string nome = dados[0];
      int idade = int.Parse(dados[1]);
      string cpf = dados[2];
      int id = int.Parse(dados[3]);

      minha_loja.CadastrarCliente(new Cliente(nome, idade, cpf ,id));
    }
    return true;
  }

  public CentralDeComando()
  {
    minha_loja = new LojaVirtual();
  }

  public void MenuInicial()
  {
    string opcao = "";
    while(opcao != "0")
    {
      Console.Clear();
      Console.Write("------------------------------------------------------------");
      Console.Write("------------------------OPCÕES DO SISTEMA-------------------");
      Console.WriteLine("------------------------------------------------------------------");
      Console.WriteLine("0 - SAIR");
      Console.WriteLine("1 - CADASTRAR PRODUTO");
      Console.WriteLine("2 - CADASTRAR CLIENTE"); 
      Console.WriteLine("3 - ADICIONAR PRODUTO AO CARRINHO DO CLIENTE");
      Console.WriteLine("4 - REMOVER PRODUTO AO CARRINHO DO CLIENTE");
      Console.WriteLine("5 - FINALIZAR COMPRA DO CLIENTE");
      Console.WriteLine("6 - CANCELAR COMPRA DO CLIENTE");
      Console.WriteLine("7 - APRESENTAR RELATORIO DE VENDAS");
      Console.WriteLine("8 - GRAVAR DADOS DOS CLIENTES");
      Console.WriteLine("9 - CARREGAR DADOS DOS CIENTES");

      Console.WriteLine();

      Console.WriteLine("INFORME A OPÇÃO DESEJADA:");
      opcao = Console.ReadLine();
      
      Console.WriteLine();
      
      switch(opcao)
      {
        case "0":
          return;
        case "1":
          Console.WriteLine("INFORME O NOME DO PRODUTO");
          string nome_do_produto = Console.ReadLine();
          Console.WriteLine("INFORME O ID DO PRODUTO");
          int id_do_produto = int.Parse(Console.ReadLine());
          Console.WriteLine("INFORME O PREÇO DO PRODUTO");
          float preco = float.Parse(Console.ReadLine());
          Console.WriteLine("INFORME O ESTOQUE DO PRODUTO");
          int estoque = int.Parse(Console.ReadLine());
          Console.WriteLine("INFORME O ESTOQUE MINIMO");
          int estoque_min = int.Parse(Console.ReadLine());

        minha_loja.AdicionarProduto(new Produto(nome_do_produto, id_do_produto, preco, estoque, estoque_min));

          Console.WriteLine("APERTE QUALQUER TECLA PARA CONTINUAR");
          Console.ReadKey();
          break;
        case "2":
          Console.WriteLine("INFORME O NOME DO CLIENTE");
          string nome = Console.ReadLine();
          Console.WriteLine("INFORME A IDADE DO CLIENTE");
          int idade = int.Parse(Console.ReadLine());
          Console.WriteLine("INFORME O CPF DO CLIENTE");
          string cpf = Console.ReadLine();
          Console.WriteLine("INFORME O ID DO CLIENTE");
          int id = int.Parse(Console.ReadLine());
          minha_loja.CadastrarCliente(new Cliente(nome, idade, cpf, id));
          Console.WriteLine("APERTE QUALQUER TECLA PARA CONTINUAR");
          Console.ReadKey();
          break;
        case "3":
          Console.WriteLine("CATALOGO");
          minha_loja.ExibirCatalogo();
          Console.WriteLine();
          Console.WriteLine("INFORME O ID DO CLIENTE");
          int id_cliente = int.Parse(Console.ReadLine());
          Cliente cliente = minha_loja.ProcuraCliente(id_cliente);
          if(cliente != null){
            Console.WriteLine("INFORME O ID DO PRODUTO");
            int id_produto = int.Parse(Console.ReadLine());
            Produto produto = minha_loja.ProcuraProduto(id_produto);
            if(produto != null){
              produto.AdicionarAoCarrinho(cliente, minha_loja);
            }
          }
          Console.WriteLine("APERTE QUALQUER TECLA PARA CONTINUAR");
          Console.ReadKey();
          break;
        case "4":
          Console.WriteLine("CATALOGO");
          minha_loja.ExibirCatalogo();
          Console.WriteLine();
          Console.WriteLine("INFORME O ID DO CLIENTE");
          id_cliente = int.Parse(Console.ReadLine());
          cliente = minha_loja.ProcuraCliente(id_cliente);
          if(cliente != null){
            Console.WriteLine("INFORME O ID DO PRODUTO");
            int id_produto = int.Parse(Console.ReadLine());
            Produto produto = minha_loja.ProcuraProduto(id_produto);
            if(produto != null){
              produto.RemoverDoCarrinho(cliente);
            }
          }
          
          Console.WriteLine("APERTE QUALQUER TECLA PARA CONTINUAR");
          Console.ReadKey();
          break;
        case "5":
          Console.WriteLine("INFORME O ID DO CLIENTE");
          id_cliente = int.Parse(Console.ReadLine());
          Console.WriteLine("DIGITE A FORMA DE PAGAMENTO");
          Console.WriteLine("CARTAO DIGITE C /DINHEIRO DIGITE D");
          string forma_pagamento = Console.ReadLine().ToUpper();
          cliente = minha_loja.ProcuraCliente(id_cliente);
          if(cliente != null){
            cliente.FazerCompra(forma_pagamento);
          }
          Console.WriteLine("APERTE QUALQUER TECLA PARA CONTINUAR");
          Console.ReadKey();
          break;
        case "6":
          Console.WriteLine("INFORME O ID DO CLIENTE");
          id_cliente = int.Parse(Console.ReadLine());
          cliente = minha_loja.ProcuraCliente(id_cliente);
          cliente.VisualizarCarrinho();
          cliente.CancelarCompra();
          Console.WriteLine("APERTE QUALQUER TECLA PARA CONTINUAR");
          Console.ReadKey();
          break;
        case "7":
          minha_loja.GerarRelatorio();
          Console.WriteLine("APERTE QUALQUER TECLA PARA CONTINUAR");
          Console.ReadKey();
          break;
        case "8":
          GravarDadosClientes("LojaVirtual/DadosClientes.txt");
          Console.WriteLine("DADOS GRAVADOS COM SUCESSO");
          Console.WriteLine("APERTE QUALQUER TECLA PARA CONTINUAR");
          Console.ReadKey();
          break;
        default:
          Console.WriteLine("OPÇÃO INVALIDA");
          Console.WriteLine("APERTE QUALQUER TECLA PARA CONTINUAR");
          Console.ReadKey();
          break;
        case "9":
          bool realizar_acao = true;
          if(minha_loja.GetListaDeClientes().Count > 0)
          {
            Console.WriteLine("OS DADOS ATUAIS SERÃO SUBSTITUIDOS");
            Console.WriteLine("DESEJA CONTINUAR (S/N)");
            string opc = Console.ReadLine();
            if(opc.ToUpper() == "S")
            {
              minha_loja.LimpaListaDeClientes();
              realizar_acao = true;
            }
            else
            {
              realizar_acao = false;
            }
          }
          if(realizar_acao){
            CarregarDadosClientes("LojaVirtual/DadosClientes.txt");
            Console.WriteLine("OS DADOS FORAM CARREGADOS");
            Console.WriteLine("APERTE QUALQUER TECLA PARA CONTINUAR");
          }
        else
        {
            Console.WriteLine("OS DADOS NÃO FORAM CARREGADOS");
            Console.WriteLine("APERTE QUALQUER TECLA PARA CONTINUAR");
        }
          Console.ReadKey();
          break;
      }
      opcao = "";
    }
  }
  
  public static void Main (string[] args) 
  {
    CentralDeComando meu_gerenciador = new CentralDeComando();

    meu_gerenciador.MenuInicial();
  }
}