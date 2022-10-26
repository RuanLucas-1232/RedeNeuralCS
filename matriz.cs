namespace RedeNeuralCS
{
    public class matriz
    {
        public double preNeuronio1 = 0;
        public double preNeuronio2 = 0;
        public double preNeuronio3 = 0;

        public void multiplicarMatriz(double[] entrada, double[,] pesos)
        {
            for (int i = 0; i < 1; i++)
            {
                preNeuronio1 = entrada[i] * pesos[i, i] + entrada[i + 1] * pesos[i, i + 1] + entrada[i + 2] * pesos[i, i + 2];
                preNeuronio2 = entrada[i] * pesos[i + 1, i] + entrada[i + 1] * pesos[i + 1, i + 1] + entrada[i + 2] * pesos[i + 1, i + 2];
                preNeuronio3 = entrada[i] * pesos[i + 2, i] + entrada[i + 1] * pesos[i + 2, i + 1] + entrada[i + 2] * pesos[i + 2, i + 2];
            }
        }

        public double funcaoAtivacao(double preNeuronio){
            double neuronio = 1/(1+Math.Pow(Math.E,-preNeuronio));

            if (neuronio >= 0.5)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public double erro(double neuronio, double valorReal){
            double erro = 0;

            erro = Math.Pow(neuronio - valorReal ,2);

            erro = erro * 1/2;

            return erro;
        }
    }

}