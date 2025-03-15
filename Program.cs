using bytebank.Modelos.Conta;
using bytebank.Utils;

Console.WriteLine("Boas vindas ao ByteBankm Atendimento.");

int idade0 = 30;
int idade1 = 40;
int idade2 = 17;
int idade3 = 21;
int idade4 = 18;

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
TestaArrayDeContasCorrentes();
