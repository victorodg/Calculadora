using System;
using System.Collections;
using System.Collections.Generic;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Operacoes> filaOperacoes = new Queue<Operacoes>();
            filaOperacoes.Enqueue(new Operacoes { valorA = 2, valorB = 3, operador = '+' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 14, valorB = 8, operador = '-' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 5, valorB = 6, operador = '*' });
            // int vai de -2147483648 a 2147483647 então alterei para long
            filaOperacoes.Enqueue(new Operacoes { valorA = 2147483647, valorB = 2, operador = '+' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 18, valorB = 3, operador = '/' });

            Calculadora calculadora = new Calculadora();
            //##################################
            //Implementando o stack a ser imprimido no final
            Stack<Operacoes> pilhaOperacoes = new Stack<Operacoes>();
            //##################################
            
            while (filaOperacoes.Count > 0)
            {
                Console.WriteLine("+---------------------------------------+\n");
                Operacoes operacao = filaOperacoes.Peek();
                calculadora.calcular(operacao);
                Console.WriteLine("{0} {1} {2} = {3}", operacao.valorA,operacao.operador,operacao.valorB, operacao.resultado);

                //############################################
                //armazena o resultado na pilha
                pilhaOperacoes.Push(operacao);
                //############################################

                //########################################################
                //# a primeira operação estava rodando infinitamente pois filaOperacoes.Count nunca diminuía
                filaOperacoes.Dequeue();
                //########################################################
                
                Console.WriteLine();
                
                //########################################################
                //# printa as próximas operações a serem executadas
                if (filaOperacoes.Count > 0)
                {
                    Console.WriteLine("Remaining Operations:");
                    foreach (Operacoes op in filaOperacoes)
                    {
                        Console.WriteLine("{0} {1} {2}", op.valorA, op.operador, op.valorB);
                    }
                    Console.WriteLine();
                }
                //########################################################
            }
            Console.WriteLine("+---------------------------------------+\n");
            //############################################
            //printa a pilha
            Console.WriteLine("Operations stack:\n");
            foreach (Operacoes opStack in pilhaOperacoes)
            {
                Console.WriteLine("{0} {1} {2} = {3}", opStack.valorA, opStack.operador, opStack.valorB, opStack.resultado);
            }
            Console.WriteLine("\n+---------------------------------------+");
        }
    }
}
