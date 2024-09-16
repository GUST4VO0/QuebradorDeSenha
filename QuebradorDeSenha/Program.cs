using QuebraDeSenha;
using System;
using System.Diagnostics;
using System.Threading;

namespace QuebraDeSenha
{
    class Program
    {
        static Stopwatch timer = new Stopwatch(); // Mover o cronômetro para fora do Main

        static void Main(string[] args)
        {

            Console.WriteLine("Teste de Força Bruta");
            Console.Write("\nInforme uma senha  > ");

            Cracker.password = Convert.ToString(Console.ReadLine());
            Cracker.password = Cracker.password.ToLower();
            Console.WriteLine("\nQuebrando a senha...");

            timer.Start(); // Iniciar o cronômetro aqui

            Cracker.tamanhoSenha = Cracker.password.Length;
            Timer reportTimer = new Timer(ReportStatus, null, 0, 20000); // A cada 20 segundos

            Cracker.QuebraSenha(string.Empty);

            timer.Stop();
            reportTimer.Dispose();
            long elapsedMs = timer.ElapsedMilliseconds;
            double tempoGasto = elapsedMs / 1000.0;

            Console.WriteLine("\n\nA senha foi quebrada! Estatísticas:");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Senha: {0}", Cracker.password);
            Console.WriteLine("Tamanho da Senha: {0}", Cracker.tamanhoSenha);
            Console.WriteLine("Tentativas: {0}", Cracker.tentativas);
            string plural = tempoGasto == 1 ? "segundo" : "segundos";
            Console.WriteLine("Tempo gasto para hackear a senha: {0} {1}", tempoGasto, plural);
            Console.WriteLine("Senhas por segundo: {0}", (long)(Cracker.tentativas / tempoGasto));
            Console.ReadKey();
        }

        static void ReportStatus(object state)
        {
            Console.WriteLine("\nTentativas até agora: {0}", Cracker.tentativas);
            double tempoGasto = timer.Elapsed.TotalSeconds;
            Console.WriteLine("Tempo gasto: {0} segundos", tempoGasto);

            if (timer.Elapsed.TotalMinutes >= 10)
            {
                Console.WriteLine("\nTempo limite de" +
                    " minutos atingido.");
                Environment.Exit(0);
            }
        }
    }
}
