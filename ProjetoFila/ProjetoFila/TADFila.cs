// Jhonatan Goulart - implementado dia 21/04
// pratica com objetivo de compreender a implementação e funcionamento de uma fila em C#



public class TADFila // classe TADFila
{
    private int codigo; // codigo dela
    private string descricao; // quaisquer descrição que queira que a fila tenha
    private int capacidade; // capacidade da fila
    private int[] elementos; // array de elementos da fila
    private int inicio; // indice para o inicio da fila
    private int fim; // indice para a proxima posição disponivel na fila

    public TADFila(int codigo, string descricao, int capacidade) // metodo construtor
    {
        this.codigo = codigo;
        this.descricao = descricao;
        this.capacidade = capacidade;
        this.elementos = new int[capacidade];
        this.inicio = 0;
        this.fim = 0;
    }

    public void incluirNaFila(int elemento) // metodo incluir, inclui mais um dado no proximo espaço disponivel
    {
        if ((fim + 1) % capacidade == inicio)
        {
            Console.WriteLine("Fila cheia");
        }
        else
        {
            elementos[fim] = elemento;
            fim = (fim + 1) % capacidade; 
            Console.WriteLine("Elemento enfileirado com sucesso");
        }
    }

    public int retirarDaFila() // metodo retirar, remove o primeiro elemento da fila e atualiza ela
    {
        if (inicio == fim)
        {
            Console.WriteLine("Fila vazia. Não hà elementos para desenfileirar");
            return -1;
        }
        else
        {
            int elementoDesenfileirado = elementos[inicio];
            inicio = (inicio + 1) % capacidade; // aqui atualizo o indice para manter a dinamica
            Console.WriteLine("Elemento desenfileirado");
            return elementoDesenfileirado;
        }
    }

    public void imprimirFila() // imprime toda a fila, começando do primeiro ate o ultimo
    {
        Console.WriteLine("Conteudo da fila:");
        int i = inicio;
        while (i != fim)
        {
            Console.WriteLine(elementos[i]);
            i = (i + 1) % capacidade;
        }
    }
}

public class Aplicacao
{
    public static void Main()
    {
        Console.WriteLine("Inicio do codigo");
        int op = 1, valor = 0;
        TADFila fila = new TADFila(1, "Fila", 5); // fila com tamanho 5 apenas para testes
                                                  // necessario outras alterações para uma fila dinamica

        while (op != 0)
        {
            Console.WriteLine("\nDigite 1 para enfileirar elementos, 2 para desenfileirar, 3 para listar e 0 para sair");
           
                op = int.Parse(Console.ReadLine());

                switch (op) // interação com usuario, bem simples apenas para testes
                {
                    case 1:
                        Console.WriteLine("\nDigite o valor para enfileirar:");
                        valor = int.Parse(Console.ReadLine());
                        fila.incluirNaFila(valor);
                        break;
                    case 2:
                        fila.retirarDaFila();
                        break;
                    case 3:
                        fila.imprimirFila();
                        break;
                    case 0:
                        Console.WriteLine("Saindo");
                        break;
                    default:
                        Console.WriteLine("Opção invalida");
                        break;
                }
            }
        Console.WriteLine("\nFim do codigo");

    }
        
    }