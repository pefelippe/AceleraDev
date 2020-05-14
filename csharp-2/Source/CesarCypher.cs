using System;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {

        public string Crypt(string message)
        {
            message = message.ToLower();

            char[] msg = message.ToCharArray();
            // a = 97 e z = 122
            // ultimos numeros tem q voltar pro começo
            // ignorar espaço
            foreach(char c in msg)
            {
                int converter = c;
                if(converter >= 97 && converter <= 122)
                {
                    converter += 3;
                    
                }
                char cripted = (char)converter;
                Console.Write(cripted);
            }

            string cryptedMsg = msg.ToString();

            return cryptedMsg;
        }

        public string Decrypt(string cryptedMessage)
        {
            cryptedMessage = cryptedMessage.ToLower();
            string decriptedMessage = " ";
            return decriptedMessage;
        }


    }
}
