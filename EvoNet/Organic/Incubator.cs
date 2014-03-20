using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoNet.Organic
{
    public class Incubator
    {
        public static Genom CreateGenom(int minLength, int maxLength, byte geneLength)
        {
            Random rnd = new Random();
            int genomLength = rnd.Next(minLength, maxLength);
            byte[] genom = new byte[genomLength];
            for (int i = 0; i < genom.Length; i++)
            {
                genom[i] = (byte)rnd.Next(geneLength);
            }
            return new Genom(genom);
        }

        public static Genom CreateGenom(int genomLength, byte geneLength)
        {
            Random rnd = new Random();
            byte[] genom = new byte[genomLength];
            for (int i = 0; i < genom.Length; i++)
            {
                genom[i] = (byte)rnd.Next(geneLength);
            }
            return new Genom(genom);
        }
    }
}
