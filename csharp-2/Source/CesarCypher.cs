using System;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {

        public string Crypt(string message)
        {

            if (String.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException();
            }

            message = message.ToLower();

            char[] msg = message.ToCharArray();
            int i = 0;

            foreach(char c in msg)
            {   
                int converter = c;

                if(converter >= 97 && converter <= 119)
                {
                    converter += 3;
                }
                else if(converter >= 120 && converter <= 122)
                {
                    converter -= 23;
                }
                else if(converter > 122 && converter < 255)
                {
                    throw new ArgumentOutOfRangeException();
                }

                msg[i] = (char)converter;
                i++;
            }

            string cryptedMsg = new string (msg);

            return cryptedMsg;
        }

        public string Decrypt(string cryptedMessage)
        {
            if (String.IsNullOrEmpty(cryptedMessage))
            {
                throw new ArgumentNullException();
            }

            cryptedMessage = cryptedMessage.ToLower();

            char[] charCrypted = cryptedMessage.ToCharArray();

            int i = 0;

            foreach (char c in charCrypted)
            {
                int converter = c;

                if (converter >= 100 && converter <= 122)
                {
                    converter -= 3;
                }
                else if (converter >= 97 && converter <= 99)
                {
                    converter += 23;
                }
                else if (converter > 122 && converter < 255)
                {
                    throw new ArgumentOutOfRangeException();
                }

                charCrypted[i] = (char)converter;
                i++;
            }


            string decriptedMessage = new string(charCrypted);
            return decriptedMessage;
        }


    }
}
