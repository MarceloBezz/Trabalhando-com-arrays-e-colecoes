using bytebank.Exceptions;
using bytebank.Modelos.Conta;

namespace bytebank.Atendimento;

internal class ByteBankAtendimento
{
    private List<ContaCorrente> listaDeContas = new()
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

    public void Atendimento()
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

    private void PesquisarConta()
    {
        Console.Clear();
        Console.WriteLine(
            @"
    ===============================
    ===     Pesquisar conta     ===
    ===============================

    "
        );
        Console.Write(
            "Desejar pesquisar por (1) NÚMERO DA CONTA, (2) CPF TITULAR ou (3) NÚMERO DA AGÊNCIA? "
        );
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

    private List<ContaCorrente> ConsultaPorNumeroAgencia(int numeroAgencia)
    {
        return [.. listaDeContas.Where(c => c.Numero_agencia == numeroAgencia)];
    }

    private ContaCorrente? ConsultaPorCPFTitular(string cpf)
    {
        return listaDeContas.Where(c => c.Titular.Cpf.Equals(cpf)).FirstOrDefault();
    }

    private ContaCorrente? ConsultaPorNumeroConta(string numeroConta)
    {
        return listaDeContas.Where(c => c.Conta.Equals(numeroConta)).FirstOrDefault();
    }

    private void OrdenarContas()
    {
        listaDeContas.Sort();
        Console.WriteLine("...Lista de contas ordenada...");
        Console.ReadKey();
    }

    private void RemoverConta()
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

    private void ListarContas()
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

    private void CadastrarConta()
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
        Console.Write("Número da Agência: ");
        int numeroAgencia = int.Parse(Console.ReadLine()!);
        ContaCorrente conta = new(numeroAgencia);

        Console.WriteLine($"Número da conta [NOVA]: {conta.Conta}");

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
}
