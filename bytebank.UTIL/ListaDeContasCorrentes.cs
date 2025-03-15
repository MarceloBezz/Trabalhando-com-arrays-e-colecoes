using bytebank.Modelos.Conta;

namespace bytebank.Utils;

public class ListaDeContasCorrentes
{
    private ContaCorrente[] Itens = null;
    private int ProximaPosicao = 0;
    public int Tamanho => ProximaPosicao;
    public ContaCorrente this[int indice] => RecuperarItemIndice(indice);

    public ListaDeContasCorrentes(int tamanhoInicial = 5)
    {
        Itens = new ContaCorrente[tamanhoInicial];
    }

    public void Adicionar(ContaCorrente conta)
    {
        VerificarCapacidade(ProximaPosicao + 1);
        Console.WriteLine($"Adicionando item na posição {ProximaPosicao}");
        Itens[ProximaPosicao] = conta;
        ProximaPosicao++;
    }

    private void VerificarCapacidade(int tamanhoNecessario)
    {
        if (Itens.Length >= tamanhoNecessario)
        {
            return;
        }
        Console.WriteLine("Aumentando a capacidade da lista...");
        ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

        for (int i = 0; i < Itens.Length; i++)
        {
            novoArray[i] = Itens[i];
        }

        Itens = novoArray;
    }

    public void Remover(ContaCorrente conta)
    {
        int IndiceItem = -1;
        for (int i = 0; i < ProximaPosicao; i++)
        {
            ContaCorrente contaAtual = Itens[i];
            if (contaAtual == conta)
            {
                IndiceItem = i;
                break;
            }
        }

        // [] [] [] []
        for (int i = IndiceItem; i < ProximaPosicao - 1; i++)
        {
            Itens[i] = Itens[i + 1];
        }
        ProximaPosicao--;
        Itens[ProximaPosicao] = null;
    }

    public void ExibeLista()
    {
        for (int i = 0; i < Itens.Length; i++)
        {
            if (Itens[i] != null)
            {
                var conta = Itens[i];
                Console.WriteLine($"Índice {i} = Conta: {conta.Conta} - Agência: {conta.Numero_agencia} ");
            }
        }
    }

    public ContaCorrente RecuperarItemIndice(int indice)
    {
        if (indice < 0 || indice >= ProximaPosicao)
        {
            throw new ArgumentOutOfRangeException("Índice inválido!");
        }
        return Itens[indice];
    }
}
