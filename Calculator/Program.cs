using System;
using CalculatorLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            //Title console app
            Console.WriteLine("Calculadora de Console em C#\r");
            Console.WriteLine("------------------------------\n");

            Calculator calculator = new Calculator();
            while (!endApp)
            {

                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                //Diz para o usuário informar o primeiro número
                Console.Write("Informe um número, e pressione Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write($"'{numInput1}' não é uma entrada válida, informe um número: ");
                    numInput1 = Console.ReadLine();
                }

                Console.Write("Informe outro número, e pressione Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write($"'{numInput2}' não é uma entrada válida, informe um número: ");
                    numInput2 = Console.ReadLine();
                }

                //Pergunta ao usuário a opção desejada
                Console.WriteLine("Escolha entre as opções a seguir: ");
                Console.WriteLine("\ta - Adição");
                Console.WriteLine("\ts - Subtração");
                Console.WriteLine("\tm - Multiplicação");
                Console.WriteLine("\td - Divisão");
                Console.Write("Sua opção? ");

                string op = Console.ReadLine();

                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Essa operação resultaria em um erro matemático.\n");
                    }
                    else Console.WriteLine("Seu resultado: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("--------------------------------------\n");

                //Aguardando comando do usuário antes de fechar.
                Console.Write("Pressione 'n' e Enter para fechar o app, ou pressione Enter para continuar: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }

            calculator.Finish();
            return;
        }
    }
}

