using Codenation.Challenge;
using System;

namespace myProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            CesarCypher cypher = new CesarCypher();

            string msgTeste = "the quick brown fox jumps over the lazy dog";

            msgTeste = cypher.Crypt(msgTeste);
            //Console.WriteLine("Encriptografada: " + msgTeste);

            //msgTeste = cypher.Decrypt(msgTeste);
            //Console.WriteLine("Decriptografada: " + msgTeste);
        }
    }
}
