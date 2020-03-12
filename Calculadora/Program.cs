using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Program
    {
        static List<Movimentacao> movimentacao = new List<Movimentacao>();
        
        static void Header(string area = null)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
            Console.WriteLine("Banco CS");
            
            if (! string.IsNullOrWhiteSpace(area))
            {
                Console.WriteLine(area);
            }

            Console.WriteLine("");
        }

        static void ErrorMessage(string msg = null)
        {
            if (string.IsNullOrWhiteSpace(msg))
                msg = "Entre com um valor numerico, pressione enter para continuar";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ReadLine();
        }

        static void Menu()
        {
            Header();

            Console.WriteLine("1 - Deposito");
            Console.WriteLine("2 - Saque");
            Console.WriteLine("3 - Extrato");
            Console.WriteLine("4 - Saldo");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("");
        }

        static void Deposito()
        {
            Header("DEPOSITO");

            try
            {
                Console.Write("Informe o valor a depositar ou digite 0 para sair: ");
                decimal valor = Convert.ToDecimal(Console.ReadLine());

                if (valor == 0)
                    return;

                movimentacao.Add(new Movimentacao
                {
                    Data = DateTime.Now,
                    Tipo = "C",
                    Valor = valor
                }) ;
            }
            catch (Exception)
            {
                ErrorMessage();
                Deposito();
            }

            Console.Write("Informe o valor a depositar:");

        }

        static void Saque()
        {
            Header("SAQUE");

            try
            {
                Console.Write("Informe o valor a sacar ou digite 0 para sair: ");
                decimal valor = Convert.ToDecimal(Console.ReadLine());

                if (valor == 0)
                    return;

                movimentacao.Add(new Movimentacao
                {
                    Data = DateTime.Now,
                    Tipo = "D",
                    Valor = valor
                });
            }
            catch (Exception)
            {
                ErrorMessage();
                Deposito();
            }

            Console.Write("Informe o valor a depositar:");

        }
        static void Main(string[] args)
        {
            int opcao = 0;

            do
            {
                

                Menu();

                try
                {
                    Console.Write("Informe a opcao desejada: ");
                    opcao = Convert.ToInt16(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Deposito();
                            break;

                        case 2:
                            Saque();
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    ErrorMessage();
                    opcao = 100;
                }

            } while (opcao > 0);
        }
    }
}
