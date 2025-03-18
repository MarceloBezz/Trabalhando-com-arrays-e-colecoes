﻿using System.Collections;
using bytebank.Exceptions;
using bytebank.Modelos.Conta;
using bytebank.Utils;

Console.WriteLine("Boas vindas ao ByteBankm Atendimento.");

int idade0 = 30;
int idade1 = 40;
int idade2 = 17;
int idade3 = 21;
int idade4 = 18;

# region Exemplos Arrays
void TestarArrayInt()
{
    int[] idades = [idade0, idade1, idade2, idade3, idade4];

    Console.WriteLine($"Tamanho do array: {idades.Length}");
    foreach (var idade in idades)
    {
        Console.WriteLine($"{idade}");
    }

    int media = (int)idades.Average();
    Console.WriteLine($"Média das idades: {media}");
}

void TestarBuscarPalavra()
{
    string[] palavras = new string[5];
    for (int i = 0; i < palavras.Length; i++)
    {
        Console.Write($"Digite a {i + 1}ª palavra: ");
        palavras[i] = Console.ReadLine()!;
    }

    Console.WriteLine("Digite a palavra a ser encontrada: ");
    string busca = Console.ReadLine()!;

    if (palavras.Contains(busca))
    {
        Console.WriteLine($"Palavra {busca} encontrada no array!");
    }
    else
    {
        Console.WriteLine($"A palavra {busca} não está contida no array!");
    }
}

// TestarArrayInt();
// TestarBuscarPalavra();

Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

void TestaMediana(Array array)
{
    if (array == null || array.Length == 0)
    {
        Console.WriteLine("Array para cálculo de mediana vazio ou nulo");
    }
    else
    {
        double[] numerosOrdenados = (double[])array.Clone();
        Array.Sort(numerosOrdenados);

        int tamanho = numerosOrdenados.Length;
        int meio = tamanho / 2;
        double mediana =
            (tamanho % 2 != 0)
                ? numerosOrdenados[meio]
                : (numerosOrdenados[meio] + numerosOrdenados[meio + 1]) / 2;

        Console.WriteLine($"Com base na amostra, a mediana é igual a {mediana}");
    }
}

// TestaMediana(amostra);

// System.IndexOutOfRangeException:

// int[] valores = [1,2,3,4];
// for (int i = 0; i < 6; i++)
// {
//     Console.WriteLine($"{valores[i]}");
// }

//AULA 2
void TestaArrayDeContasCorrentes()
{
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaDeContas.Adicionar(new ContaCorrente(875, "445668-A"));
    listaDeContas.Adicionar(new ContaCorrente(876, "445669-A"));
    listaDeContas.Adicionar(new ContaCorrente(877, "445670-A"));
    listaDeContas.Adicionar(new ContaCorrente(878, "445671-A"));
    listaDeContas.Adicionar(new ContaCorrente(879, "445672-A"));
    listaDeContas.Adicionar(new ContaCorrente(880, "445673-A"));
    var contaExclusao = new ContaCorrente(675, "123456-Z");
    listaDeContas.Adicionar(contaExclusao);

    // listaDeContas.ExibeLista();
    // listaDeContas.Remover(contaExclusao);
    // Console.WriteLine("============================");
    // listaDeContas.ExibeLista();

    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        var conta = listaDeContas[i];
        Console.WriteLine($"índice {i} - {conta.Conta}/{conta.Numero_agencia}");
    }
}
// TestaArrayDeContasCorrentes();
#endregion

List<ContaCorrente> listaDeContas = new()
{
    new ContaCorrente(97, "706235-Z")
    {
        Saldo = 300,
        Titular = new Cliente { Cpf = "11111", Nome = "Marcelo" },
    },
    new ContaCorrente(96, "789001-Y")
    {
        Saldo = 200,
        Titular = new Cliente { Cpf = "22222", Nome = "Felipe" },
    },
    new ContaCorrente(95, "123456-X")
    {
        Saldo = 100,
        Titular = new Cliente { Cpf = "33333", Nome = "Joãozinho" },
    },
    new ContaCorrente(95, "123456-X")
    {
        Saldo = 100,
        Titular = new Cliente { Cpf = "33333", Nome = "Joãozinho" },
    },
};

Atendimento();
void Atendimento()
{
    try
    {
        char opcao = '0';
        while (opcao != '6')
        {
            Console.Clear();
            Console.WriteLine(
                @"
        ========================================
        ====            Atendimento         ====
        ==== 1 - Cadastrar conta            ====
        ==== 2 - Listar contas              ====
        ==== 3 - Remover conta              ====
        ==== 4 - Ordenar contas             ====
        ==== 5 - Pesquisar conta            ====
        ==== 6 - Sair do sistema            ====
        ========================================
        Digite a opção desejada:
        "
            );
            try
            {
                opcao = Console.ReadLine()![0];
            }
            catch (Exception ex)
            {
                throw new ByteBankExceptions(ex.Message);
            }
            switch (opcao)
            {
                case '1':
                    CadastrarConta();
                    break;
                case '2':
                    ListarContas();
                    break;
                case '3':
                    RemoverConta();
                    break;
                case '4':
                    OrdenarContas();
                    break;
                case '5':
                    PesquisarConta();
                    break;
                case '6':
                    Console.WriteLine("Até a próxima (:");
                    break;
                default:
                    Console.WriteLine("Opção não implementada");
                    break;
            }
        }
    }
    catch (ByteBankExceptions ex)
    {
        Console.WriteLine($"{ex.Message}");
    }
}

void PesquisarConta()
{
    Console.Clear();
    Console.WriteLine(
        @"
    ===============================
    ===     Pesquisar conta     ===
    ===============================

    "
    );
    Console.Write("Desejar pesquisar por (1) NÚMERO DA CONTA, (2) CPF TITULAR ou (3) NÚMERO DA AGÊNCIA? ");
    switch (int.Parse(Console.ReadLine()!))
    {
        case 1:
            Console.Write("Informe o Número da Conta: ");
            string numeroConta = Console.ReadLine()!;
            ContaCorrente? consultaConta = ConsultaPorNumeroConta(numeroConta);
            if (consultaConta != null)
            {
                Console.WriteLine(consultaConta.ToString());
            }
            else
            {
                Console.WriteLine(
                    "Conta não encontrada! Verifique se os dados foram digitados corretamente."
                );
            }
            Console.ReadKey();
            break;
        case 2:
            Console.Write("Informe o CPF do titular: ");
            string cpf = Console.ReadLine()!;
            ContaCorrente? consultaCpf = ConsultaPorCPFTitular(cpf);
            if (consultaCpf != null)
            {
                Console.WriteLine(consultaCpf.ToString());
            }
            else
            {
                Console.WriteLine(
                    "Conta não encontrada! Verifique se os dados foram digitados corretamente."
                );
            }
            Console.ReadKey();
            break;
        case 3:
            Console.Write("Informe o Número da Agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine()!);
            List<ContaCorrente> consultaNumeroAgencia = ConsultaPorNumeroAgencia(numeroAgencia);
            if (consultaNumeroAgencia.Count > 0)
            {
                foreach (var conta in consultaNumeroAgencia)
                {
                    Console.WriteLine(conta.ToString());
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine(
                    "Agência não encontrada! Verifique se os dados foram digitados corretamente."
                );
                Console.ReadKey();
            }
            break;
        default:
            Console.WriteLine("Opção digitada não reconhecida!");
            break;
    }
}

List<ContaCorrente> ConsultaPorNumeroAgencia(int numeroAgencia)
{
    return [.. listaDeContas.Where(c => c.Numero_agencia == numeroAgencia)];
}

ContaCorrente? ConsultaPorCPFTitular(string cpf)
{
    return listaDeContas.Where(c => c.Titular.Cpf.Equals(cpf)).FirstOrDefault();
}

ContaCorrente? ConsultaPorNumeroConta(string numeroConta)
{
    return listaDeContas.Where(c => c.Conta.Equals(numeroConta)).FirstOrDefault();
}

void OrdenarContas()
{
    listaDeContas.Sort();
    Console.WriteLine("...Lista de contas ordenada...");
    Console.ReadKey();
}

void RemoverConta()
{
    Console.Clear();
    Console.WriteLine(
        @"
    ===============================
    ===      Remover conta      ===
    ===============================

    "
    );
    Console.Write("Informe o número da Conta: ");
    string numeroConta = Console.ReadLine()!;
    if (listaDeContas.Any(c => c.Conta.Equals(numeroConta)))
    {
        listaDeContas.RemoveAll(c => c.Conta.Equals(numeroConta));
        Console.WriteLine("Conta removida da lista!");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Conta para remoção não encontrada...");
        Console.ReadKey();
    }
}

void ListarContas()
{
    Console.Clear();
    if (listaDeContas.Count <= 0)
    {
        Console.WriteLine("...Não há contas cadastradas...");
        Console.ReadKey();
        return;
    }
    foreach (ContaCorrente conta in listaDeContas)
    {
        Console.WriteLine(conta.ToString());
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>");
        Console.ReadKey();
    }
}

void CadastrarConta()
{
    Console.Clear();
    Console.WriteLine(
        @"
    ===============================
    ===   CADASTRO DE CONTAS    ===
    ===============================
    Informe dados da conta

    "
    );
    Console.Write("Número da Conta: ");
    string numeroConta = Console.ReadLine()!;

    Console.Write("Número da Agência: ");
    int numeroAgencia = int.Parse(Console.ReadLine()!);

    ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

    Console.Write("Informe o saldo inicial: ");
    conta.Saldo = double.Parse(Console.ReadLine()!);

    Console.Write("Informe o nome do titular: ");
    conta.Titular.Nome = Console.ReadLine()!;

    Console.Write("Informe o CPF do titular: ");
    conta.Titular.Cpf = Console.ReadLine()!;

    Console.Write("Informe profissão do titular: ");
    conta.Titular.Profissao = Console.ReadLine()!;

    listaDeContas.Add(conta);
    Console.WriteLine("...Conta cadastrada com sucesso!...");
    Console.WriteLine("...Aperte qualquer tecla para sair...");
    Console.ReadKey();
}
