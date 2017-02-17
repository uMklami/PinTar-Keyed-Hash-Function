using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace NewKeyScheduling
{
    class Statistics 
    {
        public Statistics()
        {
        }

        public double Correlation(string message, byte[] digest)
        {
            byte[] array1 = Encoding.ASCII.GetBytes(message);
            
            int[] msg = new int[message.Length];
            int[] dig = new int[digest.Length];
            for (int i = 0; i < message.Length; i++)
            {
                msg[i] = array1[1];
            }
            for (int i = 0; i < digest.Length; i++)
            {
                dig[i] = digest[i];
            }

            int [] arr = new int[array1.Length];

            double av1 = average(msg);
            double av2 = average(dig);
            for (int i = 0; i < msg.Length; i++)
            {
                arr[i] = (int)(msg[i] - (int)av1) * (dig[i] - (int)av2);
            }
            double d = 0;
            for (int i = 0; i < msg.Length; i++)
            {
                d = d + arr[i];
            }
            double sd1 = standardDeviation(msg);
            double sd2 = standardDeviation(dig);
            return (d / (sd1 * sd2)) / (msg.Length - 1);
        }

        double standardDeviation(int[] array)
        {
            double[] arr = new double[array.Length];
            double av = average(array);
            for (int i = 0; i < array.Length; i++)
            {
                arr[i] = (array[i] - av) * (array[i] - av);
            }
            double d = 0;
            for (int i = 0; i < array.Length; i++)
            {
                d = d + arr[i];
            }
            return Math.Sqrt(d / (arr.Length - 1));
        }

        double average(int[] array)
        {
            double d = 0;
	        int total = 0;
	        for (int i = 0; i < array.Length; i++) 
                {
	              total = total + array[i];
	            }
	        d = total / array.Length;
	        return d;
	  }
    }
    
}
