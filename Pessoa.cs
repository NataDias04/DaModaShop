using System;

using System.Collections.Generic;

class Pessoa
{
  protected string nome;
  protected int   idade;
  protected string  cpf;

  public Pessoa(string nome, int idade, string cpf){
    this.nome =   nome;
    this.idade = idade;
    this.cpf =     cpf;
  
  }

  public string GetNome()
  {
    return nome;
  }

  public void SetNome(string NovoNome)
  {
    nome = NovoNome.ToUpper();
  }

  public int GetIdade()
  {
    return idade;
  }

  public void SetIdade(int NovaIdade)
  {
    idade = NovaIdade;
  }

  public string GetCpf()
  {
    return cpf;
  }

  public void SetCpf(string NovoCpf) 
  {
    cpf = NovoCpf;
  }

  }     