using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuebraDeSenha
{
    public class Cracker
    {
        //Define os pârametros para quebrar a senha
        public static char primeirochar = '0';
        public static char ultimochar = '9';
        public static int tamanhoSenha = 11;
        public static long tentativas = 0;
        public static bool concluido = false;
        public static string password = "abc";

        public static void QuebraSenha(string chaves)
        {
            if (chaves == password)
            {
                concluido = true;
            }
            if (chaves.Length == tamanhoSenha || concluido == true)
            {
                return;
            }
            for (char c = primeirochar; c <= ultimochar; c++)
            {
                tentativas++;
                QuebraSenha(chaves + c);
            }
        }
    }
}
