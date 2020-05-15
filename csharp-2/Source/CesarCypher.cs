using System;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public static class Constants
        {
            public const int salto = 3;
        }

        public string Crypt(string message)
        {
            message = parseMessage(message);
            return scrollArray(message, true);
        }

        public string Decrypt(string cryptedMessage)
        {
            cryptedMessage = parseMessage(cryptedMessage);
            return scrollArray(cryptedMessage, false);
        }

        public string parseMessage(string message)
        {
            if (String.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException();
            }

            return message.ToLower();
        }

        public string scrollArray(string message, bool encrypt)
        {
            char[] charMessage = message.ToCharArray();
            int i = 0;

            foreach (char charAtual in charMessage)
            {
                int CharEmInt = charAtual;
                checkInvalid(CharEmInt);

                // CRIPTOGRAFAR
                if (encrypt == true)
                {
                    if (CharEmInt >= 97 && CharEmInt <= 119)
                    {
                        CharEmInt += Constants.salto;  
                    }
                    else if (CharEmInt >= 120 && CharEmInt <= 122) // x, y, z
                    {
                        CharEmInt -= 23; 
                    }
                }

                // DESCRIPTOGRAFAR
                else
                {
                    if (CharEmInt >= 100 && CharEmInt <= 122)
                    {
                        CharEmInt -= Constants.salto;
                    }
                    else if (CharEmInt >= 97 && CharEmInt <= 99) // a, b, c
                    {
                        CharEmInt += 23;
                    }
                }

                charMessage[i] = (char)CharEmInt;
                i++;
            }

            return new string(charMessage); 
        }

        public void checkInvalid(int CharEmInt) 
        {
            if (!(CharEmInt == 32 || (CharEmInt >= 97 && CharEmInt <= 122 ) || (CharEmInt >= 48 && CharEmInt <= 57)))
            {
                throw new ArgumentOutOfRangeException();
            }
        }

    }
}

