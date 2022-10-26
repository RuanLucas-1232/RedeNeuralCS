using RedeNeuralCS;

//decisão
/*
    1 = seguir em frente
    0 = retroceder
*/
//Infuencias
/*
    Caminho é Estreito = (1-Sim,0-Não)
    Caminho com Obstáculo = (0-Sim,1-Não)
*/
//Pesos
/*
    Inflência1 = 2
    Inflência1 = 5
*/

matriz matrizes = new matriz();

Console.Clear();

Console.WriteLine("Digite o valor da influência 1:");
double i1 = double.Parse(Console.ReadLine());

Console.WriteLine("Digite o valor da influência 2:");
double i2 = double.Parse(Console.ReadLine());

Console.WriteLine("Digite o valor do peso 1:");
double p1 = double.Parse(Console.ReadLine());

Console.WriteLine("Digite o valor do peso 2:");
double p2 = double.Parse(Console.ReadLine());

double[] influencias = { i1, i2 };
double[] pesos = { p1, p2 };

double somatorio = 0;
Console.Clear();

for (int i = 0; i < influencias.Length; i++)
{
    somatorio += influencias[i] * influencias[i];
}

double bias = -3;

somatorio += bias;

double neuronio = matrizes.funcaoAtivacao(somatorio);

if (neuronio == 1)
{
    Console.WriteLine("Siga em frente");
}
else
{
    Console.WriteLine("Volte para trás");
}

Console.WriteLine("Insira o valor real da decisão");
double valorReal = double.Parse(Console.ReadLine());

double erro = matrizes.erro(neuronio, 1);

Console.WriteLine($"\nErro: {erro}");

for (int it = 0; it < 100000; it++)
{


    for (int i = 0; i < influencias.Length; i++)
    {
        double n = influencias.Length;
        double constante = 0.003;

        pesos[i] = pesos[i] - constante * 1 / n * (neuronio - valorReal) * pesos[i];
        bias = bias - constante * 1 / n * (neuronio - valorReal) * influencias[i];
    }


    for (int i3 = 0; i3 < influencias.Length; i3++)
    {
        somatorio += influencias[i3] * influencias[i3];
    }

    somatorio += bias;

    neuronio = matrizes.funcaoAtivacao(somatorio);

    erro = matrizes.erro(neuronio, valorReal);

    Console.WriteLine($"Nº:{it}: Bias{bias}, Peso1 {pesos[0]}, Peso2 {pesos[1]} e Erro: {erro}");
    if (erro <= 0.05)
    {

        if (neuronio == 1)
        {
            Console.WriteLine("Siga em frente");
            break;
        }
        else
        {
            Console.WriteLine("Volte para trás");
            break;
        }

    }
}

string caminho = @"./Relatorio/relatorio.txt";

if (!File.Exists(caminho))
{
    using (StreamWriter sw = File.CreateText(caminho))
    {
        sw.WriteAsync($@"
        RELATÓRIO DE TREINOS GERAL
        Neurônio: {neuronio}\n
        Peso1: {pesos[0]}\n
        Peso2: {pesos[1]}\n
        Baias: {bias}\n
        Erro: {erro}\n
        ");
        sw.Close();
    }
}
else
{
    using (StreamWriter sw = File.CreateText(caminho))
    {
        sw.WriteAsync($@"================================
RELATÓRIO DE TREINOS GERAL
Neurônio: {neuronio}
Peso1: {pesos[0]}
Peso2: {pesos[1]}
Baias: {bias}
Erro: {erro}
================================");
        sw.Close();
    }
}

Thread.Sleep(5000);

Console.Clear();
//Treino

Console.WriteLine("Digite o valor da influência de Treino 1:");
double iT1 = double.Parse(Console.ReadLine());

Console.WriteLine("Digite o valor da influência de Treino 1:");
double iT2 = double.Parse(Console.ReadLine());

Console.WriteLine("Digite o valor do peso de Treino 1:");
double pT1 = double.Parse(Console.ReadLine());

Console.WriteLine("Digite o valor do peso de Treino 1:");
double pT2 = double.Parse(Console.ReadLine());

double[] influenciasTreino = { iT1, iT2 };
double[] pesosTreino = { pT1, pT2 };
double somatorioTreino = 0;
valorReal = neuronio;

for (int i = 0; i < influenciasTreino.Length; i++)
{
    somatorioTreino += influenciasTreino[i] * pesosTreino[i];
}

somatorioTreino += bias;

double neuronioTreino = matrizes.funcaoAtivacao(somatorioTreino);

double erroTreino = matrizes.erro(neuronioTreino, valorReal);

Console.WriteLine($"Erro: {erroTreino}");

if (erro <= 0.05)
{

    if (neuronioTreino == 1)
    {
        Console.WriteLine("Siga em frente");

    }
    else
    {
        Console.WriteLine("Volte para trás");

    }

}

/*
        RELATÓRIO DE TREINOS GERAL

    Treino 1:

    Interferência = 1
    Interferência = 0
    
    peso = 4
    peso = 5

    Resultado: 1 . errado.
    Correção: 0.

    Treino 2:

    Interferência = 1
    Interferência = 1
    
    peso = 4
    peso = 5

    Resultado: 1.

    Treino 3:

    Interferência = 0
    Interferência = 0
    
    peso = 4
    peso = 5

    Resultado: 0.

    Treino 4:

    Interferência = 0
    Interferência = 1
    
    peso = 4
    peso = 5

    Resultado: 1.
*/